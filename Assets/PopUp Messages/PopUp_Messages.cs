﻿using System.Collections;
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

    private EventBehavior parent;  

    private Text msgText;

    private Text goldText; 

    private CompanyManager companyManager;

   // private CompanyManager.trend trend;   //COOL ENUM STUFF!!! DIDN'T KNOW IT'S A TYPE LIKE THIS (note for Ernes; don't erase

    private string companyName;

    private string style;

    private int numberOfCompanies;



    private void Start()
    {
       
        parent = transform.parent.GetComponent<EventBehavior>();

        companyManager = GameObject.FindObjectOfType<CompanyManager>(); 

        tempMessage = Random.Range(0, 3);

        msgText = gameObject.transform.GetChild(4).GetComponent<Text>();

        goldText = gameObject.transform.GetChild(3).GetComponent<Text>();

        numberOfCompanies = companyManager.CompanyList.Length;

        var tempRandom = Random.Range(0, numberOfCompanies);

        companyName = GameObject.FindGameObjectWithTag("Company Manager").GetComponent<CompanyManager>().CompanyList[tempRandom].name;


        var tempWant = Random.Range(0, 2);

        style = GameObject.FindGameObjectWithTag("Company Manager").GetComponent<CompanyManager>().CompanyList[tempRandom].itWants[tempWant].ToString();   //0 1 style randomizer   /why zac why

    }

    private void Update()
    {
        Debug.Log(parent);

        //parent is a job
        if (parent.isJob == true)
        {
            switch (parent.thisEventState)
            {
                case (EventBehavior.eventState.SUCCESS):

                    msgText.text = success_job[tempMessage];

                    break;

                case (EventBehavior.eventState.SUPERSUCCESS):

                    msgText.text = super_job[tempMessage];

                    break;

                case (EventBehavior.eventState.FAIL):

                    msgText.text = fail_job[tempMessage];

                    break;
            }

        }

        //parent  is a party
        else if (parent.isJob == false)
        {
            goldText.text = "";

            switch (parent.thisEventState)              //TODO FIGURE OUT HOW TO BOLD
            {
                case (EventBehavior.eventState.SUCCESS):

                    msgText.text = success_party[0] + " " + companyName + " likes " + style + " clothes...";

                    break;

                case (EventBehavior.eventState.SUPERSUCCESS):

                    msgText.text = super_party[0] + " " + companyName + " likes " + style + " clothes...";

                    break;

                case (EventBehavior.eventState.FAIL):

                    msgText.text = fail_party[tempMessage];

                    break;
            }
        }
    }
}
