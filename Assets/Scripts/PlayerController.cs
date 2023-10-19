using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rb;

    private float HP_Max;
    private float HP_Now;

    private Vector2 moveInput;
    private float playerSpeed;

    private bool isAttacking;
    private float attackCooldown;
    private float attackTimer;

    private bool isDashing;
    private bool dashable;
    private float dashDistance;
    private float dashCooldown;
    private float dashTimer;
    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();

        HP_Max = 100f;
        HP_Now = HP_Max;

        playerSpeed = 10.0f;

        isAttacking = false;
        attackCooldown = 0.5f;
        attackTimer = 0f;

        isDashing = false;
        dashable = true;
        dashDistance = 2f;
        dashCooldown = 3f;
        dashTimer = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.status == GameManager.gameStatus.Running)
        {
            playerMove();
            playerAttack();
            playerDashCooldown();
        }


        // Temporary Functions
        if (isAttacking)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else GetComponent<MeshRenderer>().material.color = Color.white;
    }

    

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (gameManager.status == GameManager.gameStatus.Running)
        {
            if (ctx.performed)
            {
                moveInput = ctx.ReadValue<Vector2>();
            }
            else if(ctx.canceled)
            {
                moveInput = Vector2.zero;
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
                    isAttacking = true;
                    attackTimer = attackCooldown;
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
                if (dashable)
                {
                    StartCoroutine(playerDash());
                    isDashing = true;
                    dashTimer = dashCooldown;
                }
            }
        }
    }

    private void playerMove()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector3(moveInput.x, 0f, moveInput.y) * playerSpeed;

            if (moveInput != Vector2.zero)
            {
                transform.rotation = new Quaternion(moveInput.x, 0f, moveInput.y, 0f);
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
                attackTimer = 0f;
            }
        }
    }

    private void playerDashCooldown()
    {
        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                dashTimer = 0f;
                dashable = true;
            }
        }
    }

    private IEnumerator playerDash()
    {
        dashable = false;
        dashTimer = dashCooldown;
        float counter = dashDistance;
        while (counter > 0)
        {
            Vector3 tempVec3 = transform.position;
            transform.Translate(transform.forward);
            float deltaDistance = (tempVec3 - transform.position).magnitude;
            counter -= deltaDistance;
            yield return null;
        }
        isDashing = false;
        yield return null;
    }
}
