using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordPanelManager : MonoBehaviour
{
    public static PasswordPanelManager instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    Camera targetCamera;
    [SerializeField]
    GameObject passwordPanel;
    [SerializeField]
    GameObject closeButton;
    [SerializeField]
    incrementManager[] increments = default;
    [SerializeField]
    Animator animator = default;

    int[] Answer = { 0, 2, 1, 9 };

    private void Start()
    {
        passwordPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        ShowPanel();
    }

    public void OnClickButton()
    {
        if(CheckClear())
        {
            passwordPanel.SetActive(false);
            animator.Play("Clear");
        }
    }

    public bool CheckClear()
    {
        for(int i=0; i<increments.Length; i++)
        {
            if (increments[i].password != Answer[i])
            {
                return false;
            }
        }
        return true;
    }

    public void ShowPanel()
    {
        if (targetCamera)
        {
            RaycastHit hit;

            if (Physics.Raycast(targetCamera.ViewportPointToRay(
                new Vector2(0.5f, 0.5f)),
                out hit,
                1.0f))
            {
                if (hit.collider.CompareTag("Door") && Input.GetKeyDown(KeyCode.F))
                {
                    passwordPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.Confined;
                }
            }
        }
    }

    public void Close()
    {
        passwordPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
