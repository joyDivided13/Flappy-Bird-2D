/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
	public static GameControl instance; //for a singleton pattern
	public GameObject gameOverText;
	public bool gameOver = false;
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

	public void BirdDied()
	{
		gameOverText.SetActive(true);
		gameOver = true;
	}
}
