using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class attackBoss : MonoBehaviour
{
    public TMP_Text txt;
    float count = 0;
    float countMaterials =0;
    float Multiplier=0;
    float attack = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col){
        if (count==5){
            
            Multiplier += .5f;
        }
         if (count==10){
            
            Multiplier += 2f;
        } if (count==20){
            
            Multiplier += 4f;
        }
        
         if(col.gameObject.tag=="material"){
           
           countMaterials++;
            count++;
            txt.SetText("Materials "+(countMaterials)+" \n"+" \n Attack Damage\n"+(attack+(attack*Multiplier)));

         }
          if(col.gameObject.name=="boss"){
            count++;
           
            txt.SetText("Materials "+(countMaterials)+" \n"+" \n Attack Damage\n"+(attack+(attack*Multiplier)));
          }

    }
}
