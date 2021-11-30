using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSManager : MonoBehaviour
{
    public Transform startPos;

    public Text timer;

    float time;
    float msec;
    float sec;
    float min;
    float hour;

    public bool isDebugMode;
    void Awake()
    {
        if (!isDebugMode)
        {
            GameManager.Instance.SpawnCharacter(startPos);
        }
    }


    private void Start()
    {
        StartCoroutine(timerCroutine());

    }

    IEnumerator timerCroutine()
    {
        Debug.Log(2);
        while (true)
        {
            yield return null;
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);
            hour = (int)(time / 60 / 60 % 60);

            timer.text = $"{hour}:{min}:{sec}:{msec}";
        
        }
    }
    
}
