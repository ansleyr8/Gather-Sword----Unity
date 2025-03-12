using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle_move : MonoBehaviour
{
    public float circleSpeed = 1f; // Speed of the circular movement
    public float radius = 5f; // Radius of the circular path

    private float angle = 0f; // Current angle on the circular path

    void Update()
    {
        // Move the cube in a circular path
        angle += circleSpeed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        transform.position = new Vector3(x, y, transform.position.z);
    }
}