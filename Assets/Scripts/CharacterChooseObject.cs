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
        demandText.text = demandClearNum + "�� Ŭ���� �ʿ�";
        if(GameManager.clearNum >= demandClearNum)
        {
            panel.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
