using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RhinoController : MonoBehaviour
{
    float time2=0;
    bool stop = false;
    float time = 0;
    bool followPlayer = true;
    public float lookRadius=30f;
    Transform target;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
        target =PlayerManager.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        time+=Time.deltaTime;
        if(stop&&time2<3){
            agent.enabled=false;
            followPlayer=false;
            time2+=Time.deltaTime;
            stop = false;
        }
        if(time2>3){
            agent.enabled = true;
          
            time2=0;
            
        }
        if(time>3){
            followPlayer = false;
            agent.speed=100;
             agent.acceleration=100;
        }
         if(time>7){
              stop = false;
            followPlayer=true;
            agent.speed=20;
             agent.acceleration=15;
             time=0;
        }
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius&&followPlayer){
            if(agent.enabled =true)
            agent.destination=target.position;
        }
    }
    private void OnTriggerStay(Collider col) {
        if(col.gameObject.name == "ball"&&Projectile.hit){
            stop= true;
            time=0;
            Projectile.hit=false;
        }
    }
}
