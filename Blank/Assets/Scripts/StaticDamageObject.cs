using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class StaticDamageObject : MonoBehaviour
{

    [SerializeField] private Sprite[] sprites;
    
    [SerializeField] private int spriteElegido;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[spriteElegido];
    }
    private void OnValidate()
    {
        if(spriteElegido > sprites.Length - 1)
        {
            spriteElegido = sprites.Length - 1;
        }
        if(spriteElegido < 0)
        {
            spriteElegido = 0;
        }
    }

}
