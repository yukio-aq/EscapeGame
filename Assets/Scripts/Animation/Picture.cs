using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;
    [SerializeField]
    Animator animator = default;

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
                if (hit.collider.CompareTag("Picture") && Input.GetKeyDown(KeyCode.F))
                {
                    animator.Play("PictureAnimation");
                }
            }
        }
    }

   
}
