using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	void OnDrawGizmos() {

        Gizmos.DrawIcon(gameObject.transform.position, "deathzone");
    }
}
