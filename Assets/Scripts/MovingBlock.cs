using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{

    Vector2 originPos;
    public Vector2 tarPos;

    public float waitSec = 1;
    public float toSpeed = 2 ;
    public float fromSpeed = 2;
    void Start()
    {
        originPos = transform.position;
        tarPos = new Vector2(originPos.x + 7, originPos.y);
        StartCoroutine(moving());
    }

    void Update()
    {
        
    }

    IEnumerator moving()
    {

        while (true)
        {
            while (Vector2.Distance(transform.position, tarPos) > 0.01f)
            {
                transform.position = Vector2.Lerp(transform.position, tarPos, toSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitSec);

            while (Vector2.Distance(transform.position, originPos) > 0.01f)
            {
                transform.position = Vector2.Lerp(transform.position, originPos, fromSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(waitSec);


        }
    }
}
