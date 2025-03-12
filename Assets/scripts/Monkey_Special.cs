using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey_Special : MonoBehaviour

{
    [SerializeField]
    public GameObject cubePrefab; // Assign your cube prefab in the Inspector

    [SerializeField]
    public Vector3 areaCenter; // Center of the spawn area

    [SerializeField]
    public Vector3 areaSize; // Size of the spawn area (width, length, height)

    [SerializeField]
    public float destroyTime = 5f; // Time after which the cube will be destroyed

    [SerializeField]
    public float spawnInterval = 10f; // Interval between each spawn

    [SerializeField]
    public float fallSpeed = 1f; // Speed at which the cube falls

    void Start()
    {
        // Call the SpawnCube function every spawnInterval seconds
        InvokeRepeating("SpawnCube", 0f, spawnInterval);
    }

    void SpawnCube()
    {
        // Generate a random position within the specified area
        Vector3 randomPosition = areaCenter + new Vector3(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2),
            Random.Range(-areaSize.z / 2, areaSize.z / 2)
        );

        // Instantiate the cube prefab at the random position
        GameObject cubeInstance = Instantiate(cubePrefab, randomPosition, Quaternion.identity);

        // Apply the fall speed to the cube's Rigidbody
        Rigidbody rb = cubeInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -fallSpeed, 0);
        }

        // Destroy the cube instance after destroyTime seconds
        Destroy(cubeInstance, destroyTime);
    }
}