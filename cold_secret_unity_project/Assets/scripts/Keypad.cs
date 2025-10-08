using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public TMP_InputField charHolder;
    public GameObject k1;
    public GameObject k2;
    public GameObject k3;
    public GameObject k4;
    public GameObject k5;
    public GameObject k6;
    public GameObject k7;
    public GameObject k8;
    public GameObject k9;
    public GameObject k0;
    public GameObject kCheck;
    public GameObject kDecline;
    
    public void Key1()
    {
        charHolder.text = charHolder.text + "1";
    }
    public void Key2()
    {
        charHolder.text = charHolder.text + "2";
    }
    public void Key3()
    {
        charHolder.text = charHolder.text + "3";
    }
    public void Key4()
    {
        charHolder.text = charHolder.text + "4";
    }
    public void Key5()
    {
        charHolder.text = charHolder.text + "5";
    }
    public void Key6()
    {
        charHolder.text = charHolder.text + "6";
    }
    public void Key7()
    {
        charHolder.text = charHolder.text + "7";
    }
    public void Key8()
    {
        charHolder.text = charHolder.text + "8";
    }
    public void Key9()
    {
        charHolder.text = charHolder.text + "9";
    }
    public void Key0()
    {
        charHolder.text = charHolder.text + "0";
    }
    public void KeyCheck()
    {
        
        if(charHolder.text == "50603530")
        {
            Debug.Log("Sucesso");
        }
        else
        {
            Debug.Log("errou");
        }
    }
    public void KeyDecline()
    {
        charHolder.text = null;
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
