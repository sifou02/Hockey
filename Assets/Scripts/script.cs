﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(0);
            }
    }
}
