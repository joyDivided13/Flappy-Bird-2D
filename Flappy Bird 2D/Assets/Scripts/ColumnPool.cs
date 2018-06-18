/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float spawnRate = 4f;
	public float columnMin = -1f;
	public float columnMax = 3.5f;
	private GameObject[] _columns;
	private Vector2 _objectPoolPosition = new Vector2(-15f, -25f);
	private float timeSinceLastSpawned;
	private float spawnXPosition = 10f;
	private int currentColumn  = 0;
	void Start ()
	{
		timeSinceLastSpawned = 0;

		_columns = new GameObject[columnPoolSize];
		for(int i = 0; i < columnPoolSize; i++)
		{
			_columns[i] = (GameObject) Instantiate(columnPrefab, _objectPoolPosition, Quaternion.identity);
		}
	}
	
	void Update () 
	{
		timeSinceLastSpawned += Time.deltaTime;

		if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
		{
			timeSinceLastSpawned = 0;

			float spawnYPosition = Random.Range(columnMin, columnMax);
			_columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
			currentColumn++;

			if(currentColumn >= columnPoolSize)
			{
				currentColumn = 0;
			}
		}
	}
}
