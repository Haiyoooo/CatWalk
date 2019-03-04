using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyPopUp : MonoBehaviour
{
    private Party party;
    //private Job job;

    void Start()
    {
        party = transform.parent.parent.GetComponent<Party>();
        //job = transform.parent.parent.GetComponent<Job>();

    }

    //Button function to close pop-up window
    public void hidePopUp()
    {
        //remove the event if success.... TODO: refactor. needed the if function because my script is stupid
        if (transform.parent.parent.tag == "Job")
        {
            //job.disappearOnSuccess();
        }
        else
        {
            party.disappearOnSuccess();
        }


        Destroy(transform.parent.gameObject); //hide the pop up message
    }
}
