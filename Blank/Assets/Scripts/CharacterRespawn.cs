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
        Debug.Log(collision.tag);
        if (collision.tag == "Damage")
        {
            Debug.Log("colision");
            StartCoroutine(DeathWait());
        }
    }
    private IEnumerator DeathWait()
    {
        sprite.enabled = false;
        controller.enabled = false;
        rb.Sleep();
        yield return new WaitForSeconds(2f);
        Debug.Log("Han pasado 2 sec");
        controller.enabled = true;
        rb.WakeUp();
        sprite.enabled = true;
        GetComponentInParent<Transform>().position = charSpawner.transform.position;
        GetComponentInParent<Transform>().rotation = charSpawner.transform.rotation;
        
    }
}
