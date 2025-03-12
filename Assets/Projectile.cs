using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float time2 = 0;
  public static bool hit = false;
 public static bool respawn = false;
   public Rigidbody rb2;
    public static bool rhinoHit = false;
     Vector3 playerForwardVector;
     public Transform t;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
       
        
        if(time2>1){
            hit = false;
            time2=0;
        }
    }
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.name == "sword"&&PlayerMove.isAttacking){
          hit= true; 
           
             
        }
    }
     private void OnTriggerExit(Collider col) {
        if(hit ==true){
            rb2.velocity =t.forward*20;
            time2+=Time.deltaTime;
        }
     }
}
