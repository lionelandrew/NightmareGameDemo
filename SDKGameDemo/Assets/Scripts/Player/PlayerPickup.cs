using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {

    public ItemContainer itemContainer;
    public AudioClip playerPickUp;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DropItem")
        {
            audio.PlayOneShot(playerPickUp);
            ItemContainerManager.MoveItem(collision.gameObject.GetComponent<ItemDataComponent>().itemData, null, itemContainer);
            Destroy(collision.gameObject);
        }
    }
}
