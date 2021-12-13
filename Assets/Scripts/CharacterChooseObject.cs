using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChooseObject : MonoBehaviour
{
    public GameObject panel;
    public Text demandText;
    public int demandClearNum;
    void Start()
    {
        demandText.text = demandClearNum + "번 클리어 필요";
        if(GameManager.clearNum >= demandClearNum)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
