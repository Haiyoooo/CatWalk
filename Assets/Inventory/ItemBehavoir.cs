using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavoir : MonoBehaviour
{

    bool mouseHeld;
    enum foundIn { store, closet };
    foundIn location;
    enum style { Western, Goth, Pirate/*, Formal, Neon, Skater, Sporty, Cute, Graceful, Southern, Royal */}
    bool equipped;
    enum putOn { head, body };
    putOn wornOn;
    bool mouseOver;

    void Start()
    {
        mouseHeld = false;
        location = foundIn.store;
        equipped = false;
        mouseOver = false;
    }

    
    void Update()
    {
        // Mouse grab code

        // grabs the item
        if ( mouseOver && Input.GetMouseButtonDown(0) )
        {
            mouseHeld = true;
        }

        // move with the mouse
        if (mouseHeld)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Scale(transform.position, new Vector3(1, 1, 0));

            // releases the item
            if (Input.GetMouseButtonUp(0))
            {
                mouseHeld = false;
            }
        }

    }

    protected void OnMouseOver()
    {
        mouseOver = true;
    }
    protected void OnMouseExit()
    {
        mouseOver = false;
    }

}
