using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rb;

    public float HP_Max;
    public float HP_Now;

    private Vector2 moveInput;
    private float playerSpeed;
    public float playerAtk;

    private bool isAttacking;
    private float attackCooldown;
    private float attackTimer;

    private bool isDashing;
    public bool dashable;
    private float dashDistance;
    private float dashSpeed;
    private float dashCooldown;
    private float dashTimer;

    private Animator player_animator;
    private bool perform_attack;

    public GameObject playerAttackTrigger;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        HP_Max = 100f;
        HP_Now = HP_Max;

        moveInput = Vector2.zero;
        playerSpeed = 5.0f;
        playerAtk = 100f;

        isAttacking = false;
        attackCooldown = 0.5f;
        attackTimer = 0f;

        isDashing = false;
        dashable = true;
        dashDistance = 2f;
        dashSpeed = 10f;
        dashCooldown = 0.1f;
        dashTimer = 0f;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Debug.Log(moveInput);
        if (gameManager.status == GameManager.gameStatus.Running)
        {
            playerMove();
            playerAttack();
        }
        playerHPControl();

        if (transform.position.y <= -3f || HP_Now <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }


        // Temporary Functions
        if (Input.GetKeyDown(KeyCode.O)) HP_Now = HP_Max;
    }


    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (gameManager.status == GameManager.gameStatus.Running)
        {
            if (!isDashing)
            {
                if (ctx.performed)
                {
                    if (!perform_attack)
                    {
                        player_animator.SetBool("walk", true);
                        //perform_attack = true;
                    }
                    // player_animator.SetBool("walk", true);
                    moveInput = ctx.ReadValue<Vector2>().normalized;
                }
                else if (ctx.canceled)
                {
                    player_animator.SetBool("walk", false);
                    moveInput = Vector2.zero;
                }
            }
        }
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (gameManager.status == GameManager.gameStatus.Running)
        {
            if (ctx.performed)
            {
                if (!isAttacking)
                {
                    player_animator.SetBool("attack", true);
                    isAttacking = true;
                    attackTimer = attackCooldown;
                    HP_Now -= 5;
                    Instantiate(playerAttackTrigger, transform);
                }
            }
        }
    }

    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (gameManager.status == GameManager.gameStatus.Running)
        {
            if (ctx.performed)
            {
                if (dashable && moveInput != Vector2.zero)
                {
                    StartCoroutine(playerDash(moveInput));
                }
            }
        }
    }

    private void playerMove()
    {
        if (!isDashing)
        {
            // Debug.Log(moveInput.ToString() + " " + playerSpeed.ToString());
            rb.velocity = new Vector3(moveInput.x, 0f, moveInput.y) * playerSpeed;
            if (moveInput != Vector2.zero)
            {
                transform.localRotation = Quaternion.Euler(0f, Vector2.SignedAngle(Vector2.up, new Vector2(moveInput.x * -1, moveInput.y)), 0f);
            }
        }
    }

    private void playerAttack()
    {
        if (isAttacking)
        {
            if (attackTimer > 0)
            {
                // Attack
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                player_animator.SetBool("attack", false);
                attackTimer = 0f;
            }
        }
    }

    private IEnumerator playerDashCooldown()
    {
        while (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                dashTimer = 0f;
                dashable = true;
            }
            yield return null;
        }
    }

    private IEnumerator playerDash(Vector2 towards)
    {
        isDashing = true;
        dashable = false;
        dashTimer = dashCooldown;
        StartCoroutine(playerDashCooldown());
        rb.useGravity = false;
        Vector3 tempVec3 = transform.position;
        while ((tempVec3 - transform.position).magnitude < dashDistance)
        {
            rb.velocity = new Vector3(towards.x, 0f, towards.y) * dashSpeed;
            yield return null;
        }
        rb.velocity = Vector3.zero;
        isDashing = false;
        rb.useGravity = true;
        yield return null;
    }

    private void playerHPControl()
    {
        if (HP_Now < 0) HP_Now = 0;
        if (HP_Max == 0) HP_Max = 1;
    }
}
