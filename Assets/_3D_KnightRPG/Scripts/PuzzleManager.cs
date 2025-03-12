using System;
using System.Collections.Generic;
using UnityEngine;

/*
This class should be placed on a Empty/Place holder gameobject.
The childs of the gameobject should be related to puzzle
For example they should hold PuzzleBoxTarget.cs script.
*/
public class PuzzleManager : MonoBehaviour
{
    private List<PuzzleBoxTarget> puzzleBoxTargets;
    public static event EventHandler OnPuzzleFinished;

    void Start()
    {
        puzzleBoxTargets = new List<PuzzleBoxTarget>();

        foreach(Transform child in this.transform)
        {
            if(child.GetComponent<PuzzleBoxTarget>() != null)
            {
                puzzleBoxTargets.Add(child.GetComponent<PuzzleBoxTarget>());
            }
        }
    }

    public void RefreshList()
    {
        bool finishedPuzzle = true;

        foreach(PuzzleBoxTarget puzzleBoxTarget in puzzleBoxTargets)
        {
            if(!puzzleBoxTarget.IsTargetReached())
            {
                finishedPuzzle = false;
                break;
            }
        }

        if (finishedPuzzle)
        {
            OnPuzzleFinished?.Invoke(this.gameObject.name, EventArgs.Empty);
        }
    }
}
