using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindPlace : MonoBehaviour
{

    public enum Dir
    {
        Left,
        Right,
    }

    public Dir dir;
    bool isPlayer;
    GameObject player;
    public SpriteRenderer[] wind;
    bool isstart;

    private void Start()
    {
        wind = GetComponentsInChildren<SpriteRenderer>();


        foreach (var item in wind)
        {
            item.flipX = (dir == Dir.Left) ? true : false;
        }
    }   
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        isPlayer = true;
        player = collision.gameObject;
        if(!isstart)
            StartCoroutine(Wind());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayer = false;

    }
    IEnumerator Wind()
    {
        isstart = true;
        Rigidbody2D rigid = player.GetComponent<Rigidbody2D>();
        float time;
        while (true)
        {

            foreach (var item in wind)
            {
                item.enabled = false;
            }

            yield return new WaitForSeconds(2f);


            time = Time.time + 1;
            while (time >= Time.time)
            {
                foreach (var item in wind)
                {
                    item.enabled = true;
                }
                if (!isPlayer)
                    break;

                if (isPlayer)
                {
                    if (dir == Dir.Left)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x - 1, rigid.velocity.y);
                    }
                    else if (dir == Dir.Right)
                    {
                        rigid.velocity = new Vector2(rigid.velocity.x + 1, rigid.velocity.y);

                    }
                    yield return new WaitForSeconds(0.1f);
                }
            }

            


        }
    }

    
}
