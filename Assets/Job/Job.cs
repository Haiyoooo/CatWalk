using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Job : MonoBehaviour
{

    public enum jobState { AVALIABLE, SUCCESS, SUPERSUCCESS, FAIL, DONE };
    public jobState thisJobState;
    private jobPopUp jobPopUp;

    [Header("Job Stats")]
    [SerializeField] private int salary = 20;
    [SerializeField] private float ssBonusMultiplier = 1.5f;

    [Header("PopUp Messages")]
    [SerializeField] private GameObject successPopUp;
    [SerializeField] private GameObject superSuccessPopUp;
    [SerializeField] private GameObject failPopUp; //reference the pop-up messages

    [Header("Disasppear Animation")]
    [SerializeField] private GameObject fireworksFX;

    // Start is called before the first frame update
    void Start()
    {
        jobPopUp = gameObject.GetComponent<jobPopUp>();
    }

    // Update is called once per frame
    void Update()
    {
        //switch(thisJobState)
        //{
        //    case jobState.AVALIABLE:
        //        //do nothing
        //        break;
        //    case jobState.SUCCESS:
        //        success();
        //        break;
        //    case jobState.SUPERSUCCESS:
        //        supersuccess();
        //        break;
        //    case jobState.FAIL:
        //        fail();
        //        break;
        //    default:
        //        break;
        //}

    }
    
    //Fail & Success Conditions
    private void OnMouseOver()
    {
        //DISPLAY TOOL TIP
        Debug.Log("TOOLTIP");

        //move the code below to OnMouseDown when doing the actual game
        //move out day++

        // If there is a UI open, stop player from clicking on other jobs.
        /* Description:
         * Checks if the mouse was clicked over a UI element
         * Prevents player from interacting with other jobs if a UI element is blocking the screen
         * (eg. Message pop-up, Shop interface is open) */
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Success
            //player is wearing 1 item that the job likes
            if (Input.GetMouseButtonDown(0))
            {
                thisJobState = jobState.SUCCESS;
                GameManager.instance.fishCoin += salary; //money
                var tempPopUp = Instantiate(successPopUp);
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("Success." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
            }

            //Fail
            //player is wearing 0 items that the job likes
            else if (Input.GetMouseButtonDown(1))
            {
                thisJobState = jobState.FAIL;
                var tempPopUp = Instantiate(failPopUp);
                tempPopUp.transform.parent = gameObject.transform;
                Debug.Log("Fail." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
            }

            //Super Success
            //player is wearing 2 items that the job likes
            else if (Input.GetMouseButtonDown(2))
            {
                thisJobState = jobState.SUPERSUCCESS;
                var tempPopUp = Instantiate(superSuccessPopUp);
                tempPopUp.transform.parent = gameObject.transform;
                GameManager.instance.fishCoin += Mathf.FloorToInt(salary * ssBonusMultiplier);
                Debug.Log("SUPERSUCCESS." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
            }

            GameManager.instance.day++;
        }

    }

    protected void disappearAnimation()
    {
        //if(thisJobState == jobState.SUCCESS || thisJobState == jobState.SUPERSUCCESS)
        {
            //var FX = Instantiate(fireworksFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy(FX.gameObject, 3f);
            Debug.Log("Disappear" + gameObject.name); //TODO: DESTROY THE FUCKING BUILDING
            Destroy(gameObject, 3f); 
            
        }
    }
}
