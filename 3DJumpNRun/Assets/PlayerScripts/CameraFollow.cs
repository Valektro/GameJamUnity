using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private float distanceAway = 5;
    private float distanceUp = 2;
    public float smooth = 100;

    public Transform followedObject;
    public Vector3 toPosition;

    void LateUpdate() {

        toPosition = followedObject.position + Vector3.up * distanceUp - followedObject.forward * distanceAway;

        transform.position = Vector3.Lerp(transform.position, toPosition, smooth * Time.deltaTime);

        transform.LookAt(followedObject);
    }
}
