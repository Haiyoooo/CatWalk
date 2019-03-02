using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSpawn : MonoBehaviour
{
    public GameObject[] cities;

    private enum cityType {job, party, none};
    private cityType type;

    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeStatus(GameObject obj, int index)
    {
        //int index = Random.Range(1, 4);
        if (index == 1)
        {
            type = cityType.job;
            obj.GetComponent<Image>().color = Color.blue;
        }
        if (index == 2)
        {
            type = cityType.party;
            obj.GetComponent<Image>().color = Color.red;
        }
        if (index == 3)
        {
            type = cityType.none;
            obj.GetComponent<Image>().color = Color.white;
        }

    }

    void RandomSpawn()
    {
        int job1 = Random.Range(0, 10);
        ChangeStatus(cities[job1], 1);
        int party1;
        do { party1 = Random.Range(0, 10); } while (party1 == job1);
        ChangeStatus(cities[party1], 2);
        int party2;
        do { party2 = Random.Range(0, 10); } while (party2 == job1 && party2 == party1);
        ChangeStatus(cities[party2], 2);

        Debug.Log("job1 " + job1);
        Debug.Log("party1 " + party1);
        Debug.Log("party2 " + party2);
    }

    
}
