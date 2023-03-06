using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemDataBaseEntity ItemDataBaseEntity = default;

    public Item Spawn(Item.Type type)
    {
        for (int i = 0; i < ItemDataBaseEntity.items.Count; i++)
        {
            Item itemData = ItemDataBaseEntity.items[i];
            if (itemData.type == type)
            {
                return new Item(itemData);
            }
        }
        return null;
    }
}
