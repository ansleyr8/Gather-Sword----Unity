using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public GameObject rootObj;
    public float increment = 0;
    public  Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
          if (Input.GetKey("up") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
            increment = 0;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x, increment, rootObj.transform.rotation.z);
            
            
        }
        else if (Input.GetKey("up") && Input.GetKey("right"))
        {
            increment = 45;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x,  increment, rootObj.transform.rotation.z);
        }
        else if (Input.GetKey("up") && Input.GetKey("left"))
        {
            increment = 315;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x, increment, rootObj.transform.rotation.z);
        }
        else if (Input.GetKey("right") && !Input.GetKey("down") && !Input.GetKey("up"))
        {
            increment = 90;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x, increment, rootObj.transform.rotation.z);
        }
        else if (Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
            increment = 180;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x,  increment, rootObj.transform.rotation.z);
            
        }
        else if (Input.GetKey("down") && Input.GetKey("right"))
        {
            increment = 135;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x,  increment, rootObj.transform.rotation.z);
             
        }
        else if (Input.GetKey("down") && Input.GetKey("left"))
        {
            increment = 225;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x,  increment, rootObj.transform.rotation.z);
               
        }
        else if (Input.GetKey("left") && !Input.GetKey("down") && !Input.GetKey("up"))
        {
            increment = 270;
            rootObj.transform.rotation = Quaternion.Euler(rootObj.transform.rotation.x,  increment, rootObj.transform.rotation.z);
            
        }

        if(Input.GetKey("up")){
            transform.Translate(Vector3.forward*Time.deltaTime*5);
        }
        if(Input.GetKey("right")){
            transform.Translate(Vector3.right.x*Time.deltaTime*5,0,0);
        }
        if(Input.GetKey("left")){
            transform.Translate(Vector3.left.x*Time.deltaTime*5,0,0);
        }
        if(Input.GetKey("down")){
            transform.Translate(Vector3.back*Time.deltaTime*5);
        }
         if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
          
            anim.SetBool("isRunning",true);
        }
        else{
              anim.SetBool("isRunning",false);   
                   }
    }
}
