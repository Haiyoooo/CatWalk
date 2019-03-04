using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timebar_Animation : MonoBehaviour
{
    [Header("Icon Images")]
    [SerializeField] private Sprite future; //day hasn't been passed yet
    [SerializeField] private Sprite past; //day is in the past
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = future;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Time Bar Handle") //the arrow indicator, object name 'handle'
        {
            image.sprite = past;
        }
    }

    public void ResetDayMarkerColor()
    {
        image.sprite = future;
    }
}
