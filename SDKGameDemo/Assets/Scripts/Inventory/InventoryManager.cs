using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

    public GameObject Inventory;
    public GameObject Weapon;
    public GameObject Armour;

    bool isInventoryShowing = false;

    void Start()
    {
        LoadContainerItems();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        if (isInventoryShowing == false)
        {
            Inventory.SetActive(true);
            Weapon.SetActive(true);
            Armour.SetActive(true);

            isInventoryShowing = true;
        }
        else
        {
            Inventory.SetActive(false);
            Weapon.SetActive(false);
            Armour.SetActive(false);

            isInventoryShowing = false;
        }
    }

    void LoadContainerItems()
    {
        Inventory.GetComponentInChildren<LoadItemsForContainer>().LoadItems();
        Weapon.GetComponentInChildren<LoadItemsForContainer>().LoadItems();
        Armour.GetComponentInChildren<LoadItemsForContainer>().LoadItems();
    }
}
