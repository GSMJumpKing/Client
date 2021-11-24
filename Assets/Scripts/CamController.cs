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
        int Pos = (int)Player.transform.position.y / 14;

        transform.position = new Vector3(0, Pos * 14 + 7f, -10);
    }
}
