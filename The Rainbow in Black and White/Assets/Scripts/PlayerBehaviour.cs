using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    private float side;
    private float jump;
    public float distanceToGround = 11.5f;
    public LayerMask ground;

    private Vector3 dirVec;
    private Rigidbody rigid;
	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody>();
        dirVec = Vector3.zero;

    }
	
	// Update is called once per frame
	void Update ()
    {
        side = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        if(jump != 0)
            print(jump);

    }

    void FixedUpdate() {

        print(Grounded());
        setVelocity();


        dirVec.z = 0f;
        rigid.AddForce(dirVec);

    }

    bool Grounded() {

        return Physics.Raycast(transform.position, Vector3.down, distanceToGround, ground);
    }

    void setVelocity() {

        if (rigid.velocity.x >= speed && rigid.velocity.x > 0|| rigid.velocity.x <= -speed && rigid.velocity.x < 0) {
            print("too fast");
            dirVec.x = 0f;
        }
        /*else if (rigid.velocity.x >= speed-5 || rigid.velocity.x <= -speed+5) {
            print("fast");
            dirVec.x = side * 50;
        }*/
        else {
            dirVec.x = side * 200;
        }

        if (Grounded())
            dirVec.y = jump * jumpSpeed;
        else
            dirVec.y = 0f;
    }

}
