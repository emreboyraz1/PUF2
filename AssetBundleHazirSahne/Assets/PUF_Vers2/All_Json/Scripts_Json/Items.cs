using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public string id { get; set; }
    public string type { get; set; }
    public string target { get; set; }
    public string filepath { get; set; }
}
public class ItemJson
{
    public List<Items> items;
}

