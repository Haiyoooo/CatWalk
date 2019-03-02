using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobPopUp : Job
{
    private GameObject[] jobs;

    public void hidePopUp()
    {
        disappearAnimation();
        Debug.Log("Call");
        Destroy(transform.parent.gameObject,1f);
    }
}
