using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    float t, t1, t2, Delta, C, D, E, vbx, vby, cx, cy, vx, vy, x, y;

    [SerializeField]
    GameObject ball;

    bool once, center, noway, defending, defendingonce,ud;
    void Start()
    {
        once = true;
        center = false;
    }
    void FixedUpdate()
    {

        if (((ball.GetComponent<Rigidbody2D>().velocity.y > -2f && ball.transform.position.y > -3f) || ball.transform.position.y >= -0.25f))
        {
            if (once)
            {
                Hit();
                vbx = ball.GetComponent<Rigidbody2D>().velocity.x;
                vby = ball.GetComponent<Rigidbody2D>().velocity.y;
                once = false;
            }
        }

        if (vbx != ball.GetComponent<Rigidbody2D>().velocity.x || vby != ball.GetComponent<Rigidbody2D>().velocity.y)
        {
            once = true;
        }
        if (center)
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(0, 3)) <= 0.1f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                center = false;
            }
        }
        if (ball.transform.position.y + 3f < transform.position.y || !ud)
        {
            if (defending)
            {
                returntocenter();
                center = true;
                defending = false;
            }
        }
        if (ball.transform.position.y > transform.position.y - 0.5f)
        {
            if (!defending)
                noway = true;
        }
        if (noway)
        {
            defending = true;
            if (ball.transform.position.x > 0)
                defend(true);
            else
                defend(false);
            noway = false;
            defendingonce = true;
        }
        if (defending && defendingonce)
        {
            if (Vector2.Distance(new Vector2(0, transform.position.y), new Vector2(0, 3.5f)) <= 0.1f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                defendingonce = false;
            }

        }
        if (transform.position.x > 1.735f) { transform.position = new Vector3(1.735f, transform.position.y, transform.position.z); }
        if (transform.position.x < -1.735f) { transform.position = new Vector3(-1.735f, transform.position.y, transform.position.z); }
        if (transform.position.y < 0.4f) { transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z); }
        if (transform.position.y > 3.735f) { transform.position = new Vector3(transform.position.x, 3.735f, transform.position.z); }
    }
    void Hit()
    {

        vbx = ball.GetComponent<Rigidbody2D>().velocity.x;
        vby = ball.GetComponent<Rigidbody2D>().velocity.y;
        if (vbx < 0)
        {
            cx = ball.transform.position.x - transform.position.x - 0.25f;
            cy = ball.transform.position.y - transform.position.y + 0.25f;
        }
        else
        {
            cx = ball.transform.position.x - transform.position.x + 0.25f;
            cy = ball.transform.position.y - transform.position.y + 0.25f;
        }
        C = vbx * vbx + vby * vby - 25;
        D = 2 * ((vbx * cx) + (vby * cy));
        E = cx * cx + cy * cy;
        Delta = D * D - 4 * E * C;
        if (Delta > 0)
        {
            ud = false;
            t1 = (-D - Mathf.Sqrt(Delta)) / (2 * C);
            t2 = (-D + Mathf.Sqrt(Delta)) / (2 * C);
            if (t1 > 0)
            {
                vx = vbx + (cx / t1);
                vy = vby + (cy / t1);
                GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
            }
            if (t2 > 0)
            {
                vx = vbx + (cx / t1);
                vy = vby + (cy / t1);
                GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
            }
        }
        else if (Delta == 0)
        {
            ud = false;
            Debug.Log("Not Error");
            t1 = -(D * D) / (2 * C);
            vx = (vbx * t1 + cx) / t1;
            vy = (vby * t1 + cy) / t1;
            GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
        }
        else
        {
            ud = true;
        }
    }
    void returntocenter()
    {
        x = transform.position.x;
        y = transform.position.y;
        t = Mathf.Sqrt(((x * x) + (3 - y) * (3 - y)) / 25);
        vx = -x / t;

        vy = (3 - y) / t;

        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
    void defend(bool right)
    {
        x = transform.position.x;
        y = transform.position.y;
        if (right)
        {
            t = Mathf.Sqrt(((0.95f - x) * (0.95f - x) + (3.5f - y) * (3.7f - y)) / 28);
            vx = (0.95f - x) / t;
            vy = (3.7f - y) / t;
        }
        else
        {
            t = Mathf.Sqrt(((-0.75f - x) * (-0.75f - x) + (3.5f - y) * (3.7f - y)) / 28);
            vx = (-0.75f - x) / t;
            vy = (3.7f - y) / t;

        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            if (ball.GetComponent<Rigidbody2D>().velocity.y < 2f)
            {
                returntocenter();
                center = true;

            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            returntocenter();
            center = true;
        }
    }
}