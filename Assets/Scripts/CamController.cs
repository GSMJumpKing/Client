using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        int Pos = (int)Player.transform.position.y / 10;

        transform.position = new Vector3(0, Pos * 10 + 3f, -10);
    }
}
