using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{

    private enum jobState { AVALIABLE, SUCCESS, SUPERSUCCESS, FAIL, DONE };
    private jobState thisJobState;
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

        //Success
        //player is wearing 1 item that the job likes
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.day++; //time
            GameManager.instance.fishCoin += salary; //money
            successPopUp.gameObject.SetActive(true); //pop up
            Debug.Log("Success." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
        }

        //Fail
        //player is wearing 0 items that the job likes
        else if (Input.GetMouseButtonDown(1))
        {

            GameManager.instance.day++;
            failPopUp.gameObject.SetActive(true);
            Debug.Log("Fail." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
        }

        //Super Success
        //player is wearing 2 items that the job likes
        else if (Input.GetMouseButtonDown(2))
        {

            GameManager.instance.day++;
            superSuccessPopUp.gameObject.SetActive(true);
            GameManager.instance.fishCoin += Mathf.FloorToInt(salary * ssBonusMultiplier);
            Debug.Log("SUPERSUCCESS." + GameManager.instance.day + " $" + GameManager.instance.fishCoin);
        }
    }

    private void disappearAnimation()
    {
        if(    jobPopUp.hidePopUp()
            && (thisJobState != jobState.FAIL || thisJobState != jobState.AVALIABLE) )
        {
            var FX = Instantiate(fireworksFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Destroy(FX.gameObject, 3f);
        }


    }
}
