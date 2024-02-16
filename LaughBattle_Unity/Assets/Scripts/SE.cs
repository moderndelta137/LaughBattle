using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public static SE instance;
    public AudioSource playerhitaudio;
    public AudioSource bullethitaudio;
    public AudioClip[] playerhitcilps;
    public AudioClip[] bullethitcilps;

    void Awake()
    {
        instance = this;
        initialize();
    }

    void initialize()
    {

    }

    public void _playPlayerAudio()
    {
        int rand = Random.Range(0, playerhitcilps.Length);
        playerhitaudio.PlayOneShot(playerhitcilps[rand]);
    }

    public void _playBulletAudio()
    {
        int rand = Random.Range(0, bullethitcilps.Length);
        bullethitaudio.PlayOneShot(bullethitcilps[rand]);
    }



}
