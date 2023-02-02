using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusUIManagement : MonoBehaviour
{
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Char ch = GameObject.Find("Player").GetComponent<Char>();
        if(ch.virus != null)
        {
            hpSlider.value = ch.virus.hp;
            if (ch.virus.hp <= 0)
            {
                ch.virus.hp = 0;
            }
            hpSlider.value = ch.virus.hp;
        }
    }
}
