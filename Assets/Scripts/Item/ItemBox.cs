using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBox : MonoBehaviour
{
    [SerializeField]
    SlotManager[] slotManagers = default;
    [SerializeField]
    GameObject closeButton = default;

    Item selectedItem = default;

    public static ItemBox instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        closeButton.SetActive(false);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Cursor.lockState = CursorLockMode.Confined;
            closeButton.SetActive(true);
        }
    }

    public void SetItem(Item item)
    {
        for (int i = 0; i < slotManagers.Length; i++)
        {
            SlotManager slot = slotManagers[i];
            if (slot.IsEmpty())
            {
                slot.Set(item);
                break;
            }
        }
    }

    public void OnSlotClick(int position)
    {

        for (int i = 0; i < slotManagers.Length; i++)
        {
            slotManagers[i].Hide();
        }
        slotManagers[position].OnSelect();
        selectedItem = slotManagers[position].SelectedItem();
    }

    public bool hasKey(Item.Type type)
    {
        if(selectedItem == null) { return false; }

        if(selectedItem.type == type)
        {
            return true;
        }
        return false;
    }

    public void Close()
    {
        closeButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


}
