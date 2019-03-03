using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject storeSpace;
    [SerializeField] GameObject closetSpace;
    public ItemLog[] AllItemList = new ItemLog[3];
    [SerializeField] List<GameObject> storeItems = new List<GameObject>();
    [SerializeField] List<GameObject> closetItems = new List<GameObject>();

    void Start()
    {
        foreach (ItemLog pair in AllItemList)
        {
            GameObject temp = Instantiate(pair.prefab, transform.position, Quaternion.identity);
            temp.GetComponent<ItemBehavoir>().cost = pair.cost;
        }
        
    }

    void Update()
    {
        // divides all items into store or closet lists
        if (true /* TODO: INSERT CODE THAT CHECKS IF THE STORE/CLOSET IS OPEN*/ )
        {
            storeItems.Clear();
            closetItems.Clear();
            foreach ( ItemBehavoir item in GameObject.FindObjectsOfType<ItemBehavoir>() )
            {
                if (item.location == ItemBehavoir.foundIn.store)
                {
                    storeItems.Add(item.gameObject);
                }
                else
                {
                    closetItems.Add(item.gameObject);
                }
            }
        }
        
        // organize the items in the store
        int i = 0;
        foreach (GameObject item in storeItems)
        {
            Vector3 targetVector = new Vector3((-5.75f + (2 * (i % 3))), (3 - 2 * (i / 3)), 0);
            if (transform.position != targetVector)
            {
                item.transform.position = Vector3.Lerp(item.transform.position, targetVector, 0.60f);
            }
            i++;
        }
        
        // organize the items in the closet
        int j = 0;
        foreach (GameObject item in closetItems)
        {
            Vector3 targetVector = new Vector3((1.75f + (2 * (j % 3))), (3 - 2 * (j / 3)), 0);
            
            if (transform.position != targetVector)
            {
                item.transform.position = Vector3.Lerp(item.transform.position, targetVector, 0.1f);
            }
            j++;
        }
        
    }
}


[System.Serializable]
public class ItemLog
{
    public GameObject prefab;
    public int cost;
}