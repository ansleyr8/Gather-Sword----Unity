using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Collectable> collectableStorage;

    public static event EventHandler OnCollatableCollected;

    public void Awake()
    {
        collectableStorage = new List<Collectable>();
    }

    public void CollectableCollected(Collectable collectable)
    {
        bool found = false;

        foreach (Collectable item in collectableStorage)
        {
            if(item.Compare(ref collectable))
            {
                found = true;
                item.IncrementCount();
                break;
            }
        }

        if (!found) 
        {
            collectable.IncrementCount();

            collectableStorage.Add(collectable);
        }

        Destroy(collectable.gameObject);

        OnCollatableCollected?.Invoke(collectable, EventArgs.Empty);
    }
}
