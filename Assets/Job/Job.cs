using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Job : MonoBehaviour
{
    public enum eventState { AVALIABLE, SUCCESS, SUPERSUCCESS, FAIL };
    public eventState thisEventState = eventState.AVALIABLE;
    public bool isJob;

    [Header("For Testing")]
    [Tooltip("Number of clothing items currently worn which the company likes")]
    [Range(0, 2)]
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
    [SerializeField] private Text themeTooltip;
    private Transform childObj;
    [SerializeField] private string eventName;
    [SerializeField] private int companyNumber;
    private CompanyManager.trend theme;
    private string themeString;

    // Animation Stuff
    private Vector3 InitialScale;
    private Vector3 FinalScale;
    private bool playDisappear = false;


    // Start is called before the first frame update
    void Start()
    {
        if (isJob)
        {
            companyNumber = Random.Range(0, 9);
            eventName = GameObject.FindGameObjectWithTag("Company Manager").GetComponent<CompanyManager>().CompanyList[companyNumber].name;

            salaryTooltip.text = salary.ToString();
        }
        else // is a party 
        {
            theme = (CompanyManager.trend)Random.Range(0, 12); // picks a random theme
            themeString = theme.ToString(); // gets the theme name string to display
            salary = 0;

            themeTooltip.text = themeString;
        }

        nameTooltip.text = eventName;

        //tooltip is a child object of this event prefab
        childObj = transform.Find("Tooltip(Canvas)");
        childObj.gameObject.SetActive(false);

        //Appear animation
        InitialScale = new Vector3(0.1f, 0.1f, 0.1f);
        FinalScale = new Vector3(1, 1, 1);
        transform.localScale = InitialScale;

    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, FinalScale, Time.deltaTime * 2);
        if (playDisappear)
            transform.localScale = Vector3.Lerp(transform.localScale, InitialScale, Time.deltaTime * 2);
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

            // Determine Success
            if (isJob)
            {
                correctItems = determineJobSuccess();
            }
            else
            {
                correctItems = determinePartySuccess();
            }


            //Success
            //player is wearing 1 item that the job likes
            if (correctItems == 1)
            {
                thisEventState = eventState.SUCCESS;
                GameManager.instance.fishCoin += salary; //money
                var tempPopUp = Instantiate(successPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("Success." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);

                //AUDIO
                if (isJob)
                {
                    AudioManager.instance.job_success.Play();
                }
                else
                {
                    AudioManager.instance.party_success.Play();
                }

            }

            //Fail
            //player is wearing 0 items that the job likes
            else if (correctItems == 0)
            {
                thisEventState = eventState.FAIL;
                var tempPopUp = Instantiate(failPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("Fail." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);

                //AUDIO
                if (isJob)
                {
                    AudioManager.instance.job_fail.Play();
                }
                else
                {
                    AudioManager.instance.party_fail.Play();
                }

            }

            //Super Success
            //player is wearing 2 items that the job likes
            else if (correctItems == 2)
            {
                thisEventState = eventState.SUPERSUCCESS;
                GameManager.instance.fishCoin += Mathf.FloorToInt(salary * ssBonusMultiplier); //money
                var tempPopUp = Instantiate(superSuccessPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("SUPERSUCCESS." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);

                //AUDIO
                if (isJob)
                {
                    AudioManager.instance.job_success.Play();
                }
                else
                {
                    AudioManager.instance.party_success.Play();
                }
            }

            GameManager.instance.day++;
        }
    }

    public void disappearOnSuccess()
    {
        if (thisEventState == eventState.SUCCESS || thisEventState == eventState.SUPERSUCCESS)
        {
            //var FX = Instantiate(fireworksFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy(FX.gameObject, 3f);
            Debug.Log("Disappear" + gameObject.name);
            //Destroy(gameObject, 0.2f);
            transform.GetComponentInParent<City>().type = City.cityType.none;
        }
    }

    public int determineJobSuccess()
    {
        int result = 0;
        CompanyManager.trend playerHeadStyle = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headStyle;
        CompanyManager.trend playerBodyStyle = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyStyle;
        CompanyManager.trend jobWant1 = GameObject.FindGameObjectWithTag("Company Manager").GetComponent<CompanyManager>().CompanyList[companyNumber].itWants[0];
        CompanyManager.trend jobWant2 = GameObject.FindGameObjectWithTag("Company Manager").GetComponent<CompanyManager>().CompanyList[companyNumber].itWants[1];
        
        // only head OR body is what the company likes
        if ((playerHeadStyle == jobWant1) || (playerHeadStyle == jobWant2) ||
             (playerBodyStyle == jobWant1) || (playerBodyStyle == jobWant2))
        {
            result = 1;
        }
        // both head and body is what the company likes
        if (((playerHeadStyle == jobWant1) || (playerHeadStyle == jobWant2)) &&
             ((playerBodyStyle == jobWant1) || (playerBodyStyle == jobWant2)))
        {
            result = 2;
        }

        return result;
    }

    public int determinePartySuccess()
    {
        int result = 0;
        CompanyManager.trend playerHeadStyle = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().headStyle;
        CompanyManager.trend playerBodyStyle = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().bodyStyle;

        //  if the players head AND body in the theme
        if ((playerHeadStyle == theme) && (playerBodyStyle == theme))
        {
            result = 2;
        }
        // if the players head OR body in the theme
        else if ((playerHeadStyle == theme) || (playerBodyStyle == theme))
        {
            result = 1;
        }
        
        return result;
    }
}
