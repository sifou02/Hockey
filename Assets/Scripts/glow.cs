using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glow : MonoBehaviour
{
    float alpha,t;
    bool fading;
    Material material;
    void Start()
    {
        
        fading = false;
        material = GetComponent<SpriteRenderer>().material;
        alpha = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        material.color = new Color(material.color.r, material.color.g, material.color.b ,alpha);
        if (fading && Time.time - t >= 0.2f)
        {
            fading = false;
            alpha = 0.6f;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D ball)
    {
        alpha = 1.0f;
    }
    private void OnTriggerExit2D(Collider2D ball)
    {
        fading = true;
        t = Time.time;
    }
}
