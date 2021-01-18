using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDestroy : MonoBehaviour
{
    void Start()
    {
        GameObject[] games = GameObject.FindGameObjectsWithTag("Game");

        if (games.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
