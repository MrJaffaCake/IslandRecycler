using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;

	public AudioClip clip;

	[Range(0f, 2f)]
	public float volume = 2f;

	public bool loop = false;

	[HideInInspector]
	public AudioSource source;

}
