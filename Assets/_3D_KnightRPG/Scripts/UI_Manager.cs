using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject collectableUIPrefab;
    [SerializeField]
    private GameObject puzzleFinished_GO;
    [SerializeField]
    private Transform gridLayoutGroup;

    private List<Collectable_UI> collectableUI_Storage;

    private void Awake()
    {
        puzzleFinished_GO.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        InventoryManager.OnCollatableCollected += InventoryManager_OnCollatableCollected;
        collectableUI_Storage = new List<Collectable_UI>();

        PuzzleManager.OnPuzzleFinished += PuzzleManager_OnPuzzleFinished;
    }

    private void OnDestroy()
    {
        InventoryManager.OnCollatableCollected -= InventoryManager_OnCollatableCollected;
        PuzzleManager.OnPuzzleFinished -= PuzzleManager_OnPuzzleFinished;
    }

    private void InventoryManager_OnCollatableCollected(object sender, System.EventArgs e)
    {
        Collectable collectable = (Collectable)sender;

        bool found = false;

        foreach (Collectable_UI item in collectableUI_Storage)
        {
            if (item.collectable.Compare(ref collectable))
            {
                found = true;
                //item.collectable.IncrementCount();

                item.textMesh.text = item.collectable.GetCount().ToString();

                break;
            }
        }

        if (!found)
        {
            //collectable.IncrementCount();

            Collectable_UI collectable_UI = new Collectable_UI();
            collectable_UI.collectable = collectable;

            GameObject gameObject = Instantiate(collectableUIPrefab, gridLayoutGroup);
            collectable_UI.bgImage = gameObject.GetComponent<UnityEngine.UI.Image>();
            collectable_UI.textMesh = gameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();

            collectable_UI.textMesh.text = collectable_UI.collectable.GetCount().ToString();

            collectableUI_Storage.Add(collectable_UI);
        }
    }

    private void PuzzleManager_OnPuzzleFinished(object sender, EventArgs e)
    {
        string puzzleName = (string)sender;
        StartCoroutine(Sleep_Coroutine(3.0f, puzzleName));
    }

    private IEnumerator Sleep_Coroutine(float durationInSeconds, string puzzleName)
    {
        puzzleFinished_GO.SetActive(true);
        puzzleFinished_GO.GetComponentInChildren<TextMeshProUGUI>().text = puzzleName + " Finished";

        yield return new WaitForSeconds(durationInSeconds);

        puzzleFinished_GO.SetActive(false);
    }
}
