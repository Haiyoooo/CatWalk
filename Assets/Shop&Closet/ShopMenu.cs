using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    private bool mouseOver = false;
    private bool opened = false;
    public bool itemsOn = false;
    [SerializeField] GameObject closetIcon;
    [SerializeField] GameObject storeWindow;
    [SerializeField] GameObject closetWindow;
    private Transform childObj;
    private Vector3 windowScale;

    void Start()
    {
        // finds and disables the gray out rect
        childObj = transform.Find("Canvas");
        childObj.gameObject.SetActive(false);
        windowScale = new Vector3(1, 0.725f, 1);
    }

    
    void Update()
    {
        if (mouseOver && Input.GetMouseButtonDown(0))
        {
            opened = !opened;
            childObj.gameObject.SetActive(opened);

            //AUDIO
            if (opened)
            {
                AudioManager.instance.open_shop.Play();
            }
            else
            {
                AudioManager.instance.close_shop.Play();
            }
            
        }

        if (opened)
        {

            // closet icon moves to the top right of the screen
            Vector3 targetVector = new Vector3( -transform.position.x, transform.position.y, 0 );
            closetIcon.transform.position = Vector3.Lerp(closetIcon.transform.position, targetVector, 0.1f);
            closetWindow.transform.position = Vector3.Lerp(closetWindow.transform.position, targetVector, 0.1f);

            if (closetIcon.transform.position.x > 1) // if the closet icon gets far enough to the right
            {
                // store window opens
                storeWindow.transform.localScale = Vector3.Lerp(storeWindow.transform.localScale, windowScale, 0.2f);

                // closet window opens
                closetWindow.transform.localScale = Vector3.Lerp(closetWindow.transform.localScale, windowScale, 0.2f);

                itemsOn = true;
            }
            
        }
        else
        {
            // closet icon moves back behind the shop icon
            Vector3 targetVector = new Vector3(transform.position.x + 0.4f, transform.position.y, 0);
            closetIcon.transform.position = Vector3.Lerp(closetIcon.transform.position, targetVector, 0.1f);
            closetWindow.transform.position = Vector3.Lerp(closetWindow.transform.position, targetVector, 0.1f);

            // store window closes
            storeWindow.transform.localScale = Vector3.Lerp(storeWindow.transform.localScale, Vector3.zero, 0.1f);

            // closet window opens
            closetWindow.transform.localScale = Vector3.Lerp(closetWindow.transform.localScale, Vector3.zero, 0.1f);

            itemsOn = false;
        }

    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }

}
