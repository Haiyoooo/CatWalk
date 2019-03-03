using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int day = 0;
    public int fishCoin = 10;
    public float countDown = 5;
    public Slider timeBar;
    private float timeValue;
    private float timeLength;

    public int debt;

    private Text cashMoney;
    private Text debtText;
    private Text fameStatusText;

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

        cashMoney = GameObject.Find("Cash").GetComponent<Text>();
        debtText = GameObject.Find("Debt").GetComponent<Text>();
        fameStatusText = GameObject.Find("Fame Status").GetComponent<Text>();
    }


    private void Update()
    {
        timeBar.value = ((day - 1) * (1 / (countDown - 1))) % countDown;
        if (timeBar.value > 1) timeBar.value = 0;

        displayText();
    }

    private void displayText()
    {
        cashMoney.text = "You have: " + fishCoin;
        debtText.text = "You owe: " + debt;
        fameStatusText.text = "Nobody knows you...";
    }
}
