using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharacterRespawn : MonoBehaviour
{
    [SerializeField]private GameObject charSpawner;
    private SpriteRenderer sprite;
    private CharacterController controller;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Damage")
        {
            StartCoroutine(DeathWait());
        }
    }
    private IEnumerator DeathWait()
    {
        sprite.enabled = false;
        controller.enabled = false;
        rb.simulated = false ;
        
        yield return new WaitForSeconds(2f);

        controller.enabled = true;
        rb.simulated = true;
        sprite.enabled = true;
        Camera.main.transform.position = charSpawner.transform.position;
        gameObject.transform.position = charSpawner.transform.position;
        gameObject.transform.rotation = charSpawner.transform.rotation;
        
    }
}
