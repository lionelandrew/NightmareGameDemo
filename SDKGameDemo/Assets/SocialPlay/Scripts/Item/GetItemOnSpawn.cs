using UnityEngine;
using System.Collections;


[RequireComponent (typeof(ItemGetter))]
public class GetItemOnSpawn : MonoBehaviour {

    void Start()
    {
        ItemGetter itemGetter = GetComponent<ItemGetter>();
        itemGetter.GetItems();
    }
}
