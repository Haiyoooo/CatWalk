using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public float day = 0;
    public float countDown = 7;
    public Slider timeBar;
    public int lastWeek = 4;
    public int currentWeek = 1;
    private float dayIndex = 1;

    public int fishCoin = 10;
    public int debt = 20;
    public int[] debtList;
    private bool isPaied = false;

    public GameObject cashText;
    public GameObject debtText;
    private Text fameStatusText;
    public GameObject endWeek;
    public GameObject endWeekText;
    public GameObject nextweekButton;
    public GameObject quitButton;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        fameStatusText = GameObject.Find("Fame Status").GetComponent<Text>();

        debt = debtList[0];
    }

    private void Update()
    {
        TimebarValue();
        DisplayCashDebt();
        PayOnDeadline();
        if (day % countDown == 1)
            isPaied = false;
    }

    private void TimebarValue()
    {
        dayIndex = day % countDown - 1;
        if (day % countDown == 0)
            timeBar.value = 1;
        else
            timeBar.value = dayIndex * (1 / (countDown - 1));
    }

    private void DisplayCashDebt()
    {
        debtText.GetComponent<Text>().text = "You own: " + debt + " FishCoin";
        cashText.GetComponent<Text>().text = "You have: " + fishCoin + " FishCoin";
    }

    private void PayOnDeadline()
    {
        if (day % countDown == 0 && day > 1 && !isPaied)
        {
            fishCoin -= debt;
            isPaied = true;

            if (fishCoin <= 0)
            {//GAME OVER
                endWeekText.GetComponent<TextMeshProUGUI>().text = "You lost lah!";
                quitButton.SetActive(true);
                nextweekButton.SetActive(false);
            }
            else
            {
                if (currentWeek == lastWeek) //WON
                {
                    endWeekText.GetComponent<TextMeshProUGUI>().text = "Meow, you won!";
                    quitButton.SetActive(true);
                    nextweekButton.SetActive(false);
                }

                else //NEXTWEEK

                {
                    endWeekText.GetComponent<TextMeshProUGUI>().text = "Yay, you paid " + debt + " FishCoin on time!";
                    quitButton.SetActive(false);
                    nextweekButton.SetActive(true);
                } 
            }
            endWeek.SetActive(true);

            debt = debtList[currentWeek];
            currentWeek++;
        }
    }


}