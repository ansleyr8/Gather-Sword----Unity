using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mallet_smash : MonoBehaviour

{
    public float attackDistance = 1.0f;  // Distance of each attack
    public float attackSpeed = 1.0f;  // Speed of each attack
    public float returnSpeed = 0.5f;  // Speed of return
    public float moveSpeed = 1.0f;  // Speed of enemy movement
    public GameObject Pine_Cone;  // Pine tree prefab
    public int mapSize = 10;  // Size of the map

    private Vector3 initialPosition;
    private int smashCount = 0;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(PerformAttack());
    }

    void Update()
    {
        // Move the enemy along the x-axis at moveSpeed
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    IEnumerator PerformAttack()
    {
        while (true)
        {
            yield return Attack();
            yield return Return();
            yield return new WaitForSeconds(2);  // Wait for 2 seconds
        }
    }

    IEnumerator Attack()
    {
        float startTime = Time.time;
        Vector3 endPosition = initialPosition + new Vector3(0, attackDistance, 0);

        while (Time.time < startTime + attackSpeed)
        {
            transform.position = Vector3.Lerp(initialPosition, endPosition, (Time.time - startTime) / attackSpeed);
            yield return null;
        }
    }

    IEnumerator Return()
    {
        float startTime = Time.time;
        Vector3 currentPosition = transform.position;

        while (Time.time < startTime + returnSpeed)
        {
            transform.position = Vector3.Lerp(currentPosition, initialPosition, (Time.time - startTime) / returnSpeed);
            yield return null;
        }

        // Increment smash count
        smashCount++;

        // Perform special mallet smash after 5 smashes
        if (smashCount >= 5)
        {
            SpecialMalletSmash();
            smashCount = 0;  // Reset smash count
        }
    }

    void SpecialMalletSmash()
    {
        // Instantiate pine tree prefab at a random position on the map
        Vector3 position = new Vector3(Random.Range(-mapSize, mapSize), 0, Random.Range(-mapSize, mapSize));
        Instantiate(Pine_Cone, position, Quaternion.identity);
    }
}
    
