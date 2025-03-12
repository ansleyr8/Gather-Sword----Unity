using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
   public Slider slider;
    float time = 1;
    public float hp = 100;
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
        
        if(other.gameObject.name=="rhino"){
            time += Time.deltaTime;
            if(time>1){
           hp = hp -  damageDealt;
            slider.value -= .1f;
           time=0;
            }
          
           if(hp<=0){
            Destroy(gameObject);

           }
        }
    }
    private void OnTriggerExit(Collider other) {
        time=0;
    }
}

