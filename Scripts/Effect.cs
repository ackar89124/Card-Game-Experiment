using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// might replace with a vector2Int
public struct Effect
{
    public int type, strength;

    public Effect(int t, int l)
    {
        type = t;
        strength = l;
    }
}