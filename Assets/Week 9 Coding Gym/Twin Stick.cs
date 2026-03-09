using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TwinStick : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movemnet;
    public Vector3 look;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movemnet * speed * Time.deltaTime;
        
        look = transform.eulerAngles;
        transform.eulerAngles = look;

        //transform.position = movemnet;
    }

    //public void OnPoint(InputAction.CallbackContext context)
    //{
    //    //this is the asme as Mouse.current.position.ReadValue()
    //    movemnet = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    //}

    public void OnMove(InputAction.CallbackContext context)
    {
        movemnet = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look.z = context.ReadValue<float>();
    }

}
