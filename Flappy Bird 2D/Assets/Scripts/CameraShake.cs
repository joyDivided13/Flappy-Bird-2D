/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

//this uses a coroutine. Need to include using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public IEnumerator Shake(float duration, float magnitude)
	{
		Vector3 originalPos = transform.localPosition; //the position must be referenced using a Vector3

		float elapsed = 0f;
		
		while(elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			transform.localPosition = new Vector3(x, y, originalPos.z);

			elapsed += Time.deltaTime;

			yield return null; //wait for the next frame to be drawn before continuing on with the while loop
		}

		transform.localPosition = originalPos;
	}
}
