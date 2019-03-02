using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int day = 0;
    public int fishCoin = 10;
    public int countDown = 5;
    public Slider timeBar;

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
        timeBar.value = (day - 1) * (1 / (countDown - 1));
    }
}
