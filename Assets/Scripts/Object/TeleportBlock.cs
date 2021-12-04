using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBlock : MonoBehaviour
{

    public Vector2 targetPos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.position = targetPos;
    }
}
