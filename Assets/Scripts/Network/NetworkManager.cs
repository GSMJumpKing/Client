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

        string data = userdata;
        yield return new WaitForSeconds(1);
        WWWForm form = new WWWForm();

        form.AddField("userData", userdata.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://15.165.160.44:3000/datasave", form);  
        yield return www.Send();

        Debug.Log(www.downloadHandler.text);
    }

    public IEnumerator Recive()
    {
        //UnityWebRequest www = UnityWebRequest.Get("http://192.168.64.1:8080/show-player");
        //yield return www.Send();

        //string a = www.downloadHandler.text;


        yield return null;

        TextAsset t = Resources.Load<TextAsset>("DummyData");
        Debug.Log(t);
        string a = t.text;

        Debug.Log(a);
        //JObject parsedObj = new JObject(); //Json Object 생성

        //parsedObj = JObject.Parse(a);
        //Debug.Log(parsedObj);
        JArray jArray = new JArray();
        jArray = JArray.Parse(a);

        Debug.Log(jArray);

        userRankList.Clear();

        foreach (JObject jo in jArray)
        {

            TDRank tdrank = new TDRank();

            tdrank.SetJsonData(jo);


            userRankList.Add(tdrank);
        }
        Debug.Log("랭크 테이블 완료");


        foreach (var item in userRankList)
        {
            Debug.Log($"{item.id}  {item.name}   {item.score}");

        }
    }
}
