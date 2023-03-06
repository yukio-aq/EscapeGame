using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCanvas : MonoBehaviour
{
    public static ItemCanvas instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    ItemPanelManager itemPanelManager = default;

    public void SetItem(Item item)
    {
        itemPanelManager.Set(item);
    }
}
