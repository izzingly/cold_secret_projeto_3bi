using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    public float rayDistance = 2f;
    public float rotateSpeed = 200;
    public Transform objectViewer;
    public Transform objectReader;
    public Transform objectUse;
    public UnityEvent OnView;
    private Camera myCam;
    private bool isViewing;
    private Interactables currentInteractable;
    public bool userInteract = false;
    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
    }
     public void CheckInteractables()
{
    RaycastHit hit;
    Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

    if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, rayDistance))
    {
        Interactables interactable = hit.collider.GetComponent<Interactables>();

        if (interactable != null)
        {
            UIManager.instance.SetInteractCursor(true);
            currentInteractable = interactable;
            isViewing = true;
        }
        else
        {
            UIManager.instance.SetInteractCursor(false);
            isViewing = false;
        }
    }
    else
    {
        UIManager.instance.SetInteractCursor(false);
        isViewing = false;
    }
}
}
    
