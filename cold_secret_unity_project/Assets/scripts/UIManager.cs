using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject interactCursor;
    public GameObject cursor;
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
}
