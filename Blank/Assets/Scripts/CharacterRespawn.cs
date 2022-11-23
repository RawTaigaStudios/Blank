using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterRespawn : MonoBehaviour
{
    [SerializeField]private GameObject charSpawner;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            StartCoroutine(DeathWait(collision.gameObject));
        }
    }
    private void RespawnCharacter()
    {
        
    }
    private IEnumerator DeathWait(GameObject character)
    {
        character.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        character.SetActive(true);
        character.transform.position = charSpawner.transform.position;
        character.transform.rotation = charSpawner.transform.rotation;
        
    }
}
