using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Animator animator;

    
    public float dashSpeed = 10f;
    public float dashDuration = 0.25f;

    private bool isDashing = false;
    private int facingDirection = 1; // left = -1, right = 1

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Player movement
        if (!isDashing)
        {
            transform.position += (Vector3)movement * speed * Time.deltaTime;
        }

        //animator
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        //sprite flipping
        Vector3 scale = transform.localScale;

        if (movement.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            facingDirection = 1;
        }
        else if (movement.x < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
            facingDirection = -1;
        }

        transform.localScale = scale;
    }

    //Movement input
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    //Dash input
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && !isDashing)
        {
            StartCoroutine(DashCoroutine());
        }
    }

    //Dash
    private IEnumerator DashCoroutine()
    {
        isDashing = true;
        animator.SetBool("IsDashing", true);

        float dashDirection;

        //Dash direction
        if (Mathf.Abs(movement.x) > 0.1f)
        {
            dashDirection = Mathf.Sign(movement.x);
        }
        else
        {
            dashDirection = facingDirection;
        }

        float timer = 0f;

        while (timer < dashDuration)
        {
            transform.position += new Vector3(dashDirection, 0f, 0f) * dashSpeed * Time.deltaTime;

            timer += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("IsDashing", false);
        isDashing = false;
    }
}