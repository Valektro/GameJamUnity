using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{

    private float side;
    private float jump;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        side = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
	}
}
