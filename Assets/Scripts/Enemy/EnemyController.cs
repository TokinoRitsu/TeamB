using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Keep hand componenet in 2nd position to make scrip works

    NavMeshAgent agent;
    public Transform player_pos;
    bool onBaCD; //Basic attack cooldown
    public bool hit; //True if this attack hit already
    float cd_counter; //Counter for cooldown

    Animator animator; //Animator
    public Enemy e;
    public float enemyHP_Now;

    public GameObject bonus;
    public bool chasingTarget; //Is the enemy chasing a target?

    public bool busy; //check if whether enemy is going to grab bonus

    //Bomb
    public GameObject bomb_gameobject;
    public Transform bomb_startPos;

    public enum EnemyStates
    {
        Idle,
        Chasing,
        Bonus,
        Attack,
        Dead,
    }

    EnemyStates currentState;

    private void Awake()
    {
        cd_counter = 0;
        onBaCD = false;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = transform.GetChild(1).GetComponent<Animator>(); //Get Animator componenet from hand
        enemyHP_Now = e.enemyHP_Max;
        currentState = EnemyStates.Idle;
        player_pos = GameObject.FindGameObjectWithTag("Player").transform;

        chasingTarget = false;
    }

    void Update()
    {
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

        if (enemyHP_Now <= 0)
        {
            Debug.Log("Dead");
            setCurrentEnemyState(EnemyStates.Dead);
        }

        switch (currentState)
        {
            case EnemyStates.Idle:
                break;
            case EnemyStates.Chasing:
                chasingTarget = true;
                agent.destination = player_pos.position; //Chase palyer
                

                //If player in attack range, switch to attack state
                if (Vector3.Distance(player_pos.position, transform.position) <= e.attack_range)
                {
                    
                    currentState = EnemyStates.Attack;
                }

                break;

            case EnemyStates.Bonus:
                if (bonus != null)
                {
                    agent.destination = bonus.transform.position;
                } else
                {
                    if (chasingTarget)
                    {
                        currentState = EnemyStates.Chasing;
                    } else
                    {
                        currentState = EnemyStates.Idle;
                    }
                }
                
                if (chasingTarget)
                {

                }

                break;


            case EnemyStates.Attack:

                //If player still in range and not on basic attack cooldown, attack
                if (Vector3.Distance(player_pos.position, transform.position) <= e.attack_range && !onBaCD)
                {
                    if (e.GetTier() == 1)
                    {
                        agent.isStopped = true; //Stop the agent if in attack range;
                        Attack(e.GetAttack());
                    }

                    if (e.GetTier() == 2)
                    {
                        Debug.Log("Doing");
                        agent.destination = player_pos.position;
                        SpinAttack(500, 5);
                    }

                    if (e.GetTier() == 3)
                    {
                        
                        ThrowBomb(e.GetAttack());
                    }
                    
     
                } else if (Vector3.Distance(player_pos.position, transform.position) <= e.attack_range && onBaCD)
                {
                    if (animator != null)
                    {
                        animator.SetBool("attack", false);
                    }
                    
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
                Destroy(gameObject);
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
        //animator.SetBool("attack", true);
        onBaCD = true;
    }

    public void SpinAttack(float speed, float duration)
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
        
    }

    public void ThrowBomb(float damage)
    {
        transform.LookAt(player_pos);
        GameObject b = Instantiate(bomb_gameobject, bomb_startPos.position, Quaternion.identity);
        onBaCD = true;
    }
}
