using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavoir : MonoBehaviour
{

    private bool mouseOver = false;
    public bool equipped = false;
    public int cost = 1;
    public enum foundIn { store, closet };
    public foundIn location = foundIn.store;
    [SerializeField] Sprite wornItemSprite;
    [SerializeField] GameObject equipMark;
    GameObject checkMark;

    enum trend { Western, Goth, Pirate/*, Formal, Neon, Skater, Sporty, Cute, Graceful, Southern, Royal */}
    [SerializeField] trend style; 
    enum putOn { head, body };
    [SerializeField] putOn wornOn;
    

    void Start()
    {
        checkMark = Instantiate(equipMark, this.gameObject.transform);
        checkMark.transform.position = transform.position + Vector3.up + Vector3.right;
    }

    
    void Update()
    {
        // Buying Code
        if (mouseOver && (location == foundIn.store) && Input.GetMouseButtonDown(0))
        {
            location = foundIn.closet;
            //AUDIO
            //money -= cost;
        }

        // Unequip Code
        else if (mouseOver && (location == foundIn.closet) && Input.GetMouseButtonDown(0) && equipped)
        {
            equipped = !equipped;
            GameManager.instance.unequip.Play();

            if (wornOn == putOn.head) // head
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headItem = null;
            }
            else if (wornOn == putOn.body) // body
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyItem = null;
            }
        }

        // Equip Code
        else if (mouseOver && (location == foundIn.closet) && Input.GetMouseButtonDown(0))
        {
            // if this is a headpiece, look through all the items that are also 
            // headpieces and unequip the one that was previously equipped
            if (wornOn == putOn.head) // head
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headItem = wornItemSprite;
                foreach (ItemBehavoir item in GameObject.FindObjectsOfType<ItemBehavoir>())
                {
                    if (item.wornOn == putOn.head)
                    {
                        if (item.equipped)
                        {
                            item.equipped = false;
                            continue;
                        }
                    }
                }
            }
            // if this is a bodypiece, look through all the items that are also 
            // bodypieces and unequip the one that was previously equipped
            else if (wornOn == putOn.body) // body
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyItem = wornItemSprite;
                foreach (ItemBehavoir item in GameObject.FindObjectsOfType<ItemBehavoir>())
                {
                    if (item.wornOn == putOn.body)
                    {
                        if (item.equipped)
                        {
                            item.equipped = false;
                            continue;
                        }
                    }
                }
            }
            equipped = true;
            GameManager.instance.equip.Play();
        }

        checkMark.SetActive(equipped);
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
    
}
