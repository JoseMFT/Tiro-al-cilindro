using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanGenerator: MonoBehaviour {
    public Material DefaultMaterial;
    float respawnTime = 5f, timeUntilRespawn = 5f;
    [SerializeField]
    GameObject Latas;

    // Update is called once per frame
    void Update () {

        if (timeUntilRespawn <= 0.0f) {
            respawnTime -= 0.05f;
            timeUntilRespawn = respawnTime;
            var position = new Vector3 (Random.Range (-11.0f, 12.0f), 12f, 2.14f);
            Instantiate (Latas, position, Quaternion.identity);
            //Latas.GetComponent<MeshRenderer> ().material = DefaultMaterial;
        }

        timeUntilRespawn -= Time.deltaTime;
    }
}
