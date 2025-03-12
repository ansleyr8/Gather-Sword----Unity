using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoStats : MonoBehaviour
{
    public float hp = 150;
    private static float defense  = 10;
    private float damageDealt= 20-defense;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.name=="sword"&&PlayerMove.isAttacking){

           hp = hp -  damageDealt;
           PlayerMove.isAttacking=false;
           if(hp<=0){
            Destroy(transform.parent.gameObject);

           }
        }
    }
}
