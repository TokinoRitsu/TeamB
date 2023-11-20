using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Keep hand componenet in 2nd position to make scrip works
    [SerializeField] int tier; //Set the enemy tier;
    [SerializeField] int cost;

    NavMeshAgent agent;
    public Vector3 player_pos;
    bool onBaCD; //Basic attack cooldown
    public bool hit; //True if this attack hit already
    float cd_counter; //Counter for cooldown

    Animator animator; //Animator
    public Enemy e;

    public GameObject bonus;
    public bool chasingTarget; //Is the enemy chasing a target?

    private Material material;

    public enum EnemyStates
    {
        Idle,
        Chasing,
        Bonus,
        Attack,
        Dead,
    }

    public EnemyStates currentState;

    private void Awake()
    {
        e = new Enemy(tier, cost); //New enemy
        cd_counter = 0;
        onBaCD = false;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = transform.GetChild(1).GetComponent<Animator>(); //Get Animator componenet from hand
        currentState = EnemyStates.Idle;
        player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;

        chasingTarget = false;


        material = GetComponent<MeshRenderer>().material;
        if (e.isBoss) material.color = new Color(1, 0, 0);
        else if (e.hasHpReward) material.color = new Color(0, 1, 0);
        else material.color = new Color(1, 1, 1);

        Debug.Log(e.enemyTier);
    }

    void Update()
    {

        player_pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Debug.Log(Vector3.Distance(player_pos.position, transform.position));
        //Basic attack cooldown counting on any state
        if (onBaCD)
        {
            //GetComponent<MeshRenderer>().material.color = Color.white;
            cd_counter += Time.deltaTime;
            if (cd_counter >= e.GetAttack_Delay())
            {
                cd_counter = 0; //Reset the counter
                onBaCD = false;
            }
        }

        switch (currentState)
        {
            case EnemyStates.Idle:
                break;
            case EnemyStates.Chasing:
                chasingTarget = true;
                agent.destination = player_pos; //Chase player
                

                //If player in attack range, switch to attack state
                if (Vector3.Distance(player_pos, transform.position) <= e.attack_range)
                {
                    
                    currentState = EnemyStates.Attack;
                }

                break;

            case EnemyStates.Bonus:
                agent.destination = bonus.transform.position;
                if (chasingTarget)
                {

                }

                break;


            case EnemyStates.Attack:

                //If player still in range and not on basic attack cooldown, attack
                if (Vector3.Distance(player_pos, transform.position) <= e.attack_range && !onBaCD)
                {
                    if (e.GetTier() == 1 && e.GetEnemyCost() == 1)
                    {
                        agent.isStopped = true; //Stop the agent if in attack range;
                        Attack(e.GetAttack());
                    }

                    if (e.GetTier() == 1 && e.GetEnemyCost() == 2)
                    {
                        Debug.Log("Doing");
                        agent.destination = player_pos;
                        SpinAttack(500, 5);
                    }
                    
     
                } else if (Vector3.Distance(player_pos, transform.position) <= e.attack_range && onBaCD)
                {
                    if (animator != null)
                        animator.SetBool("attack", false);
                    //wait for next attack
                } else
                {
                 
                    agent.isStopped = false;
                    if (animator != null)
                        animator.SetBool("attack", false);
                    currentState = EnemyStates.Chasing;
                   
                    
                }


                break;
            case EnemyStates.Dead:
                break;
        }
    }


    public EnemyStates getCurrentEnemyState() { return currentState; }
    public void setCurrentEnemyState(EnemyStates currentState) { this.currentState = currentState; }
    public Enemy GetEnemy() { return e; }

    //Temp attack function, not by hit box and collider
    public void Attack(float damage)
    {
        //player_pos.gameObject.GetComponent<PlayerController>().HP_Now -= damage;
        animator.SetBool("attack", true);
        onBaCD = true;
    }

    public void SpinAttack(float speed, float duration)
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
        
    }
}
