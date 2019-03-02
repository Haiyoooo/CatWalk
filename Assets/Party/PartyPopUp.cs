using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopUp : MonoBehaviour
{
    private Party party;

    void Start()
    {
        party = transform.parent.parent.GetComponent<Party>();
    }

    public void hidePartyPopUp()
    {
        party.disappearOnSuccess(); //remove the event if success
        Destroy(transform.parent.gameObject); //hide the pop up message
    }
}
