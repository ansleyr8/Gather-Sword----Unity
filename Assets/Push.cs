using UnityEngine;
using static PuzzleBoxTarget;

public class Push : MonoBehaviour
{
    // These values should be identical to compare with PuzzleBoxTarget.BoxTarget
    public enum BoxType
    {
        Undefined = BoxTarget.Undefined,
        Yellow = BoxTarget.Yellow,
        Orange = BoxTarget.Orange,
        Green = BoxTarget.Green
    }

    private PlayerMove script;
    public Rigidbody rb;

    Vector3 forwardMovement;

    public BoxType boxType;

    float time = 0f;
    float moveSpeed;
    bool push = false;

    private void Start()
    {
        if (boxType == BoxType.Undefined)
        {
            Debug.LogError("The Box type cannot be undefined");
        }
        script=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.increment==45||script.increment==135||script.increment==225||script.increment!=335){
            rb.velocity=Vector3.zero;
        }

        if(push==true){
                time+=Time.deltaTime;
                //moveSpeed= Mathf.SmoothStep(1,10,(Time.deltaTime-3)/5);

                moveSpeed= Mathf.SmoothStep(100,200,1.0f);
                rb.velocity+= forwardMovement*moveSpeed*Time.deltaTime;

            if(time>1){
                push=false;
                rb.velocity=Vector3.zero;
                time=0; 
                
            }
        }

    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "box")
        {
            push = false;
            rb.velocity = Vector3.zero;
            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (col.gameObject.name == "Player" && script.increment != 45 && script.increment != 135 && script.increment != 225 && script.increment != 335)
        {
            push = true;
            forwardMovement = script.transform.forward;
            col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void TargetSnap(Vector3 snapPosition)
    {
        push = false;
        rb.velocity = Vector3.zero;
        this.gameObject.transform.position = snapPosition;
    }
}
