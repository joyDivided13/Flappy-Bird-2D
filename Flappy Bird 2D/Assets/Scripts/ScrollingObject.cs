/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
	private Rigidbody2D _rb2d;
	void Start ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
	}
	
	void Update () 
	{
		if(GameControl.instance.gameOver == true)
		{
			_rb2d.velocity = Vector2.zero; //stopping the scrolling once the game is over
		}
	}
}
