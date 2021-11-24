using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GSManager : MonoBehaviour
{
    public Transform startPos;
    void Awake()
    {
        GameManager.Instance.SpawnCharacter(startPos);
    }

    void Update()
    {
        
    }
}
