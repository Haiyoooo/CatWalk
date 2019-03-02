using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrendManager : MonoBehaviour
{
    public int day;
    float degree;
    int[] style;
    public int inSeason;
    public int passSeason;
    public int nextSeason;
    
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        style = new int[12];
        inSeason = 1;
        passSeason = 12;
        nextSeason = 2;
    }

    // Update is called once per frame
    void Update()
    {
        degree = (day - 1) * 30;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, degree);
        StyleChange();
    }

    void StyleChange()
    {
        if (day % 12 == 0)
            inSeason = 12;
        else
            inSeason = day % 12;
        if (day % 12 - 1 == 0)
            passSeason = 12;
        else if (day % 12 - 1 == -1)
            passSeason = 11;
        else
            passSeason = day % 12 - 1;
        nextSeason = day % 12 + 1;
    }
}
