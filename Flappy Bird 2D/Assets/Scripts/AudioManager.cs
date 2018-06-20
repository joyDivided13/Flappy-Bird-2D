/*
Copyright (c) Shubham Saudolla
https://github.com/shubham-saudolla
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
		DontDestroyOnLoad(gameObject); //the theme does not get cut when reloading the scene

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
			s.source.loop = s.loop;
		}

		Play("theme");
	}
	
	public void Play(string name)
	{
		Sound s = Array.Find(sounds, sounds => sounds.name == name); //needs the System namespace
		if(s == null)
		{
			Debug.LogWarning("Sound " + name + "not found.");
			return;
		}
		s.source.Play();
	}
}
