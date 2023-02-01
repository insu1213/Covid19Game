using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManagement : MonoBehaviour
{
    public Slider hpSlider;
    
    void Start()
    {
       hpSlider = GetComponent<Slider>();
    }

    void Update()
    {
        Char ch = GameObject.Find("Player").GetComponent<Char>();
        Debug.Log(ch.hp);
        hpSlider.value = ch.hp;
    }
}
