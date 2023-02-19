using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
		}
	}

	void Start()
	{
		Play("theme");    //Igra na pocetok na scenata
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null) return;

		s.source.volume = s.volume;
		s.source.Play();
	}
	public void Stop(string sound)
    {
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null) return;

		s.source.volume = 0;
		s.source.Stop();
    }

	public void Music(bool play)
	{
		Sound[] music = { Array.Find(sounds, item => item.name == "theme"),
                          Array.Find(sounds, item => item.name == "shop"),
                          Array.Find(sounds, item => item.name == "boat") };

		foreach (Sound s in music)
		{
			if (s == null) continue;
			if (play)
			{
				s.source.mute = false;
			}
			else
			{
				s.source.mute = true;
			}
		}
	}
}
