using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopUp : MonoBehaviour
{
    private Party party;
    private Job job;

    void Start()
    {
        party = transform.parent.parent.GetComponent<Party>();
        job = transform.parent.parent.GetComponent<Job>();

    }

    public void hidePopUp()
    {
        //remove the event if success.... TODO: refactor. needed the if function because my script is stupid
        if (transform.parent.parent.tag == "Job")
        {
            job.disappearOnSuccess();
        }
        else
        {
            party.disappearOnSuccess();
        }


        Destroy(transform.parent.gameObject); //hide the pop up message
    }
}
