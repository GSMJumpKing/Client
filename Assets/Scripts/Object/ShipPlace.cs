using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlace : MonoBehaviour
{

    public GameObject coll;
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 3;
            coll.SetActive(false);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 1;
            coll.SetActive(true);
        }
    }
}
