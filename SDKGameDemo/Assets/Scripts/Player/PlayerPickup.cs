using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {

    public ItemContainer itemContainer;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DropItem")
        {
            ItemContainerManager.MoveItem(collision.gameObject.GetComponent<ItemDataComponent>().itemData, null, itemContainer);
            Destroy(collision.gameObject);
        }
    }
}
