using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMechanic : MonoBehaviour
{
    private GameObject[] Type1Platforms, Type2Platforms;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Leyendo plataformas");

        Type1Platforms = GameObject.FindGameObjectsWithTag("T1Platform");
        Debug.Log("Plataformas 1: "+Type1Platforms.GetLength(0));
        
        Type2Platforms = GameObject.FindGameObjectsWithTag("T2Platform");
        Debug.Log("Plataformas 2: "+Type2Platforms.GetLength(0));

        Debug.Log("Platformas leidas");

        foreach (GameObject go in Type2Platforms)
        {
            var col = go.GetComponent<Renderer>().material.color;
            if (col.a == 0.5f) col.a = 1;
            else if (col.a == 1) col.a = 0.5f;
            go.GetComponent<Renderer>().material.color = col;
            go.GetComponent<BoxCollider2D>().enabled = !go.GetComponent<BoxCollider2D>().isActiveAndEnabled;

        }
        Debug.Log("Plataformas 2 cambiadas");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Swap"))
        {
            SwapMech();
        }
    }

    private void SwapMech()
    {
        Debug.Log("Plataformas cambiadas");
        foreach (GameObject go in Type1Platforms)
        {
            var col = go.GetComponent<Renderer>().material.color;
            if (col.a == 0.5f) col.a = 1;
            else if(col.a == 1)col.a = 0.5f;
            go.GetComponent<Renderer>().material.color = col;
            go.GetComponent<BoxCollider2D>().enabled = !go.GetComponent<BoxCollider2D>().isActiveAndEnabled;
        }
        foreach (GameObject go in Type2Platforms)
        {
            var col = go.GetComponent<Renderer>().material.color;
            if (col.a == 0.5f) col.a = 1;
            else if (col.a == 1) col.a = 0.5f;
            go.GetComponent<Renderer>().material.color = col;
            go.GetComponent<BoxCollider2D>().enabled = !go.GetComponent<BoxCollider2D>().isActiveAndEnabled;
        }

    }
}
