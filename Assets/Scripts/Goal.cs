using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    Score g;
    private void Start()
    {
        g = GameObject.FindGameObjectWithTag("Game").GetComponent<Score>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (name == "P1 goal")
        {
            g.goal(2);
        }
        if (name == "P2 goal")
        {
            g.goal(1);
        }
        SceneManager.LoadScene(1);
    }
}
