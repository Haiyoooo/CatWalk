﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCity : MonoBehaviour
{
    public void FinishJob()
    {
        if (GetComponent<Image>().color == Color.blue)
            GetComponent<Image>().color = Color.white;
    }

    public void FinishParty()
    {
        if (GetComponent<Image>().color == Color.red)
            GetComponent<Image>().color = Color.white;
    }
}