﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToTheMenu()
    {
        SceneManager.LoadScene(0); 
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene(4); 
    }
}
