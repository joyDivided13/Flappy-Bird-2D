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
	public GameObject topScoreText;
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

	void Start()
	{
		Text dummyText = topScoreText.GetComponent<Text>();
		dummyText.text = PlayerPrefs.GetInt("TopScore", 0).ToString();
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

	public void topScore()
	{
		if(_score > PlayerPrefs.GetInt("TopScore", 0))
		{
			PlayerPrefs.SetInt("TopScore", _score);
			Text dummyText = topScoreText.GetComponent<Text>();
			dummyText.text = "Top Score: " + _score.ToString();
			topScoreText.SetActive(true);
		}
		else
		{
			Text dummyText = topScoreText.GetComponent<Text>();
			dummyText.text = "Top Score: " + PlayerPrefs.GetInt("TopScore").ToString();
			topScoreText.SetActive(true);
		}
	}

	public void BirdDied()
	{
		gameOverText.SetActive(true);
		gameOver = true;
		
		topScore();
	}
}
