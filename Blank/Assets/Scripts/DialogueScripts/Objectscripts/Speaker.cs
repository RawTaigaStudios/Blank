using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="New Speaker",menuName="Dialogue/New Speaker")]
public class Speaker : ScriptableObject
{
    public string speakerName;
    //public Sprite speakerSprite;

    public string GetName()
    {
        return speakerName;
    }
    /*
    public Sprite GetSprite()
    {
        return speakerSprite;
    }*/
}
