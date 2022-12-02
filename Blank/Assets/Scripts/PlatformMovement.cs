using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    GameObject plataforma;

    [SerializeField]
    Transform puntoIni, puntoFin;

    [SerializeField]
    float velocidad;

    private Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        direccion = puntoFin.position;
    }

    // Update is called once per frame
    void Update()
    {
        plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position, direccion, velocidad * Time.deltaTime);
        
        if (plataforma.transform.position == puntoFin.position)
        {
            direccion = puntoIni.position;
        }
        if (plataforma.transform.position == puntoIni.position)
        {
            direccion = puntoFin.position;
        }
    }

    
}
