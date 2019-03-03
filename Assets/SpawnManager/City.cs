using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{

    public enum type { NOTHING, JOB, PARTY }
    public type myType;

    private void Start()
    {

    }

    //private void Update()
    //{
    //    switch(myType)
    //    {
    //        case type.NOTHING:
    //            break;
    //        case type.JOB:
    //            Job();
    //            break;
    //        case type.PARTY:
    //            Party();
    //            break;
    //        default:
    //            myType = type.JOB;
    //            break;
    //    }
    //}
}
