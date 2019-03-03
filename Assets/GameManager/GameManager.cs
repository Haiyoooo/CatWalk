using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float day = 0;
    public int fishCoin = 10;
    private float countDown = 7;
    public Slider timeBar;
    private float timeValue;
    private float timeLength;
    private float dayIndex = 1;

    public int debt;

    private Text cashMoney;
    private Text debtText;
    private Text fameStatusText;

    public AudioSource[] sounds;

    public AudioSource equip;
    public AudioSource unequip;

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

        sounds = GetComponents<AudioSource>();

        //AUDIO
        equip = sounds[1];
        unequip = sounds[2];

    }


    private void Update()
    {
        dayIndex = day % countDown - 1;
        if (day % countDown == 0)
            timeBar.value = 1;
        else
            timeBar.value = dayIndex * (1 / (countDown - 1));
        //if (timeBar.value > 1) timeBar.value = 0;

        displayText();
    }

    private void displayText()
    {
        cashMoney.text = "You have: " + fishCoin;
        debtText.text = "You owe: " + debt;
        fameStatusText.text = "Nobody knows you...";
    }
}
