using System;
using UnityEngine;

[Serializable]
public class Item
{
    public enum Type {
        Phone,
        Key,
    }

    public Type type;
    public Sprite sprite;

    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
    }
}
