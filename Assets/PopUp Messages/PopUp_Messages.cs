using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PopUp_Messages : MonoBehaviour
{
    [Header("Party Messages")]
    public string[] success_party;
    public string[] fail_party;
    public string[] super_party;

    [Header("Job Messages")]
    public string[] success_job;
    public string[] fail_job;
    public string[] super_job;

    private int tempMessage;

    private Job parent;

    private Text msgText;

    private void Start()
    {
        parent = transform.parent.GetComponent<Job>();

        tempMessage = Random.Range(0, 3);

        msgText = gameObject.transform.GetChild(4).GetComponent<Text>();

    }

    private void Update()
    {
        Debug.Log(parent);

        //parent is a job
        if (parent.isJob == true)
        {
            switch (parent.thisEventState)
            {
                case (Job.eventState.SUCCESS):

                    msgText.text = success_job[tempMessage];

                    break;

                case (Job.eventState.SUPERSUCCESS):

                    msgText.text = super_job[tempMessage];

                    break;

                case (Job.eventState.FAIL):

                    msgText.text = fail_job[tempMessage];

                    break;
            }
          
        }

        //parent  is a party
        else if(parent.isJob == false) 
        {
            switch (parent.thisEventState)
            {
                case (Job.eventState.SUCCESS):

                    msgText.text = success_party[tempMessage];

                    break;

                case (Job.eventState.SUPERSUCCESS):

                    msgText.text = super_party[tempMessage];

                    break;

                case (Job.eventState.FAIL):

                    msgText.text = fail_party[tempMessage];

                    break;
            }
        }
    }
}
