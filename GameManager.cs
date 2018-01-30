using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float gameTempo;
    private float currentTime = 0;
    public event Action changeDifficulty;
    public Text secondsSurvived;
    public GameObject gameOverScreen;
    private bool gameOver = false;

    // Use this for initialization
    void Start () {
        FindObjectOfType<player>().gameOver += onGameOver;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > currentTime)
        {
            changeDifficulty();
            currentTime += gameTempo;
        }
        if(gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                
                FindObjectOfType<blockSpawner>().spawnTime = 0f;  // reseting game difficulty progression
                FindObjectOfType<blockSpawner>().spawnInterval = 1f;
                FindObjectOfType<ColorChange>().changeSpeed = 1f;
                SceneManager.LoadScene(0);

            }
        }
	}

    void onGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvived.text = Time.timeSinceLevelLoad.ToString();
        gameOver = true;
    }
}
