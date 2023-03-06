using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;
    [SerializeField]
    Animator animator = default;
    [SerializeField]
    GameObject phone = default;

    private void Start()
    {
        phone.SetActive(false);
    }

    private void LateUpdate()
    {
        Open();
    }

    void Open()
    {
        if (targetCamera)
        {
            RaycastHit hit;

            if (Physics.Raycast(targetCamera.ViewportPointToRay(
                new Vector2(0.5f, 0.5f)),
                out hit,
                1.0f))
            {
                if (hit.collider.CompareTag("Box")
                    && ItemBox.instance.hasKey(Item.Type.Key)
                    && Input.GetKeyDown(KeyCode.F))
                {
                    phone.SetActive(true);
                    animator.Play("OpenBox");
                }
                else if (hit.collider.CompareTag("Box")
                         && Input.GetKeyDown(KeyCode.F))
                {
                    MessagePanelManager.instance.ShowPanel("Locked,Need A Key.");
                }
            }
        }
    }


}