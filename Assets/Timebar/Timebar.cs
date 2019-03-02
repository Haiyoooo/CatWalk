using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timebar : MonoBehaviour
{
    private float barValue;
    
    // Start is called before the first frame update
    void Start()
    {
        barValue = GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        //barValue = GameManager.instance.day * (1 / GameManager.instance.countDown);
        //Debug.Log(barValue);
    }
}
