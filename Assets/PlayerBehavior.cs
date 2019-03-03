using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] public Sprite headItem;
    [SerializeField] public Sprite bodyItem;


    void Start()
    {
        headItem = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        bodyItem = this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;
    }

    
    void Update()
    {
        
    }
}
