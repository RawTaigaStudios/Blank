using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int totalLevel = 9;
    public int maxLevel;


    public float sound;
    public float music;
    public Data()
    {
        maxLevel = 0;
        sound = Mathf.Log10(1);
        music = Mathf.Log10(1) * 20;

    }
}