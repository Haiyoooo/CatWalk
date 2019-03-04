using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPopUp : MonoBehaviour
{

    private Event event_;

    void Start()
    {
       event_ = transform.parent.parent.GetComponent<Event>();

    }

    //Button function to close pop-up window
    public void hidePopUp()
    {
        //remove the event if success.... TODO: refactor. needed the if function because my script is stupid
   
           // event_.disappearOnSuccess();


        Destroy(transform.parent.gameObject); //hide the pop up message
    }
}
