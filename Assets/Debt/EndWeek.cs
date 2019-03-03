using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWeek : MonoBehaviour
{
    public GameObject panel;

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void NextWeek()
    {
        panel.SetActive(false);
    }
}
