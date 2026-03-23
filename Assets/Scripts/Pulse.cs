using UnityEngine;

public class Pulse : MonoBehaviour
{
    public AnimationCurve pluse;
    float t;
    float speed = 3.0f;
    public TrailRenderer trailRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        t += Time.deltaTime;
        Vector2 newPosition = transform.position;
        newPosition.x += speed * Time.deltaTime;
        newPosition.y = pluse.Evaluate(t);//%1
        transform.position = newPosition;

        Vector2 left = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x > Screen.width)
        {
            trailRenderer.Clear();
            transform.position = new Vector2(left.x, 0);
            t = 0;
            trailRenderer.Clear();

        }
    }
}
