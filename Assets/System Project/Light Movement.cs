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
            speed = Random.insideUnitCircle.normalized * 5f;
            Timer = 0f;
        }

        
        Vector2 newPosition = transform.position;
        newPosition += speed * Time.deltaTime;
        transform.position = newPosition;


        //Stay within screen
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0)
        {
            screenPos.x = 0;
            speed.x *= -1;
        }
        else if (screenPos.x > Screen.width)
        {
            screenPos.x = Screen.width;
            speed.x *= -1;
        }

        if (screenPos.y < 0)
        {
            screenPos.y = 0;
            speed.y *= -1;
        }
        else if (screenPos.y > Screen.height)
        {
            screenPos.y = Screen.height;
            speed.y *= -1;
        }

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
}
