using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwapMechanic : MonoBehaviour
{
    private GameObject[] Type1Platforms, Type2Platforms;

    [SerializeField]
    private Transform playerTransform;
    [SerializeField] private InputActionReference swap;
    [SerializeField]
    private LayerMask platformLayer;

    //private BoxCollider2D boxCollider;
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
            go.GetComponent<BoxCollider2D>().isTrigger = !go.GetComponent<BoxCollider2D>().isTrigger;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (swap.action.triggered)
        {
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
            foreach (GameObject go in Type1Platforms)
            {
                var col = go.GetComponent<Renderer>().material.color;
                if (col.a == 0.5f) col.a = 1;
                else if (col.a == 1) col.a = 0.5f;
                go.GetComponent<Renderer>().material.color = col;
                go.GetComponent<BoxCollider2D>().isTrigger = !go.GetComponent<BoxCollider2D>().isTrigger;
            }
            foreach (GameObject go in Type2Platforms)
            {
                var col = go.GetComponent<Renderer>().material.color;
                if (col.a == 0.5f) col.a = 1;
                else if (col.a == 1) col.a = 0.5f;
                go.GetComponent<Renderer>().material.color = col;
                go.GetComponent<BoxCollider2D>().isTrigger = !go.GetComponent<BoxCollider2D>().isTrigger;
            }
        }
        

    }
}
