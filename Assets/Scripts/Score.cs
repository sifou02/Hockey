using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int P1score, P2score;
    public int winner;
    [SerializeField]


    
    void Update()
    {
        if (P1score == 8)
        {   
            winner = 1;
            SceneManager.LoadScene(2);
            
        }
        else if (P2score == 8)
        {   
            winner = 2;
            SceneManager.LoadScene(2);
            
        }
        else
        {
            GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0].text = P2score.ToString();
            GameObject.Find("Canvas").GetComponentsInChildren<Text>()[1].text = P1score.ToString();
        }
    }
    public void goal(int player)
    {
        if (player == 1)
        {
            P1score += 1;
        }
        if (player == 2)
        {
            P2score += 1;
        }
    }
}
