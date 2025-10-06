using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject interactCursor;
    public GameObject cursor;
    public GameObject interactText;
    public GameObject fusivel1;
    public GameObject fusivel2;
    public GameObject fusivel3;
    public GameObject fusivel4;
    public GameObject fusivel5;
    public GameObject timerText;
    public GameObject avisoText;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInteractCursor(bool state)
    {
        interactCursor.SetActive(state);
    }
    public void SetCursor(bool state)
    {
        cursor.SetActive(state);
    }
     public void SetInteractText(bool state)
    {
        interactText.SetActive(state);
    }
    public void SetFusivel1(bool state)
    {
        fusivel1.SetActive(state);
    }
    public void SetFusivel2(bool state)
    {
        fusivel2.SetActive(state);
    }
    
    public void SetFusivel3(bool state)
    {
        fusivel3.SetActive(state);
    }
    public void SetFusivel4(bool state)
    {
        fusivel4.SetActive(state);
    }
    public void SetFusivel5(bool state)
    {
        fusivel5.SetActive(state);
    }
    public void SetTimer(bool state)
    {
        timerText.SetActive(state);
    }
    public void SetAviso(bool state)
    {
        avisoText.SetActive(state);
    }
}
