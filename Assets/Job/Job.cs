using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Job : MonoBehaviour
{
    public enum jobState { AVALIABLE, SUCCESS, SUPERSUCCESS, FAIL };
    public jobState thisJobState = jobState.AVALIABLE;
    private jobPopUp jobPopUp; //refer to pop-up script
    private SpriteRenderer rend;
    private bool mouseOn = false;

    [Header("For Testing")]
    [Tooltip("Number of clothing items currently worn which the company likes")]
    [Range(0,2)]
    [SerializeField] private int correctItems = 0;

    [Header("Job Stats")]
    [SerializeField] private int salary = 20;
    [SerializeField] private float ssBonusMultiplier = 1.5f;

    [Header("PopUp Messages")]
    [SerializeField] private GameObject successPopUp;
    [SerializeField] private GameObject superSuccessPopUp;
    [SerializeField] private GameObject failPopUp; //reference the pop-up messages

    [Header("Disasppear Animation")]
    [SerializeField] private GameObject fireworksFX;

    [Header("Tooltips Setup")]
    [SerializeField] private Text nameTooltip;
    [SerializeField] private Text salaryTooltip;
    private Transform childObj;
    private string jobName = "Zac's Pte Ltd";
    
    // Start is called before the first frame update
    void Start()
    {
        jobPopUp = gameObject.GetComponent<jobPopUp>();
        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.color = Color.white;

        nameTooltip.text = jobName;
        salaryTooltip.text = salary.ToString();

        //tooltip is a child object of this event prefab
        childObj = transform.Find("Tooltip(Canvas)");
        childObj.gameObject.SetActive(false);
    }


    //Tool tip
    private void OnMouseOver()
    {
        childObj.gameObject.SetActive(true);
        //transform.localScale += new Vector3(0.1f, 0.1f, 0);
    }

    private void OnMouseExit()
    {
        childObj.gameObject.SetActive(false);
    }


    //Fail & Success Conditions
    private void OnMouseDown()
    {
        // If there is a UI open, stop player from clicking on other jobs.
        /* Description:
         * Checks if the mouse was clicked over a UI element
         * Prevents player from interacting with other jobs if a UI element is blocking the screen
         * (eg. Message pop-up, Shop interface is open) */
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Success
            //player is wearing 1 item that the job likes
            if (correctItems == 1)
            {
                thisJobState = jobState.SUCCESS;
                GameManager.instance.fishCoin += salary; //money
                var tempPopUp = Instantiate(successPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("Success." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);

                //AUDIO
                AudioManager.instance.job_success.Play();
            }

            //Fail
            //player is wearing 0 items that the job likes
            else if (correctItems == 0)
            {
                thisJobState = jobState.FAIL;
                var tempPopUp = Instantiate(failPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform; 
                Debug.Log("Fail." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);

                //AUDIO
                AudioManager.instance.job_fail.Play();
            }

            //Super Success
            //player is wearing 2 items that the job likes
            else if (correctItems == 2)
            {
                thisJobState = jobState.SUPERSUCCESS;
                GameManager.instance.fishCoin += Mathf.FloorToInt(salary * ssBonusMultiplier); //money
                var tempPopUp = Instantiate(superSuccessPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("SUPERSUCCESS." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
            }

            GameManager.instance.day++;
        }
    }

    public void disappearOnSuccess()
    {
        if (thisJobState == Job.jobState.SUCCESS || thisJobState == Job.jobState.SUPERSUCCESS)
        {
            //var FX = Instantiate(fireworksFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy(FX.gameObject, 3f);
            Debug.Log("Disappear" + gameObject.name);
            //Destroy(gameObject, 0.2f);
            transform.GetComponentInParent<City>().type = City.cityType.none;
        }
    }
}
