using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMechanics: MonoBehaviour {

    public Material hitMaterial;
    // Start is called before the first frame update
    void OnTriggerEnter (Collider other) {
        if (other.tag == "Vacio") {
            Destroy (gameObject, .5f);
        }
    }

    // Update is called once per frame
    public void color () {
        gameObject.GetComponent<MeshRenderer> ().material = hitMaterial;
    }
}