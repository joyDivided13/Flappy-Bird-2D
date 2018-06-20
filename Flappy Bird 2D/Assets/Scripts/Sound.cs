/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
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
	[HideInInspector]
	public AudioSource source;
}
