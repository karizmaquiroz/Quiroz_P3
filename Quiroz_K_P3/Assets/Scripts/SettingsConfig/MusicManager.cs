using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> SongList = new List<AudioClip>();
    public float bgVolume = 1.00f;
    public int curSong = 0;
    public int ranMin, ranMax;
    public bool PlayRandomly = false;
    public float pitch = 1f;
    public float StereoPan;
    public AudioSource audio;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        //GetComponent<AudioSource>().volume = bgVolume;
        //GetComponent<AudioSource>().pitch = pitch;
        audio.volume = bgVolume;
        audio.pitch = pitch;

        ranMax = SongList.Count;
        curSong = -1;
    }

    void Update()
    {
        if (PlayRandomly)
            PlayRandom();
        else
            Playlist();

        //GetComponent<AudioSource>().volume = bgVolume;
        //GetComponent<AudioSource> ().pitch = pitch;
        //GetComponent<AudioSource> ().panStereo = StereoPan;

        audio.volume = bgVolume;
        audio.pitch = pitch;
        audio.panStereo = StereoPan;
    }

    void PlayRandom()
    {
        //if(!GetComponent<AudioSource>().isPlaying)
        if (!audio.isPlaying)
        {
            //GetComponent<AudioSource>().clip = SongList[Random.Range(ranMin, ranMax)];
            //GetComponent<AudioSource>().Play();
            audio.clip = SongList[Random.Range(ranMin, ranMax)];
            audio.Play();
        }
    }

    void Playlist()
    {
        //	if(!GetComponent<AudioSource>().isPlaying)
        if (!audio.isPlaying)
        {
            if (curSong >= SongList.Capacity)
            {
                curSong = SongList.Capacity - 1;
            }
            else
            {
                curSong++;
            }
            audio.clip = SongList[curSong];
            audio.Play();
        }
    }

    void PlayRepeat(AudioClip Song)
    {
        //GetComponent<AudioSource>().clip = Song;
        //GetComponent<AudioSource>().loop = true;
        //GetComponent<AudioSource>().Play();
        audio.clip = Song;
        audio.loop = true;
        audio.Play();
    }
}
