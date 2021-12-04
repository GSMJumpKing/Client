using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public GameObject[] Characters;
    public Queue<GameObject> UIQueue = new Queue<GameObject>();

    public static int chooseIndex;
    public RankSender user;

    void Start()
    {
        DontDestroyOnLoad(this);
        user = new RankSender();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UIQueue.Count != 0)
            {
                UIQueue.Dequeue().SetActive(false);
            }
        }
    }

    

    public void SpawnCharacter(Transform pos)
    {
        Instantiate(Characters[chooseIndex],pos);
    }

    
}
