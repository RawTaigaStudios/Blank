using System.Collections;
using System.Collections.Generic;
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
            
        }
    }
    private void MoveObjectDown()
    {
        transform.position -= new Vector3(0f,speed * Time.deltaTime, 0f);
    }
    private void CheckHit()
    {
        
    }
    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
    private bool CheckVerticalRay()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center, boxCollider.bounds.size, 0f,
            Vector2.down, 100f, playerLayerMask);
        if (hit)
        {
            return true;
        }
        else return false;
    }
}
