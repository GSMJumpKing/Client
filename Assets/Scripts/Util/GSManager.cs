using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GSManager : Singleton<GSManager>
{
    public Transform startPos;

    public Text timer;

    public Text nickName;
    public GameObject inputUI;
    public GameObject endPanel;
    public GameObject toLobbyBtn;
    float time;
    float msec;
    float sec;
    float min;
    float hour;

    public bool isDebugMode;

    public bool isEnd;
    protected override void Awake()
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
        while (!isEnd)
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


    public void GameEnd()
    {
        isEnd = true;
        endPanel.SetActive(true);
        GameManager.clearNum++;
        GameManager.Instance.saveClearNum();
    }

    public void nickNameInput()
    {
        if(nickName.text.Length != 0)
        {
            GameManager.Instance.user.name = nickName.text;
            int endTime = (int)((((hour * 60) + min) * 10000) + sec * 100 + msec);
            GameManager.Instance.user.score = endTime;
            
            inputUI.SetActive(false);

            NetworkManager.Instance.sendData();
            GameManager.Instance.saveClearNum();
            StartCoroutine(spawnButton());
        }
    }

    IEnumerator spawnButton()
    {
        yield return new WaitForSeconds(2);

        toLobbyBtn.SetActive(true);

    }

    public void toLobby()
    {
        SceneManager.LoadScene(0);
    }
    
}
