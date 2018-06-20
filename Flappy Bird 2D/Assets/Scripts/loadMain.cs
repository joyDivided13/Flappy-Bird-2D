/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMain : MonoBehaviour
{	
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			SceneManager.LoadScene(1);
		}
	}
}
