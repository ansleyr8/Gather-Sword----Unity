using System;
using UnityEngine;

/*
This class should be placed Under the Empty/Place holder gameobject(Puzzle parent gameobject).
The parent of the gameobject should be related to puzzle
For example the parent should hold PuzzleManager.cs script.
*/
public class PuzzleBoxTarget : MonoBehaviour
{
    // These values will be used in Push.BoxType to have a comparision On collisions
    public enum BoxTarget
    {
        Undefined = 0,
        Yellow = 1,
        Orange = 2,
        Green = 3
    }

    private PuzzleManager puzzleManager;
    [SerializeField]
    private BoxTarget boxTarget;
    private bool reachedTarget = false;

    private void Start()
    {
        if(boxTarget == BoxTarget.Undefined)
        {
            Debug.LogError("The Box Target type cannot be undefined");
            return;
        }

        puzzleManager = GetComponentInParent<PuzzleManager>();

        if(puzzleManager == null)
        {
            Debug.LogError("The Parent doesn't contain PuzzleManager, is your puzzle setup correct?");
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("box"))
        {
            Push pushRef = other.GetComponent<Push>();

            if (pushRef != null)
            {
                if(AreEnumsEqual(this.boxTarget, pushRef.boxType))
                {
                    reachedTarget = true;
                    pushRef.TargetSnap(this.transform.position);
                    puzzleManager.RefreshList();
                }

            }
            else
            {
                Debug.LogError("Push Reference not found, do you have the Push script attached to the gameobject which is tagged with box?");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("box"))
        { 
            Debug.Log("OnTriggerExit Called and tag matched with box.");
            reachedTarget = false;
        }
    }

    private bool AreEnumsEqual<TEnum1, TEnum2>(TEnum1 enum1, TEnum2 enum2)
    where TEnum1 : Enum
    where TEnum2 : Enum
    {
        return Convert.ToInt32(enum1) == Convert.ToInt32(enum2);
    }

    public bool IsTargetReached()
    {
        return reachedTarget;
    }
}
