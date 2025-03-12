using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RhinoBehaviour : MonoBehaviour
{
    float time = 0;
    
    float rate=0;
    [SerializeField] float delayTime=0;
    [SerializeField] private GameObject playerObj;
    Vector3 playerPosition;
    Vector3 rhinoPosition;
    float distanceThreshold = 5;
    [SerializeField] float lerpTime = 1;
    [SerializeField] AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(runTowardsPlayer());
        
    }
    void Update()
    {
        time+=Time.deltaTime;
         playerPosition = playerObj.transform.position;
        rhinoPosition = transform.position;
           float a = 0;
       a+=Time.deltaTime;
     
           transform.rotation =Quaternion.LookRotation(new Vector3(playerObj.transform.position.x,0,playerPosition.z));
            if(time<5){
                float i = 0;
                rate = 1 / lerpTime;
                if(i< 1)
                {


                
                    i += Time.deltaTime*rate;
                    transform.position = Vector3.Lerp(rhinoPosition, playerPosition,curve.Evaluate(i) );
                
                }
                if(i>1){
                    transform.position = playerPosition;
                }
            }
             if(time>5){
                time=0;
             }
    }
    // Update is called once per frame
    private IEnumerator runTowardsPlayer()
    {
        
        Debug.Log(" IEnumerator Working");
       
        yield return new WaitForSeconds(delayTime);
       
       

       
       

    }
}
