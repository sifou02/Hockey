using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winner : MonoBehaviour
{
    Score score;
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Game").GetComponent<Score>();
        if (score.winner == 1)
        {
            GetComponent<Text>().text = "You Win";
        }
        else
        {
            GetComponent<Text>().text = "You Lose";
        }
        Destroy(GameObject.FindGameObjectWithTag("Game"));
    }
}
