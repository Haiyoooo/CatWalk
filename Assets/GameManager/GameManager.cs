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
    private float timeValue;
    private float timeLength;
    private float dayIndex = 1;

    public int fishCoin = 10;
    public int debt = 20;
    private bool isPaied = false;

    public GameObject cashText;
    public GameObject debtText;
    private Text fameStatusText;
    public GameObject endGame;
    public GameObject endGameText;

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

        fameStatusText = GameObject.Find("Fame Status").GetComponent<Text>();

    }

    private void Update()
    {
        TimebarValue();
        DisplayCashDebt();
        PayOnDeadline();
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
        if (day == countDown && !isPaied)
        {
            fishCoin -= debt;
            isPaied = true;
            if (fishCoin <= 0)
            {
                endGame.SetActive(true);
                endGameText.GetComponent<TextMeshProUGUI>().text = "You lost lah!";
            }
            else
            {
                endGame.SetActive(true);
                endGameText.GetComponent<TextMeshProUGUI>().text = "Meow, you won!";
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
