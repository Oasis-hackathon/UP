using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Item item;
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("아이템 게또!");

            Item dropitem = this.GetComponent<DropItem>().item;
            Inventory.inveninstance.GetItem(dropitem);

            Destroy(this.gameObject);
        }
    }



}
