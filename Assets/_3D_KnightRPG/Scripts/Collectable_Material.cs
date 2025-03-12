using System;
using UnityEngine;

public class Collectable_Material : Collectable
{
    [SerializeField]
    private InventoryManager inventoryManager;

    private void Start()
    {
        if(base.collectableType == Collectable.Type.Undefined)
        {
            Debug.LogError("The Collectable type cannot be undefined");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            this.gameObject.SetActive(false);

            inventoryManager.CollectableCollected(this);

            //InventoryManager.OnCollatableCollected?.Invoke(this, EventArgs.Empty);
        }
    }
}
