﻿/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	private bool _isDead = false;
	private Rigidbody2D _rb2d;
	private Animator _anim;
	
	public float upForce = 200f;
	public CameraShake cameraShake; //object of the public class CameraShake
	
	void Start ()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_anim = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(_isDead == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				_rb2d.velocity = Vector2.zero; //removing any existing velocity, cartoon physics
				_rb2d.AddForce(new Vector2(0, upForce));
				_anim.SetTrigger("Flap");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) //spelling matters
	{
		_rb2d.velocity = Vector2.zero;
		StartCoroutine(cameraShake.Shake(.15f, .14f)); //calling the coroutine
		bool hasHitGround = false;

		if(col.collider.tag == "Ground" && !hasHitGround)
		{
			AudioManager.instance.Play("hitGround");
			hasHitGround = true;
		}
		else if(col.collider.tag == "Columns" && !hasHitGround)
		{
			AudioManager.instance.Play("hitColumn");
		}

		_isDead = true;
		_anim.SetTrigger("Die");
		GameControl.instance.BirdDied();
		//AudioManager.instance.Play("youSuck");
	}
}
