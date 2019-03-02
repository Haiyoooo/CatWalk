using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemLog[] AllItemList = new ItemLog[3];


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class ItemLog
{
    public GameObject prefab;
    public int cost;
}