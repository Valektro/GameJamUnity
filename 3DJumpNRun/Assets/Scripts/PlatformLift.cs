using UnityEngine;
using System.Collections;

public class PlatformLift : MonoBehaviour {

    public float yPosition;
    public float startYPos;
    public int direction;
    public float speed;
    public int counter;

    // Use this for initialization
    void Start() {
        yPosition = transform.position.y;
        startYPos = transform.position.y;
        direction = 1;
        speed = 1.5f;
        counter = 0;
    }

    // Update is called once per frame
    void Update() {

        
    }

    void FixedUpdate() {
        StartCoroutine("Wait");

        if (yPosition - startYPos > 6.4f && direction == 1 || direction == 0) {
            if (counter == 0) {
                direction = 0;
                counter = 30;
            }
            if (counter < 2)
                direction = -1;

        }
        if (yPosition - startYPos < 0f && direction == -1 || direction == 0) {
            if (counter == 0) {
                direction = 0;
                counter = 30;
            }
            if (counter < 2)
                direction = 1;
        }



        yPosition += direction * Time.deltaTime * speed;



        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
    IEnumerator Wait() {
        if (counter != 0)
            counter--;

        yield return new WaitForSeconds(0.8f);
    }
}
