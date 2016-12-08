using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [System.Serializable]
    public class MoveSettings {

        public float runVelocity = 12;
        public float jumpVelocity = 8;
        public float turnVelocity = 100;
        public float distanceToGround = 1.3f;
        public LayerMask ground;
    }
    [System.Serializable]
    public class InputSettings {

        public string FORWARD_AXIS = "Vertical";
        public string SIDEWAYS_AXIS = "Horizontal";
        public string TURN_AXIS = "Mouse X";
        public string JUMP_AXIS = "Jump";
    }


    public MoveSettings moveSettings;
    public InputSettings inputSettings;

    private Rigidbody playerRigidbody;
    private Vector3 velocity;
    private Quaternion targetRotation;
    private float forwardInput, sidewaysInput, turnInput, jumpInput;

    public Transform spawnPoint;


    public Renderer playerRenderer;
    private Color baseColor = Color.yellow;
    private Color jumpColor = Color.red;
    public float colorState;
    public bool grounded;
    
    



    // Use this everytime the object awakes
    void Awake() {

        playerRigidbody = gameObject.GetComponent<Rigidbody>();

        playerRenderer = gameObject.GetComponent<Renderer>();
        

        velocity = Vector3.zero;
        targetRotation = transform.rotation;
        forwardInput = sidewaysInput = turnInput = jumpInput = 0;
    }

    void Start() {
        Spawn();
    }

    // Update is called once per frame
    void Update() {
       
        manageColor();
        StartCoroutine("MakeColorTransition");
        GetInput();
        Turn();
    }

    void FixedUpdate() {

        //print(Grounded());
        Run();

        Jump();

    }

    void GetInput() {

        if (inputSettings.FORWARD_AXIS.Length != 0)
            forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
        if (inputSettings.SIDEWAYS_AXIS.Length != 0)
            sidewaysInput = Input.GetAxis(inputSettings.SIDEWAYS_AXIS);
        if (inputSettings.TURN_AXIS.Length != 0)
            turnInput = Input.GetAxis(inputSettings.TURN_AXIS);
        if (inputSettings.JUMP_AXIS.Length != 0)
            jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);
    }

    void Run() {

        velocity.x = sidewaysInput * moveSettings.runVelocity;
        velocity.z = forwardInput * moveSettings.runVelocity;

        velocity.y = playerRigidbody.velocity.y;

        playerRigidbody.velocity = transform.TransformDirection(velocity);
    }

    void Jump() {

        if(Grounded() && jumpInput != 0) {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, moveSettings.jumpVelocity, playerRigidbody.velocity.z);
        }
    }

    void Turn() {

        if(Mathf.Abs(turnInput) > 0) {
            targetRotation *= Quaternion.AngleAxis(moveSettings.turnVelocity * turnInput * Time.deltaTime, Vector3.up);

        }
        transform.rotation = targetRotation;

    }

    bool Grounded() {

        return Physics.Raycast(transform.position, Vector3.down, moveSettings.distanceToGround, moveSettings.ground);
    }

    public void Spawn() {

        transform.position = spawnPoint.position;
    }

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "SpawnZone") {
            Spawn();
        }
    }



    //OwnStuff

    void manageColor() {
        //print(velocity.y >= -0.1 && velocity.y <= 0.1);

        if (Grounded()) {
            grounded = true;

        }
        else {
            grounded = false;           
        }

        playerRenderer.material.color = Color.Lerp(jumpColor, baseColor, colorState);
    }

    IEnumerator MakeColorTransition() {
        
        if(grounded && colorState <= 1f) {
            colorState += 3f * Time.deltaTime;
        }
        else if(colorState >= 0f){
            colorState -= 3f * Time.deltaTime;
        }
        else { }

        yield return null;
    }
}
