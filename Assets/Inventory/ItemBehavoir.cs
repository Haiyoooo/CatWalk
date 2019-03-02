using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavoir : MonoBehaviour
{

    private bool mouseOver = false;
    //bool mouseHeld = false;
    bool equipped = false;
    public enum foundIn { store, closet };
    public foundIn location = foundIn.store;

    enum trend { Western, Goth, Pirate/*, Formal, Neon, Skater, Sporty, Cute, Graceful, Southern, Royal */}
    [SerializeField] trend style; 
    enum putOn { head, body };
    [SerializeField] putOn wornOn;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        // Mouse grab code
        // grabs the item
        if ( mouseOver && (location == foundIn.store) && Input.GetMouseButtonDown(0) )
        {
            //mouseHeld = true;
            print(style);
        }

        // move with the mouse
        /*
        if (mouseHeld)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Scale(transform.position, new Vector3(1, 1, 0));

            // releases the item
            if (Input.GetMouseButtonUp(0))
            {
                mouseHeld = false;

                // moving from the store to closet
                if ( (transform.position.x > 0.5) /*&& (transform.position.y > -3) ) // yes, I did it manually
                {
                    location = foundIn.closet;
                    //AUDIO
                    //money -= cost;
                }
                //tell the ItemManager to reorganize the lists
            }
        }
        */


        // equip code
        if ( (location == foundIn.closet) && mouseOver && Input.GetMouseButtonDown(0))
        {
            //equipped = true;
            /* some code that finds the item that was previously equipped on the
             * player in the same spot (head or body) and sets its equipped = false
             */
        }

    }

    private void OnMouseEnter()
    {
        mouseOver = true;
        print("on " + name);
    }
    private void OnMouseExit()
    {
        mouseOver = false;
        print("off " + name);
    }
    
}
