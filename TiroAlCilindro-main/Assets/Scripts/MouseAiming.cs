using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAiming: MonoBehaviour {
    // Update is called once per frame
    void Update () {
        if (((Input.touchCount >= 1 && Input.GetTouch (0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp (0)))) // (0 = botón izq., 1 = botón cent., 2= botón der.)
        {

            Vector3 pos = Input.mousePosition;
            if (Application.platform == RuntimePlatform.Android) {
                pos = Input.GetTouch (0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay (pos);
            RaycastHit hitInfo;
            if (Physics.Raycast (rayo, out hitInfo)) {
                if (hitInfo.collider.tag.Equals ("Cubo")) {
                    hitInfo.collider.GetComponent<CubeScaler> ().OnClick ();
                }
            }
        }
    }
}
