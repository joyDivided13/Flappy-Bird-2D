/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]		//unity cannot reference a class unless it is marked as serializables
public class Sound		//the sound class yhat stores data of the sounds
{
	public string name;
	public AudioClip clip;
	public bool loop;
	[Range(0f, 1f)]
	public float volume;
	[Range(.1f, .3f)]
	[HideInInspector]
	public AudioSource source;
}
