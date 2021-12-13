using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
public class NetworkManager : Singleton<NetworkManager>
{

    public List<TDRank> userRankList = new List<TDRank>();

    public void sendData()
    {
        StartCoroutine(Sender());
    }

    public void reciveData()
    {
        StartCoroutine(Recive());
    }
    public IEnumerator Sender()
    {

        string userdata = JsonConvert.SerializeObject(GameManager.Instance.user);

        yield return new WaitForSeconds(0.1f);


        UnityWebRequest www = UnityWebRequest.Post("http://192.168.125.248:8080/add-player", userdata);  
        yield return www.Send();

    }

    public IEnumerator Recive()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.125.248:8080/show-player");
        yield return www.Send();

        string a = www.downloadHandler.text;


        yield return null;

        #region 더미데이터
        /*TextAsset t = Resources.Load<TextAsset>("DummyData");
        Debug.Log(t);
        string a = t.text;*/

        #endregion
        
        JArray jArray = new JArray();
        jArray = JArray.Parse(a);


        userRankList.Clear();

        foreach (JObject jo in jArray)
        {

            TDRank tdrank = new TDRank();

            tdrank.SetJsonData(jo);


            userRankList.Add(tdrank);
        }


    }
}
