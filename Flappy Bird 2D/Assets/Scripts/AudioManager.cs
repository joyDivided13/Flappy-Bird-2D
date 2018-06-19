/*
Copyright (c) Shubham Saudolla
https://github.com/joyDivided13
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;		//the array that holds all the different sounds
	public static AudioManager instance;

	void Awake()
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

	void Start ()
	{
		foreach(Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.volume = s.volume;
		}
	}
	
	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sounds => sounds.name == name); //needs the System namespace
		s.source.Play();
	}
}
