using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptableObjCreate : MonoBehaviour
{

    [SerializeField] private Conversation conver;
    [SerializeField] private string textoSuplantar;
    private string textoMostrar;
    [SerializeField] private InputActionReference action;
    // Start is called before the first frame update
    void Start()
    {
        textoMostrar = action.action.GetBindingDisplayString();
        ModificarDialogo();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ModificarDialogo()
    {
        for (int i = 0; i < conver.allLines.Length; i++)
        {
            if (conver.allLines[i].dialogue.Contains(textoSuplantar))
            {
                //conver.allLines[i].dialogue.Replace(textoSuplantar, textoMostrar);
                conver.allLines[i].dialogue += textoMostrar;
                Debug.Log(conver.allLines[i].dialogue.ToString());

            }
        }
    }
}
