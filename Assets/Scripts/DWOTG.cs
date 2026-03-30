using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class DWOTG : MonoBehaviour
{
    public Vector2 movemnet;
    public Tilemap tilemap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //this is the asme as Mouse.current.position.ReadValue()
        
        movemnet = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        transform.position = (Vector3)movemnet;
    }

}
