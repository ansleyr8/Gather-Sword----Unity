using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mallet_smashimprov : MonoBehaviour
{
    public float attackDistance = 1.0f;  // Distance of each attack
    public float attackSpeed = 1.0f;  // Speed of each attack
    public float returnSpeed = 0.5f;  // Speed of return
   
  

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(PerformAttack());
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
    }
}
