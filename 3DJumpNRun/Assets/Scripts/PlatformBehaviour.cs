using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

    public float zPosition;
    public float startZPos;
    public int direction;
    public float speed;

	// Use this for initialization
	void Start () {
        zPosition = transform.position.z;
        startZPos = transform.position.z;
        direction = 1;
        speed = 3f;
    }
	
	// Update is called once per frame
	void Update () {

        if (zPosition - startZPos > 5f && direction == 1)
            direction = -1;
        if (zPosition - startZPos < -5f && direction == -1)
            direction = 1;



        zPosition += direction * Time.deltaTime * speed;
        


        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
	}
}
