using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public bool isTiming = false;
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
    bool pressedOne = false;
    int fusiveisAtivos = 0;
    int fusiveisTotal = 5;
    public Light luzAlvo;
    public Light luzLanterna;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    private bool iniciarTimer = false;
    private Vector3 originPosition;
    private Quaternion originRotation;
    public MouseLook mouseLookScript;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        pauseMenu.SetActive(false);
        if(mouseLookScript == null)
        {
        mouseLookScript = FindObjectOfType<MouseLook>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
        if (iniciarTimer = true)
        {
            Timer();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void UserInteract(InputAction.CallbackContext context)
    {
        if (context.performed) {
            userInteract = true;
        } else {
            userInteract = false;
        }
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        if (fusiveisAtivos >= fusiveisTotal)
        {
            UIManager.instance.SetAviso(false);
            UIManager.instance.SetTimer(false);
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        if (fusiveisAtivos >= fusiveisTotal)
        {
            UIManager.instance.SetAviso(true);
            UIManager.instance.SetTimer(true);
        }
    }
    public void Timer()
    {
        //UIManager.instance.SetTimer(true);
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
    }
    
    public void CheckInteractables(){
    RaycastHit hit;
    Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));

    if (Physics.Raycast(rayOrigin, myCam.transform.forward, out hit, rayDistance))
    {
        Interactables interactable = hit.collider.GetComponent<Interactables>();

        if (hit.collider.CompareTag("button"))
            {
                UIManager.instance.SetInteractText(true);
                UIManager.instance.SetKeypad(true);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                mouseLookScript.enabled = false;
            }
        if (hit.collider.CompareTag("button") && Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            UIManager.instance.SetFusivel1(true);
            fusiveisAtivos++;
            if(fusiveisAtivos >= fusiveisTotal)
                {
                    Debug.Log("oi");
                    luzAlvo.enabled = true;
                    luzLanterna.enabled = false;
                    UIManager.instance.SetTimer(true);
                    UIManager.instance.SetAviso(true);
                    iniciarTimer = true;
                    UIManager.instance.SetWarning(true);
                }
        }
        if (hit.collider.CompareTag("number"))
        {
            UIManager.instance.SetKeypad(true);
        }
        else
        {
            UIManager.instance.SetKeypad(false);
        }
         if (hit.collider.CompareTag("button") && Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            UIManager.instance.SetFusivel2(true);
            fusiveisAtivos++;
            if(fusiveisAtivos >= fusiveisTotal)
                {
                    Debug.Log("oi");
                    luzAlvo.enabled = true;
                    luzLanterna.enabled = false;
                    UIManager.instance.SetTimer(true);
                    UIManager.instance.SetAviso(true);
                    iniciarTimer = true;
                    UIManager.instance.SetWarning(true);
                }
        }
         if (hit.collider.CompareTag("button") && Keyboard.current.digit7Key.wasPressedThisFrame)
        {
            UIManager.instance.SetFusivel3(true);
            fusiveisAtivos++;
            if(fusiveisAtivos >= fusiveisTotal)
                {
                    Debug.Log("oi");
                    luzAlvo.enabled = true;
                    luzLanterna.enabled = false;
                    UIManager.instance.SetTimer(true);
                    UIManager.instance.SetAviso(true);
                    iniciarTimer = true;
                    UIManager.instance.SetWarning(true);
                }
        }
         if (hit.collider.CompareTag("button") && Keyboard.current.digit9Key.wasPressedThisFrame)
        {
            UIManager.instance.SetFusivel4(true);
            fusiveisAtivos++;
            if(fusiveisAtivos >= fusiveisTotal)
                {
                    Debug.Log("oi");
                    luzAlvo.enabled = true;
                    luzLanterna.enabled = false;
                    UIManager.instance.SetTimer(true);
                    UIManager.instance.SetAviso(true);
                    iniciarTimer = true;
                    UIManager.instance.SetWarning(true);
                }
        }
         if (hit.collider.CompareTag("button") && Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            pressedOne = true;
        }
        if (hit.collider.CompareTag("button") && Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            UIManager.instance.SetFusivel5(true);
            pressedOne = false;
            fusiveisAtivos++;
            if(fusiveisAtivos >= fusiveisTotal)
                {
                    Debug.Log("oi");
                    luzAlvo.enabled = true;
                    luzLanterna.enabled = false;
                    UIManager.instance.SetTimer(true);
                    UIManager.instance.SetAviso(true);
                    iniciarTimer = true;
                    UIManager.instance.SetWarning(true);
                }
        }
            if (interactable != null && hit.collider.CompareTag("readable") && Mouse.current.leftButton.wasPressedThisFrame)
            {
                originPosition = interactable.transform.position;
                originRotation = interactable.transform.rotation;

                StartCoroutine(MovingObject(interactable, objectReader.position));

                interactable.transform.rotation = Quaternion.Euler(15, 0, 0);

                //UIManager.instance.SetExitRead(true);
            }
            if (interactable != null && hit.collider.CompareTag("door"))
            {
                //UIManager.instance.SetWin(true);
                UIManager.instance.SetObjText(true);
            }
            else{
                UIManager.instance.SetObjText(false);
            }

            if (interactable != null)
        {
            UIManager.instance.SetInteractCursor(true);
            currentInteractable = interactable;
            isViewing = true;
        }
        else
        {
            UIManager.instance.SetInteractCursor(false);
            UIManager.instance.SetInteractText(false);
            //UIManager.instance.SetKeypad(false);
            isViewing = false;
        }
        if (interactable != null && hit.collider.CompareTag("phone"))
        {
            UIManager.instance.SetPhoneText(true);
        }
        else
        {
            UIManager.instance.SetPhoneText(false);
        }
    }
    else
    {
        UIManager.instance.SetInteractCursor(false);
        isViewing = false;
    }
        IEnumerator MovingObject(Interactables obj, Vector3 position)
        {
            float timer = 0;
            while (timer < 1)
            {
                obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * 5);
                timer += Time.deltaTime;
                yield return null;
            }
            obj.transform.position = position;
        }
    }
}
    
