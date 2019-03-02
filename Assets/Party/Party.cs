using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Party : MonoBehaviour
{

    public enum partyState { AVALIABLE, SUCCESS, SUPERSUCCESS, FAIL };
    public partyState thisPartyState = partyState.AVALIABLE;


    [Header("For Testing")]
    [Tooltip("Number of clothing items currently worn which are in Theme")]
    [Range(0, 2)]
    [SerializeField] private int correctItems = 0;

    [Header("Party Hints")]
    [SerializeField] private string[] hints;

    [Header("PopUp Messages")]
    [SerializeField] private GameObject successPopUp;
    [SerializeField] private GameObject superSuccessPopUp;
    [SerializeField] private GameObject failPopUp; //reference the pop-up messages

    [Header("Disasppear Animation")]
    [SerializeField] private GameObject fireworksFX;

    void Start()
    {

    }

    //Tool tip
    private void OnMouseOver()
    {
        Debug.Log("TOOLTIP");
    }

    //Fail & Success Conditions
    private void OnMouseDown()
    {
        // If there is a UI open, stop player from clicking on other jobs.
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //Success
            if (correctItems == 1)
            {
                thisPartyState = partyState.SUCCESS;
                var tempPopUp = Instantiate(successPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
            }

            //Fail
            else if (correctItems == 0)
            {
                thisPartyState = partyState.FAIL;
                var tempPopUp = Instantiate(failPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
            }

            //Super Success
            else if (correctItems == 2)
            {
                thisPartyState = partyState.SUPERSUCCESS;
                var tempPopUp = Instantiate(superSuccessPopUp); //pop up message
                tempPopUp.transform.parent = gameObject.transform;
            }

            GameManager.instance.day++;
        }
    }

    public void disappearOnSuccess()
    {
        if (thisPartyState == Party.partyState.SUCCESS || thisPartyState == Party.partyState.SUPERSUCCESS)
        {
            //var FX = Instantiate(fireworksFX, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //Destroy(FX.gameObject, 3f);
            Debug.Log("Disappear" + gameObject.name);
            Destroy(gameObject, 1f);
            SpawnManager.totalParties--;
        }
    }
}
