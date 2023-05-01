using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerinRange;

    public string ItemName;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerinRange && SelectionManager.instance.OnTarget && SelectionManager.instance.selectedObject == gameObject)
        {

            if (!InventorySystem.Instance.CheckIfFull())
            {
                InventorySystem.Instance.AddToInventory(ItemName);

                Destroy(gameObject);

            }
            else
            {

                Debug.Log("inventory is full");

            }


        }




    }

    public string GetItemName()
    {

        return ItemName;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            playerinRange = true;


        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            playerinRange = false;


        }



    }

}