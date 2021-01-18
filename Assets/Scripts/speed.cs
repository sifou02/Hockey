using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.magnitude > 13)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 13;
        }

    }
}
