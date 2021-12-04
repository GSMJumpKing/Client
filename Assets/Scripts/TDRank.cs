using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDRank
{
    public int id;
    public string name;
    public long score;


    public void SetJsonData(JObject jo)
    {
        this.id = jo["id"].Value<int>();
        this.name = jo["name"].Value<string>();
        this.score = jo["score"].Value<long>();
    }
}
