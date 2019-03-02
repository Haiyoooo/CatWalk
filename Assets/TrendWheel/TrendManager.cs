using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrendManager : MonoBehaviour
{
    public int day;
    float degree;
    
    // Start is called before the first frame update
    void Start()
    {
        day = 1;
    }

    // Update is called once per frame
    void Update()
    {
        degree = (day - 1) * 30;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, degree);
    }
}
