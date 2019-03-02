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
        int i = 0;
        foreach (ItemLog pair in AllItemList)
        {
            Instantiate(pair.prefab, new Vector3((float)(-5.75 + (2 * (i % 3))), (float)(3 - 2*(i / 3)), 0), Quaternion.identity);
            i++;


        }


    }

    // Update is called once per frame
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
                else /*if (pair.prefab.GetComponent<ItemBehavoir>().location == ItemBehavoir.foundIn.closet)*/
                {
                    closetItems.Add(item.gameObject);
                }
            }
        }

        // organize the items in the store
        int i = 0;
        foreach (GameObject item in storeItems)
        {
            item.transform.position = Vector3.MoveTowards(transform.position, new Vector3((float)(-5.75 + (2 * (i % 3))), (float)(3 - 2 * (i / 3)), 0), 100);
            i++;
        }

        // organize the items in the closet
        int j = 0;
        foreach (GameObject item in closetItems)
        {
            item.transform.position = Vector3.MoveTowards(transform.position, new Vector3((float)(1.75 + (2 * (j % 3))), (float)(3 - 2 * (j / 3)), 0), 100);
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