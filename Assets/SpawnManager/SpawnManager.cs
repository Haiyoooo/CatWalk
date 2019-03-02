using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [Header("SetUp")]
    [SerializeField] private GameObject partyPrefab;
    [SerializeField] private GameObject jobPrefab;

    private GameObject[] cities; //spawnpoints

    private List<GameObject> jobs = new List<GameObject>();
    public static int totalParties = 0;
    public static int totalJobs = 0;

    void Start()
    {
        cities = GameObject.FindGameObjectsWithTag("City");

        //create one job
        Instantiate(jobPrefab, cities[0].transform.position, Quaternion.identity);
        totalJobs++;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("city length" + cities.Length);

        /*if (totalJobs == 0)
        {
            Debug.Log("spawn party");
            Instantiate(partyPrefab, cities[5].transform.position, Quaternion.identity);
        }*/

        PartySpawner();
        

    }

    void PartySpawner()
    {
        if (totalParties < 2)
        {
            Debug.Log("parties " + totalParties);
            int rng = Random.Range(0, cities.Length - 1 );

            if (cities[rng].GetComponent<City>().isEmpty) //TODO: stop it from spawning on things with exisiting stuff
            {
                Instantiate(partyPrefab, cities[rng].transform.position, Quaternion.identity);
                totalParties++;
            }

        }
    }
}
