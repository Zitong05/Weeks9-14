using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerInput : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movemnet;
    public AudioSource SFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += (Vector3)movemnet * speed * Time.deltaTime;
        transform.position += (Vector3)movemnet * speed * Time.deltaTime;
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //this is the asme as Mouse.current.position.ReadValue()
        movemnet = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movemnet = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack!" + context.phase);
        if (context.performed == true)
        {
            SFX.Play();
        }
    }
}
