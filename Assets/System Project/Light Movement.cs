using UnityEngine;

public class LightMovement : MonoBehaviour
{
    Vector2 speed;

    public float Timer = 0f;
    public float changeInterval = 2;

    void Start()
    {
        speed = Random.insideUnitCircle.normalized * 5f;
    }

    void Update()
    {
        //change direction
        Timer += Time.deltaTime;

        if (Timer >= changeInterval)
        {
            float currentSpeed = speed.magnitude;
            speed = Random.insideUnitCircle.normalized * currentSpeed;
            Timer = 0f;
        }

        
        Vector2 newPosition = transform.position;
        newPosition += speed * Time.deltaTime;
        transform.position = newPosition;

        //Stay within screen
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            speed.x *= -1;
        }

        if (screenPos.y < 0 || screenPos.y > Screen.height)
        {
            speed.y *= -1;
        }
    }
}
