using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.Events;

public class ColorSprites : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;

    [SerializeField]
    private int spriteElegido;
    private SpriteRenderer spriteRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
            spriteRenderer = GetComponent<SpriteRenderer>();

        SwapMechanic.instance.SwapColor += SwapSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwapSprite()
    {
        try
        {
            if (sprites.Length > 0)
            {
                if (spriteElegido >= sprites.Length - 1)
                {
                    spriteElegido = 0;
                }
                else
                {
                    spriteElegido++;
                }
                spriteRenderer.sprite = sprites[spriteElegido];
            }
        }
        catch
        {
            Debug.Log("El objeto no existe");
        }
    }
}
