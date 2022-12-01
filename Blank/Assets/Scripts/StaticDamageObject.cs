using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticDamageObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] sprites;
    [SerializeField] private const int sp = 2;
    [Range(0, sp)] private int spriteElegido;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
