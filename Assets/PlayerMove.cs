using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float time =0;
     public static bool rhinoHit = false;
    public static bool isAttacking=false;
    bool stop = false;
    public Animator anim;
    GameObject rootObj;
    Rigidbody rb;
    Vector3 Velocity;

    public float increment = 0f;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        transform.rotation = new Quaternion(-90,0,0,0);
        rootObj = this.gameObject;
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(isAttacking){
            time+=Time.deltaTime;
            if(time>3&&isAttacking==true){
                isAttacking=false;
                time=0;
            }
            if(isAttacking==false){
                time=0;
            }
        }
        if (Input.GetKey("s")){
            anim.SetBool("isAttacking", true);
           
        }
        if(Input.GetKeyDown("s")){
             isAttacking = true;
    }

        else{
            anim.SetBool("isAttacking", false);
             isAttacking = false;
        }
        if (Input.GetKey("up") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
            increment = 0;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
            
            
        }
        else if (Input.GetKey("up") && Input.GetKey("right"))
        {
            increment = 45;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
        }
        else if (Input.GetKey("up") && Input.GetKey("left"))
        {
            increment = 315;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
        }
        else if (Input.GetKey("right") && !Input.GetKey("down") && !Input.GetKey("up"))
        {
            increment = 90;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
        }
        else if (Input.GetKey("down") && !Input.GetKey("right") && !Input.GetKey("left"))
        {
            increment = 180;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
            
        }
        else if (Input.GetKey("down") && Input.GetKey("right"))
        {
            increment = 135;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
             
        }
        else if (Input.GetKey("down") && Input.GetKey("left"))
        {
            increment = 225;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
               
        }
        else if (Input.GetKey("left") && !Input.GetKey("down") && !Input.GetKey("up"))
        {
            increment = 270;
            rootObj.transform.rotation = Quaternion.Euler(0, increment, 0);
            
        }

        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
          
            anim.SetBool("isRunning",true);
            // Velocity = transform.forward * speed *VelocityIncrease* Time.deltaTime;
            
            transform.Translate(Vector3.forward* speed * Time.deltaTime);
            
        }
        else
        {
            anim.SetBool("isRunning",false);
          
        }
    }
  
}