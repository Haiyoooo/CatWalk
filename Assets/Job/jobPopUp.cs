using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobPopUp : MonoBehaviour
{
    private Job job;

    public void Start()
    {
        job = transform.parent.parent.GetComponent<Job>();
    }

    public void hidePopUp()
    {
       job.disappearOnSuccess(); //remove the event if success
       Destroy(transform.parent.gameObject); //hide the pop up message
    }
}
