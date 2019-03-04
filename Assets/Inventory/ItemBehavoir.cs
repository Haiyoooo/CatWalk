using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ItemBehavoir : MonoBehaviour
{

    private bool mouseOver = false;
    public bool equipped = false;
    public int cost;
    public enum foundIn { store, closet };
    public foundIn location = foundIn.store;
    [SerializeField] Sprite wornItemSprite;
    [SerializeField] GameObject equipMark;
    GameObject checkMark;

    //[HideInInspector]
    public Text costText; // ERNES

    //enum trend { Western, Goth, Formal, Neon, Skater, Sporty, Cute, Graceful, Pirate, Southern, MiddleEast, Royal };
    [SerializeField] CompanyManager.trend style; 
    enum putOn { head, body };
    [SerializeField] putOn wornOn;
    

    void Start()
    {
       
        checkMark = Instantiate(equipMark, this.gameObject.transform);
        checkMark.transform.position = transform.position + 0.8f*Vector3.up + 0.8f*Vector3.right; 

        // start scale at (0, 0 ,0)
        transform.localScale = Vector3.zero;

        cost = 1;
        costText = gameObject.GetComponentInChildren<Text>();
    }

    
    void Update()
    {

        //Display Cost on  Item
        costText.text = cost + "FC"; // ERNES

        Debug.Log(costText);

        // Buying Code
        if (mouseOver && (location == foundIn.store) && Input.GetMouseButtonDown(0))
        {
            location = foundIn.closet;
            costText.enabled = false;
            AudioManager.instance.job_success.Play();
            //money -= cost;
        }

        // Unequip Code
        else if (mouseOver && (location == foundIn.closet) && Input.GetMouseButtonDown(0) && equipped)
        {
            equipped = !equipped;
            AudioManager.instance.unequip.Play();

            if (wornOn == putOn.head) // head
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headItem = null;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headStyle = CompanyManager.trend.None;
            }
            else if (wornOn == putOn.body) // body
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyItem = null;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyStyle = CompanyManager.trend.None;
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headStyle = style;
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyStyle = style;
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
            AudioManager.instance.equip.Play();
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
