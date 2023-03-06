using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField]
    private Camera targetCamera;

    public Item.Type type = default;

    public void LateUpdate()
    {
        PickupObj();
    }

    public void PickupObj()
    {
        if (targetCamera)
        {
            RaycastHit hit;

            if (Physics.Raycast(targetCamera.ViewportPointToRay(
                new Vector2(0.5f, 0.5f)),
                out hit,
                10.0f))
            {
                if (hit.collider.CompareTag("Item") && Input.GetKeyDown(KeyCode.F))
                {
                    DestroyImmediate(hit.collider.gameObject);
                    Item item = ItemDataBase.instance.Spawn(type);
                    ItemBox.instance.SetItem(item);
                    ItemCanvas.instance.SetItem(item);
                    ItemPanelManager.instance.ShowItem();
                    MessagePanelManager.instance.ShowPanel("Get " + item.type);
                }
            }
        }
    }
}
