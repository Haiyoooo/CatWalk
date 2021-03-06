﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject storeSpace;
    [SerializeField] GameObject closetSpace;
    public ItemLog[] AllItemList = new ItemLog[3];
    [SerializeField] List<GameObject> storeItems = new List<GameObject>();
    [SerializeField] List<GameObject> closetItems = new List<GameObject>();
    [SerializeField] GameObject shopManager;
    [SerializeField] GameObject shopAnchor;
    [SerializeField] GameObject closetAnchor;

    public bool storeUp = false;
    public bool storeDown = false;
    public bool closetUp = false;
    public bool closetDown = false;

    Vector3 shopAnchorSpot;
    Vector3 closetAnchorSpot;

    void Start()
    {
        foreach (ItemLog pair in AllItemList)
        {
            GameObject temp = Instantiate(pair.prefab, transform.position, Quaternion.identity);
            temp.GetComponent<ItemBehavoir>().cost = pair.cost;
        }

        shopAnchorSpot = new Vector3(shopAnchor.transform.position.x + 1.36f, shopAnchor.transform.position.y - 1.1f, 0);
        closetAnchorSpot = new Vector3(closetAnchor.transform.position.x - 5.36f, closetAnchor.transform.position.y - 1.1f, 0);

    }

    void Update()
    {

        if (shopManager.GetComponent<ShopMenu>().itemsOn) // if the inventory is open to items
        {
            // divides all items into store or closet lists
            storeItems.Clear();
            closetItems.Clear();
            foreach (ItemBehavoir item in GameObject.FindObjectsOfType<ItemBehavoir>())
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

            // organize the items in the store
            int i = 0;
            foreach (GameObject item in storeItems)
            {
                // 2 is the distance between any two items, the (i%3) divides them into 3 columns, 
                // the i/3 makes it move to a new row after every 3 items, the -5.75 and 3 are just initial x and y values to start from
                //Vector3 targetVector = new Vector3(-5.35f + (2 * (i % 3)), 3.2f - 2 * (i / 3), 0);
                Vector3 targetVector = shopAnchorSpot + new Vector3(2 * (i % 3), -2 * (i / 3), 0);

                if (transform.position != targetVector)
                {
                    item.transform.position = Vector3.Lerp(item.transform.position, targetVector, 0.4f);
                    item.transform.localScale = Vector3.Lerp(item.transform.localScale, Vector3.one, 0.1f);
                }
                i++;
            }

            // organize the items in the closet
            int j = 0;
            foreach (GameObject item in closetItems)
            {
                //Vector3 targetVector = new Vector3(1.35f + (2 * (j % 3)), 3.2f - 2 * (j / 3), 0);
                Vector3 targetVector = closetAnchorSpot + new Vector3(2 * (j % 3), -2 * (j / 3), 0);

                if (transform.position != targetVector)
                {
                    item.transform.position = Vector3.Lerp(item.transform.position, targetVector, 0.1f);
                    item.transform.localScale = Vector3.Lerp(item.transform.localScale, Vector3.one, 0.1f);
                }
                j++;
            }
        }

        else // if the inventory is closed to items
        {
            // send all the items back to the item manager location
            foreach (ItemBehavoir item in GameObject.FindObjectsOfType<ItemBehavoir>())
            {
                item.transform.position = Vector3.Lerp(item.transform.position, transform.position, 0.1f);
                item.transform.localScale = Vector3.Lerp(item.transform.localScale, Vector3.zero, 0.1f);
            }
        }

        // update anchor spots
        shopAnchorSpot = new Vector3(shopAnchor.transform.position.x + 1.36f, shopAnchor.transform.position.y - 1.1f, 0);
        closetAnchorSpot = new Vector3(closetAnchor.transform.position.x - 5.36f, closetAnchor.transform.position.y - 1.1f, 0);

        // store up button
        if ( storeUp && (shopAnchor.transform.position.y > 5) )
        {
            shopAnchor.transform.position = shopAnchor.transform.position + new Vector3(0, -2, 0);
            AudioManager.instance.scroll.Play();
            //storeUp = false;
        }

        // store down button
        if (storeDown && (shopAnchor.transform.position.y < 13))
        {
            shopAnchor.transform.position = shopAnchor.transform.position + new Vector3(0, 2, 0);
            AudioManager.instance.scroll.Play();
            //storeDown = false;
        }

        // closet up button
        if (closetUp && (closetAnchor.transform.position.y > 5))
        {
            closetAnchor.transform.position = closetAnchor.transform.position + new Vector3(0, -2, 0);
            AudioManager.instance.scroll.Play();
            //closetUp = false;
        }

        // closet down button
        if (closetDown && (closetAnchor.transform.position.y < 13))
        {
            closetAnchor.transform.position = closetAnchor.transform.position + new Vector3(0, 2, 0);
            AudioManager.instance.scroll.Play();
            //closetDown = false;
        }

        // reset the arrow bools
        
        if (storeUp)
        {
            storeUp = false;
        }
        if (storeDown)
        {
            storeDown = false;
        }
        if (closetUp)
        {
            closetUp = false;
        }
        if (closetDown)
        {
            closetDown = false;
        }




    }
}


[System.Serializable]
public class ItemLog
{
    public GameObject prefab;
    public int cost;
}