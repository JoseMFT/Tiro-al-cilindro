using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScaler: MonoBehaviour {
    bool hit = false;
    public void OnClick () {
        if (hit == true) {
            LeanTween.scale (gameObject, new Vector3 (1f, 1f, 1f), .5f).setEaseOutBounce ();
            hit = false;
            Debug.Log ("small");
        } else if (hit == false) {
            LeanTween.scale (gameObject, new Vector3 (4f, 4f, 4f), .5f).setEaseOutBounce ();
            hit = true;
            Debug.Log ("big");
        }
    }
}