using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static GameObject player;
    public GameObject playerReference;
    
    // Start is called before the first frame update
    void Awake()
    {
       player = playerReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
