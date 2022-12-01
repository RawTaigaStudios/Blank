using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    BoxCollider2D boxCollider;

    [SerializeField] private float speed = 1;
    [SerializeField] private LayerMask playerLayerMask;
    private int platformLayerValue = 6;

    private bool targetFound = false;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetFound)
        {
            MoveObjectDown();
        }
        else
        {
            CheckVerticalRay();
        }
    }
    private void MoveObjectDown()
    {
        transform.position -= new Vector3(0f,speed * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.layer.Equals(platformLayerValue))
        {
            Destroy(gameObject);
        }
    }
    private void CheckVerticalRay()
    {
        RaycastHit2D hit = Physics2D.BoxCast(new Vector2(boxCollider.bounds.center.x,
            boxCollider.bounds.center.y - boxCollider.bounds.size.y),
            boxCollider.bounds.size, 0f,
            Vector2.down, Mathf.Infinity, playerLayerMask);
        
        if (hit.collider != null)
        {
            targetFound = true;
        }
    }
}
