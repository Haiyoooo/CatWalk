using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject kittyPrefab;
    public GameObject kittyPos;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CatColor()
    {
        if(kittyPos.transform.childCount != 0)
            Destroy(kittyPos.transform.GetChild(0).gameObject, 0.1f);
        Instantiate(kittyPrefab, kittyPos.transform);
    }
}
