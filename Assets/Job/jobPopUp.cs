using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jobPopUp : MonoBehaviour
{
    public void Start()
    {
        hidePopUp();
    }

    public void hidePopUp()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
