using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bear : MonoBehaviour
{
  public Animator anim;
  float time =16;
    public bool startAttacking=false;
    public Transform target;
    public NavMeshAgent agent;
   
    // Start is called before the first frame update
    void Start()
    {
        
 agent.destination=target.position;
    }

    // Update is called once per frame
    void Update()
    {
      if(time>15&&!startAttacking&&Mathf.Sqrt(Mathf.Pow((transform.position.z-target.position.z),2)+Mathf.Pow((transform.position.y-target.position.y),2))<7){
        startAttacking=true;
        time=0;

      }
      if(startAttacking){
        time+=Time.deltaTime;
        if(time<3){
          agent.enabled=false;
          anim.SetBool("isAttacking",true);
        anim.SetBool("isRunning",false);

        }
        else if(time>3){
          agent.enabled=true;
          anim.SetTrigger("isAttacking");
            anim.SetBool("isRunning",true);
            
            startAttacking=false;
        }
            
            
      }
      else{
         anim.SetBool("isRunning",true);
      }
    
      
      
    
     
        // Debug.Log(Vector3.Distance(target.position, transform.position));

   if(agent.enabled==true){
     
        agent.destination=target.position;
   }
    }
}
