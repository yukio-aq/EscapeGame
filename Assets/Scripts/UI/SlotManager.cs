using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField]
    Image image = default;
    [SerializeField]
    GameObject backPanel = default;

    Item item = null;

    private void Start()
    {
        backPanel.SetActive(false);
    }

    public void Set(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    public Item SelectedItem()
    {
        return item;
    }

    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    public void OnSelect()
    {

        backPanel.SetActive(true);
    }
    public void Hide()
    {
        backPanel.SetActive(false);
    }
}
