/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
	private BoxCollider2D _groundCollider;
	private float _groundHorizontalLength;

	void Start ()
	{
		_groundCollider = GetComponent<BoxCollider2D>();
		_groundHorizontalLength = _groundCollider.size.x;
	}
	
	void Update () 
	{
		if(transform.position.x <= -_groundHorizontalLength)
		{
			RepositionBackground();
		}
	}

	private void RepositionBackground()
	{
		Vector2 groundOffset = new Vector2(_groundHorizontalLength * 2f, 0);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
