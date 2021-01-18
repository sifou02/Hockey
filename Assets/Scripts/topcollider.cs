using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topcollider : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ball")
        {
            if (other.collider.GetComponent<Rigidbody2D>().velocity.y < 0.1f)
            {
                other.collider.GetComponent<Rigidbody2D>().velocity += new Vector2(0f, -0.8f);
            }
        }
    }
}
