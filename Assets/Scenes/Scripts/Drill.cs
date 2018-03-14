using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : MonoBehaviour
{
    public static Drill drill;

    public bool makeBig = false;
    public bool makeSmall = false;
    float timer = 0;
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

    private void Update()
    {
        timer += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (makeBig)
        {
            this.transform.localScale = originalScale * scale;
            makeBig = false;
            makeSmall = true;
            timer = 0;
        }
        

        if (collision.transform.tag.Equals("Block"))
        {
            Destroy(collision.gameObject);
        }
        if (makeSmall&&timer>0.3f)
        {
            this.transform.localScale = originalScale;
            makeSmall = false;
        }


    }
    
}
