using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject rankObjPar;
    [SerializeField] GameObject rankObjPrefab;
    public void ShowUI(GameObject obj)
    {
        GameManager.Instance.UIQueue.Enqueue(obj);

        obj.SetActive(true);
    }

    public void Choose(int a)
    {
        GameManager.chooseIndex = a;
        SceneManager.LoadScene(1);
    }


    public void showRank()
    {
        StartCoroutine(showrank());   
    }


    public void gmaeQuit()
    {
        Application.Quit();
    }
    IEnumerator showrank()
    {


        NetworkManager.Instance.reciveData();

        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < rankObjPar.transform.childCount; i++)
        {
            Debug.Log(rankObjPar.transform.GetChild(i).name);

            var obj = rankObjPar.transform.GetChild(i);

            Destroy(obj.gameObject);
        }

        for (int i = 0; i < NetworkManager.Instance.userRankList.Count; i++)
        {

            GameObject obj = Instantiate(rankObjPrefab);
            RankObject rank = obj.GetComponent<RankObject>();
            rank.rank.text = (i + 1).ToString();
            rank.name.text = NetworkManager.Instance.userRankList[i].name;
            rank.score.text = "" + (int)((NetworkManager.Instance.userRankList[i].score / 10000) / 60) + ":" +
                (int)(NetworkManager.Instance.userRankList[i].score / 10000 % 60) + ":" +
                (int)(NetworkManager.Instance.userRankList[i].score % 10000 * 0.01f) + ":" +
                (int)(NetworkManager.Instance.userRankList[i].score % 100);
            obj.transform.parent = rankObjPar.transform;
        }
    }
}
