/* CatWalk
 * 
 * by Zac
 * 7 Mar, 2019
 * 
 * This script hadnles scrolling up and down in Inventory & Shop
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScroll : MonoBehaviour
{
    private bool mouseOver = false;

    [Header("READ-ONLY (do not change!)")] //TODO: I need a better solution for this. LOL
    [Tooltip("")] //ZAC: What are you using isUp for? i see it only as if(isUp) in this script, does it ever change to false or true?
    [SerializeField] private bool isUp; //ZAC: Are these supposed to be read-only? why are you showing in inspector, for debugging? should we initialize these values?
    [SerializeField] private bool inStore; //ZAC: Are these supposed to be read-only? why are you showing in inspector, for debugging? should we initialize these values?

    [Header("Unity Setup Fields")]
    [SerializeField] private GameObject shopIcon;
    [SerializeField] private GameObject itemManager;
    [SerializeField] private Transform shopAnchor; //ZAC: is shopAnchor's position sensitive to inspector or set in code? Where does shopAnchor have to be?
    [SerializeField] private Transform closetAnchor;


    void Start()
    {
        /* This sets Scale to (0,0,0) the images do not appear at the start
         * //ZAC: would disable be beter? or do you need 0,0,0 because you're lerping?
         * Modifies: localScale
         * Returns: -
         */
        transform.localScale = Vector3.zero;
    }

    
    void Update()
    {

         /* Reads mouse-click inputs.
         * Modifies: booleans in the ItemManager script (storeUp, storeDown, closetUp, closetDown)
         * Returns: -
         */
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            // store scroll
            if (inStore)
            {
                if (isUp)
                {
                    itemManager.GetComponent<ItemManager>().storeUp = true;
                }
                else
                {
                    itemManager.GetComponent<ItemManager>().storeDown = true;
                }
            }

            // closet scroll
            else
            {
                if (isUp)
                {
                    itemManager.GetComponent<ItemManager>().closetUp = true;
                }
                else
                {
                    itemManager.GetComponent<ItemManager>().closetDown = true;
                }
            }


        }


        // disable when at the top or bottom
        if (inStore)
        {
            if (isUp)
            {
                if (shopAnchor.transform.position.y < 5)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                if (shopAnchor.transform.position.y > 13)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }
        else
        {
            if (isUp)
            {
                if (closetAnchor.transform.position.y < 5)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            else
            {
                if (closetAnchor.transform.position.y > 13)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                }
                else
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }


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
