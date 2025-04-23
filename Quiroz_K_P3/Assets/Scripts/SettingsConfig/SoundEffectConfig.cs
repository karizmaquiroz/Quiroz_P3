using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffectConfig : MonoBehaviour
{

    public List<AudioClip> soundList = new List<AudioClip>();
    
    public float pitch;
    public float StereoPan;
    private AudioSource source;

    public float sfxVolume = 1.00f;



    void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = sfxVolume;
    }

    void Update()
    {
        
        if (Input.GetButton("Fire1"))
        {
            source.clip = soundList[0];
            source.Play();
        }
        source.volume = sfxVolume;
    }

  
}
