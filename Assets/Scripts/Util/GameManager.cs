using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : Singleton<GameManager>
{

    public GameObject[] Characters;
    public Queue<GameObject> UIQueue = new Queue<GameObject>();

    public static int chooseIndex;
    public RankSender user;
    public static int clearNum;
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
        user = new RankSender();
        Application.targetFrameRate = 100;
        loadClearNum();
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
        
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UIQueue.Clear();
    }

    public void SpawnCharacter(Transform pos)
    {
        Instantiate(Characters[chooseIndex],pos);
    }

    public void loadClearNum()
    {
        string a = File.ReadAllText(Application.dataPath + "/Resources/ClearNum.txt");
        clearNum = System.Int32.Parse(a);
    }

    public void saveClearNum()
    {
        File.WriteAllText(Application.dataPath +"/Resources/ClearNum.txt",clearNum.ToString());

    }
    
}
