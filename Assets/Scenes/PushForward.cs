using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushForward : MonoBehaviour
{
    public string trigger ="";
    public GameObject obj;
    bool move = false;
    float time = 0;
    float moveVector= 0;
     float speedTime = 0;
     float speedDuration = 0;
    void Start(){
        
    }
    void Update(){
        if(move==true){
            time+=Time.deltaTime;
        }
        if(time>.3&&move==true){
            move =false;
            
             
              time = 0;
        }
       if(move){
        Debug.Log("Trigger Entered");
          if(trigger=="front"){
         
          moveVector= Mathf.Lerp(transform.position.z,transform.position.z+10,speedTime/speedDuration);
          transform.Translate(moveVector *Vector3.one);
          }
         if(trigger=="back"){
       
         moveVector= Mathf.Lerp(transform.position.z,transform.position.z-10,speedTime/speedDuration);
         transform.Translate(moveVector *Vector3.one);
         }
         if(trigger=="left"){
       
        moveVector=  Mathf.Lerp(transform.position.z,transform.position.z-10,speedTime/speedDuration);
        transform.Translate(moveVector *Vector3.one);
         }
         if(trigger=="right"){
        
         moveVector= Mathf.Lerp(transform.position.z,transform.position.z+10,speedTime/speedDuration);
         transform.Translate(moveVector *Vector3.one);
         }
       }
        
        
    }
    private void OnTriggerEnter(Collider col){
        if(col.gameObject.name=="Player"){
          move = true;
          
        }
      
    }
    
}
