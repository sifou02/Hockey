using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Ray ray;
    float mx, my;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            mx = ray.GetPoint(0).x;
            my = ray.GetPoint(0).y;           
            if (mx > 1.735f) { mx = 1.735f; }
            if (mx < -1.735f) { mx = -1.735f; }
            if (my > -0.4) { my = -0.4f; }
            if (my < -3.735f) { my = -3.735f; }
            rb.MovePosition(new Vector3(mx, my, 0));        
        
    }
}
