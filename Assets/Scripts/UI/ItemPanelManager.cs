using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanelManager : MonoBehaviour
{
    [SerializeField]
    Image image = default;
    [SerializeField]
    GameObject objectPanel = default;

    

    public static ItemPanelManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        objectPanel.SetActive(false);
    }

    public void ShowItem()
    {
        objectPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Hide()
    {
        objectPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Set(Item item)
    {
        image.sprite = item.sprite;
    }
}
