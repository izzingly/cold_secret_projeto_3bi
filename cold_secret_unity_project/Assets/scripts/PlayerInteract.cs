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
        if (isViewing)
        {
            // if (currentInteractable.item.grabbable && Input.GetMouseButtonDown(0))
            if (currentInteractable.item.grabbable && userInteract)
            {
                userInteract = false;
                UIManager.instance.SetInteractCursor(true);

                //RotateObject  
            }
        }
        RaycastHit hit;
        Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit))
        {
            Interactables interactable = hit.collider.GetComponent<Interactables>();
            Interactables interacte = hit.collider.GetComponent<Interactables>();

            if (userInteract)
                {
                    OnView.Invoke();
                    currentInteractable = interactable;
                    isViewing = true;
                }
            else
            {
                // Saiu de cima de um objeto
                UIManager.instance.SetInteractCursor(false);
            }
        }
    }
}
    
