using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SwapMechanic : MonoBehaviour
{
    public static SwapMechanic instance;

    public UnityEvent ManualSpriteSwap;
    public event Action SwapColor;

    private GameObject[] Type1Platforms, Type2Platforms;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField] private InputActionReference swap;
    [SerializeField]
    private LayerMask platformLayer;

    [SerializeField] private AudioSource skillSoundEffect;

    //private BoxCollider2D boxCollider;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //boxCollider = GetComponent<BoxCollider2D>();
        Type1Platforms = GameObject.FindGameObjectsWithTag("T1Platform");
        
        Type2Platforms = GameObject.FindGameObjectsWithTag("T2Platform");


        foreach (GameObject go in Type2Platforms)
        {
            var col = go.GetComponent<Renderer>().material.color;
            if (col.a == 0.5f) col.a = 1;
            else if (col.a == 1) col.a = 0.5f;
            go.GetComponent<Renderer>().material.color = col;
            go.GetComponent<CompositeCollider2D>().isTrigger = !go.GetComponent<CompositeCollider2D>().isTrigger;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (swap.action.triggered)
        {
            skillSoundEffect.Play();
            SwapMech();

            
        }
    }
    private bool CheckSwap()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast
                (playerTransform.position, new Vector2(1, 1), 0f,
                 Vector2.zero, Mathf.Infinity, platformLayer);
        if (raycastHit)
        {
            if (raycastHit.collider.tag == "T1Platform" ||
                raycastHit.collider.tag == "T2Platform")
            {
                
                return false;
            }
            Debug.Log(raycastHit.collider.tag);
        }
        return true;
    }
    private void SwapMech()
    {
        if (CheckSwap())
        {
            if(SwapColor != null)
            {
                SwapColor();
            }
            ManualSpriteSwap.Invoke();
            foreach (GameObject go in Type1Platforms)
            {
                var col = go.GetComponent<Renderer>().material.color;
                if (col.a == 0.5f) col.a = 1;
                else if (col.a == 1) col.a = 0.5f;
                go.GetComponent<Renderer>().material.color = col;
                go.GetComponent<CompositeCollider2D>().isTrigger = !go.GetComponent<CompositeCollider2D>().isTrigger;
            }
            foreach (GameObject go in Type2Platforms)
            {
                var col = go.GetComponent<Renderer>().material.color;
                if (col.a == 0.5f) col.a = 1;
                else if (col.a == 1) col.a = 0.5f;
                go.GetComponent<Renderer>().material.color = col;
                go.GetComponent<CompositeCollider2D>().isTrigger = !go.GetComponent<CompositeCollider2D>().isTrigger;
            }
        }
        

    }
    public void SwapGameObject(GameObject go)
    {
        try
        {
            go.GetComponent<TilemapRenderer>().enabled = !go.GetComponent<TilemapRenderer>().enabled;
        }
        catch
        {
            Debug.Log("No tilemapRenderer en " + go.name);
        }
    }
}
