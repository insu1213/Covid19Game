using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManagement : MonoBehaviour
{
    public Slider hpSlider;
    public Text hpNum;
    
    
    void Start()
    {

    }

    void Update()
    {
        Char ch = GameObject.Find("Player").GetComponent<Char>();
        if(ch.hp <= 0)
        {
            ch.hp = 0;
        }
        hpSlider.value = ch.hp;
        hpNum.text = ((int)(Mathf.RoundToInt(ch.hp*100))).ToString();
    }
}
