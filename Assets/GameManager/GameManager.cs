using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int day = 0;
    public int fishCoin = 10;
    public float countDown = 5;
    public Slider timeBar;
    private float timeValue;
    private float timeLength;

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
        timeBar.value = ((day - 1) * (1 / (countDown - 1))) % countDown;
        if (timeBar.value > 1) timeBar.value = 0;
    }
}
