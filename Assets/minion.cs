using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour
{
    
    public float rotation = 180;
    public Rigidbody rb;
     public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        
        
        rb.velocity=new Vector3(0,0,1*speed);
        
        
       
      
        
        

     
    }
    private void OnTriggerEnter(Collider col){

        if(col.gameObject.name=="wall"){
            
            transform.rotation=new Quaternion(transform.rotation.x,rotation,transform.rotation.z,0);
            rb.velocity=Vector3.zero;
        speed=speed*-1;
       
        
            if(rotation==180){
                rotation=0;
            }
             else if(rotation==0){
                rotation=180;
            }
           
        
        }
    }
}
