using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VariableSnapshot
{
    public float time;
    public float vol,freq;

    public VariableSnapshot(float time, float vol,float freq)
    {
        this.time = time;
        this.vol = vol;
        this.freq = freq;
    }
}

