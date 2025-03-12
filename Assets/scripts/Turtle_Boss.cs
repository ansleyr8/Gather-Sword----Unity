using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin_attack : MonoBehaviour
{
    public float rotationSpeed = 5f; // Speed of the rotation
    [SerializeField]
    /*private float timer = 5;
    private float bulletTime;
    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemySpeed;*/


    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime,0));
       // ShootAtPlayer();

    }

    /*void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;
        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>(); 
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
    }*/
}