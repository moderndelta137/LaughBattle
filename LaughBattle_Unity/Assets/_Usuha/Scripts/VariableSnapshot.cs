using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VariableSnapshot
{
    public float time;
    public float value;

    public VariableSnapshot(float time, float value)
    {
        this.time = time;
        this.value = value;
    }
}

