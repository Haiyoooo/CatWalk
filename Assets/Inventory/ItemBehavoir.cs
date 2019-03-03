using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavoir : MonoBehaviour
{

    private bool mouseOver = false;
    bool equipped = false;
    public int cost = 1;
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
        // Buying Code
        if ( mouseOver && (location == foundIn.store) && Input.GetMouseButtonDown(0) )
        {
            location = foundIn.closet;
            //AUDIO
            //money -= cost;
        }

        
        // Equip Code
        if ( mouseOver && (location == foundIn.closet) && Input.GetMouseButtonDown(0) )
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
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
    
}
