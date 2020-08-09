using TheChest.Items;
using UnityEngine;

/// <summary>
/// Example of world item
/// </summary>
public class WorldItem : MonoBehaviour
{
    private Item item;

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            Destroy(this.gameObject);
        }
    }
}
