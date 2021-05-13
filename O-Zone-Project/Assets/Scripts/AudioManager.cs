using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private static AudioClip Sound;

    private static AudioSource AudioSFX;
    private static AudioSource Ambience;

    // Start is called before the first frame update
    void Awake()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        AudioSFX = sources[0];
        Ambience = sources[1];

        Ambience.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string soundName)
    {
        Sound = Resources.Load<AudioClip>("Sounds/" + soundName);
        AudioSFX.PlayOneShot(Sound);
    }
}
