using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlace : MonoBehaviour
{

    bool isPlayer;
    GameObject player;


    private void Update()
    {
        Debug.Log(isPlayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        isPlayer = true;
        player = collision.gameObject;
        StartCoroutine(Wind());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;

    }
    IEnumerator Wind()
    {
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        float time;
        while (isPlayer)
        {
            yield return new WaitForSeconds(2f);

            time = Time.time + 1;
            while (time >= Time.time)
            {
                if (!isPlayer)
                    break;
                rigid.velocity = new Vector2(rigid.velocity.x - 1, rigid.velocity.y);
                yield return new WaitForSeconds(0.1f);
            }



        }
    }

    
}
