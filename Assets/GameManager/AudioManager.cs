using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource[] sounds;

    public AudioSource equip;
    public AudioSource unequip;
    public AudioSource item_select;
    public AudioSource job_success_money;


    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        
        //AUDIO

        sounds = GetComponents<AudioSource>();
        equip = sounds[1];
        unequip = sounds[2];
        item_select = sounds[3];
        job_success_money = sounds[4];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
