using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum MovementState{
  None,
  Follow,
  Charge
}
public class rhino : MonoBehaviour
{
  private float rotationSpeed =180;
  private float chargeSpeed =7;
  private float distanceThreshold = 5f;
    private Transform previousTarget;
    bool follow = true;
    float time = 0;
    bool charge = false;
    public Transform target;
    public NavMeshAgent agent;
    private MovementState moveState;
    // Start is called before the first frame update
    void Start()
    {
        
 agent.destination=target.position;
    }

    // Update is called once per frame
    void Update()
    {
     if(agent.enabled==true){
     
      agent.destination = Vector3.Lerp(transform.position,target.position,1);
     }
     
        // Debug.Log(Vector3.Distance(target.position, transform.position));

       
       
         
        
        if(time==0&& Vector3.Distance(target.position, transform.position)>distanceThreshold){
          
           previousTarget=target;
          moveState = MovementState.Follow;
       

        }
        else{
          if(previousTarget==null){
            previousTarget=target;
          }
         transform.rotation= Quaternion.RotateTowards(transform.rotation,previousTarget.rotation,Time.deltaTime*rotationSpeed);
          moveState=MovementState.Charge;
          
        }
       
        if(moveState==MovementState.Follow){
         
      
            agent.enabled=true;
            
        agent.destination=target.position;
        }
          
        if(moveState==MovementState.Charge){
         
          time+=Time.deltaTime;
        
      if(time>1){
       
        agent.enabled=true;
       agent.destination = Vector3.Lerp(transform.position,target.position,1);
         Debug.Log(agent.enabled);
          time=0;
      }
      else{
          // agent.updatePosition = false;
             agent.enabled = false;

           transform.Translate(chargeSpeed*Time.deltaTime*Vector3.forward);
      }
          
        }
        
    }
}
