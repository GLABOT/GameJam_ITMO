using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audioClip;

    [Range(0f, 1f)] public float volume = 1f;
    [Range(1f, 3f)] public float pitch = 1f;

    public bool loop = false;

    [HideInInspector]
    public AudioSource audioSource;
}