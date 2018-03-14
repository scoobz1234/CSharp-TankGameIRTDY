using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHit : MonoBehaviour {

    void OnColliderEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }
    }
}
