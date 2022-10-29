using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTrigger : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI movimiento;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Trigger") movimiento.text = "Utiliza A y D para moverte";
    }


}
