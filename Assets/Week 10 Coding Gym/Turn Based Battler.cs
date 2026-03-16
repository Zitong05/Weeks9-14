using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class TurnBasedBattler : MonoBehaviour
{
    
    public AnimationCurve Curve;
    public bool onClick = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Grow ()
    {
        transform.localScale = Vector2.zero;
        float t = 0;
        if (onClick == false)
        {
            while (t < 1)
            {
                t += Time.deltaTime;

                transform.localScale = Vector2.one * Curve.Evaluate(t);
                onClick = true;
                yield return null;
            }
        }
        
        
    }

    public void Growing()
    {
        StartCoroutine(Grow());
        onClick = false;
    }
}
