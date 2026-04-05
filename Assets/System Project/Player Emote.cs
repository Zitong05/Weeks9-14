using UnityEngine;
using UnityEngine.Events;

public class PlayerEmote : MonoBehaviour
{
    public UnityEvent onEnterLight;
    public UnityEvent onExitLight;

    public SpriteRenderer Light;
    
    public bool isInLight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Light.bounds.Contains(transform.position) == true)
        {
            isInLight = true;
            onEnterLight.Invoke();
        }
        else
        {
            isInLight = false;
            onExitLight.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Light.bounds.Contains(transform.position) == true)
        {
            if(isInLight ==true)
            {
                
            }
            else
            {
                isInLight = true;
                onEnterLight.Invoke();
            }
        }
        else
        {
            if (isInLight == true)
            {
                isInLight = false;
                onExitLight.Invoke();
            }
            else
            {
                
            }
        }
    }
}
