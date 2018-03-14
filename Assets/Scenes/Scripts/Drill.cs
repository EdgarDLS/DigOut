using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public static Drill drill;

    public bool makeBig = false;
    public bool makeSmall = false;

    Vector3 originalScale;
    public float scale;

    private void Awake()
    {
        if (drill != null)
            GameObject.Destroy(drill);
        else
            drill = this;
    }

    private void Start()
    {
        originalScale = this.transform.localScale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (makeBig)
        {
            this.transform.localScale = originalScale *scale;
            makeBig = false;
        }
        if (makeSmall)
        {
            this.transform.localScale = originalScale * scale;
            makeSmall = false;
        }
        if (collision.transform.tag.Equals("Block"))
        {
            Destroy(collision.gameObject);
        }

    }
    
}
