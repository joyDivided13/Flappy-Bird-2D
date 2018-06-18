/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static GameControl instance; //for a singleton pattern
	public GameObject gameOverText;
	public float scrollSpeed = -1.5f;
	public bool gameOver = false;
	private int _score;
	public Text scoreText;

	void Awake ()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Update()
	{
		if(gameOver == true && Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reloading the scene
		}
	}

	public void BirdScored()
	{
		if(gameOver)
		{
			return;
		}

		_score++;
		scoreText.text = "Score: " + _score.ToString();
	}

	public void BirdDied()
	{
		gameOverText.SetActive(true);
		gameOver = true;
	}
}
