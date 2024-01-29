using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public static SE instance;
    AudioSource[] audio;

    void Awake()
    {
        instance = this;
        initialize();
    }

    void initialize()
    {
        audio = new AudioSource[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            audio[i] = transform.GetChild(i).GetComponent<AudioSource>();
        }
    }

    public void _playOneShot(int i)
    {
        audio[i].PlayOneShot(audio[i].clip);
    }

    public void _playOneShot_randamaze(int i)
    {
        float value = Random.Range(0.8f, 1.2f);
        audio[i].pitch = value;
        audio[i].PlayOneShot(audio[i].clip);
    }


}
