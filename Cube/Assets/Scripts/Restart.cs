﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
        	// initialize score and player
        	PlayerScore.playerScore = 0;
        	GameOver.isPlayerDead = false;
        	Time.timeScale = 1;

        	// load scene named Scene_001
        	SceneManager.LoadScene("Scene_001");
        }        
    }
}
