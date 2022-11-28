using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    BoxCollider2D boxCollider;

    [SerializeField] private float speed = 1;
    [SerializeField] private LayerMask playerLayerMask;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckVerticalRay())
        {
            MoveObjectDown();
        }
    }
    private void MoveObjectDown()
    {
        transform.position -= new Vector3(0f,speed * Time.deltaTime, 0f);
    }
    private void CheckHit()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") ||
            collision.gameObject.layer.Equals("Platform"))
        {
            Destroy(gameObject);
        }
    }
    private bool CheckVerticalRay()
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(boxCollider.bounds.center.x,
            boxCollider.bounds.center.y - boxCollider.bounds.size.y),
            boxCollider.bounds.size, 0f,
            Vector2.down, Mathf.Infinity);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

        Debug.Log(hit.collider.name);
        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log(hit.collider.gameObject.name);
            return true;
        }
        else return false;
    }
}
