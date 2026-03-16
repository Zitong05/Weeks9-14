using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GrowUp : MonoBehaviour
{
    public Transform tree;
    public Transform apple;

    Coroutine growingCoroutine;
    Coroutine treeCoroutine;
    Coroutine appleCoroutine;

    void Start()
    {
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;
    }

    

    public void StartTreeGrowing()
    {
        if(growingCoroutine != null)
        {
            StopCoroutine(growingCoroutine);
        }

        if(treeCoroutine != null)
        {
            StopCoroutine(treeCoroutine);
        }

        if (appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }

        growingCoroutine = StartCoroutine(Growing());
    }

    IEnumerator Growing()
    {
        yield return treeCoroutine = StartCoroutine(GrowTree());
        yield return appleCoroutine = StartCoroutine(GrowApple());
    }

    IEnumerator GrowTree()
    {
        Debug.Log("starting to grow the tree");
        float t = 0;
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;
        
        while (t<1)
        {
            t += Time.deltaTime;
            tree.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished growing the tree");
    }

    IEnumerator GrowApple()
    {
        Debug.Log("starting to grow the apple");
        float t = 0;
        apple.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            apple.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("Finished growing the apple");
    }
}
