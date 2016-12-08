using UnityEngine;
using System.Collections;

public class PlatformEvil : MonoBehaviour {

    public Renderer rend;
    public MeshCollider col;
    public Color initColor;


    // Use this for initialization
    void Start () {
        rend = gameObject.GetComponent<Renderer>();
        col = gameObject.GetComponent<MeshCollider>();
        initColor = rend.material.color;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other) {
        //Debug.Log("Collision");
        StartCoroutine("Wait");
        
    }

    IEnumerator Wait() {
        rend.material.color = Color.red;

        yield return new WaitForSeconds(1f);
        rend.enabled = false;
        col.enabled = false;

        rend.material.color = initColor;
        //Destroy(this.gameObject);

        yield return new WaitForSeconds(2f);
        rend.enabled = true;
        col.enabled = true;
        //col.enabled = true;
    }
}
