using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] Characters;
    public Queue<GameObject> UIQueue = new Queue<GameObject>();

    public static int chooseIndex;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIQueue.Dequeue().SetActive(false);
        }
    }

    public void Choose(int a)
    {
        chooseIndex = a;
        SceneManager.LoadScene(1);
    }

    public void SpawnCharacter(Transform pos)
    {
        Instantiate(Characters[chooseIndex],pos);
    }

    public void ShowUI(GameObject obj)
    {
        UIQueue.Enqueue(obj);

        obj.SetActive(true);
    }
}
