using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float day = 0;
    public int fishCoin = 10;
    private float countDown = 7;
    public Slider timeBar;
    private float timeValue;
    private float timeLength;
    private float indexDay = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        indexDay = day % countDown;
        if (indexDay != 0)
            timeBar.value = (indexDay - 1) * (1 / (countDown - 1));
        else
            timeBar.value = 1;
        Debug.Log(timeBar.value);
        //if (day % countDown == 0) timeBar.value = 0;
    }
}
