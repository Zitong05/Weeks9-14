using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMutiplayerController : MonoBehaviour
{
    public LocallMultiplayerManager manager;
    public PlayerInput playerInput;
    public Vector2 movementInput;
    public float speed = 5f;
    public AnimationCurve attackCurve;

    Coroutine AttackCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (AttackCoroutine != null)
            {
                StopCoroutine(AttackCoroutine);
            }
            AttackCoroutine = StartCoroutine(Growing());

            Debug.Log("Player" + playerInput.playerIndex + ": Attacking!");
            manager.playerAttacking(playerInput);
        }     
    }

    IEnumerator Growing()
    {
        yield return AttackCoroutine = StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            
            float curveValue = attackCurve.Evaluate(t);
            transform.localScale = Vector3.one * curveValue;
            yield return null;
        }
    }
}
