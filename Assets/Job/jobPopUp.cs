using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobPopUp : MonoBehaviour
{
    private GameObject[] jobs;
    private Job job;

    public void Start()
    {
        job = transform.parent.parent.GetComponent<Job>();
    }

    public void hidePopUp()
    {
        if(job.thisJobState == Job.jobState.SUCCESS || job.thisJobState == Job.jobState.SUPERSUCCESS)
        {
            Destroy(transform.parent.parent.gameObject); //destroy the job building
            job.disappearAnimation();
        }

        Destroy(transform.parent.gameObject); //hide the pop up message

    }
}
