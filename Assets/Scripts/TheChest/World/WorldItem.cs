using System;
using TheChest.Items;
using TheChest.World;
using UnityEngine;

/// <summary>
/// Example of world item
/// </summary>
public class WorldItem : MonoBehaviour
{
    [SerializeField]
    private Item item;

    [SerializeField]
    [Range(1,100)]
    private int amount;

    public int Amount { 
        get => amount;
        set {
            if(value <= 0)
            {
                value = 1;
            }
            this.amount = value;
        }
    }

    public Item Item {
        get => item;
        set {
            item = value;
        }
    }

    private void Start()
    {
        if(item == null)
        {
            Destroy(this.gameObject);
        }

        this.GetComponent<SpriteRenderer>().sprite = item.Image;
    }

    public void OnMouseDown()
    {
        if (InventoryManager.PlayerInventory.Add(item, amount))
        {
            Destroy(this.gameObject);
        }
    }
}
