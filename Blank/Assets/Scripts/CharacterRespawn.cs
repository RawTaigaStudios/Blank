using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterRespawn : MonoBehaviour
{
    private GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log(collision.name);
            Debug.Log("Has recibido daño");
            StartCoroutine(DeathWait(collision.gameObject));
        }
    }
    private void RespawnCharacter()
    {
        
    }
    private IEnumerator DeathWait(GameObject character)
    {
        character.SetActive(false);
        Debug.Log("Iniciando DeathTimer");
        
        yield return new WaitForSeconds(2f);
        character.SetActive(true);
        character.transform.position = spawner.transform.position;
        character.transform.rotation = spawner.transform.rotation;
        Debug.Log("Reapareciendo");
        
    }
}
