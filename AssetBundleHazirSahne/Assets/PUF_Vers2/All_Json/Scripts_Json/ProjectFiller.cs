using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectFiller : IProjectFiller
{
    
    public override void Parse(string jsonStream)
    {
        
        Debug.Log("Parsing");
        string s = jsonStream;

        ItemJson it = new ItemJson();
        it.items = new List<Items>();
        it = JsonConvert.DeserializeObject<ItemJson>(s);
        if (it.items != null)
        {
            foreach(Items i in it.items)
            {
                //compare your id with json id
                if (i.id == "1")
                {
                    //do what you want
                }
            }
        }
    }
   
   

}
