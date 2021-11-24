using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] Characters;

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
}
