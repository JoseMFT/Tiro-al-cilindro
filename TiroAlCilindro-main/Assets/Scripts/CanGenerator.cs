using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanGenerator: MonoBehaviour {
    public GameObject prefabLatas;
    float respawnTime = 5f, timeUntilRespawn = 5f;

    // Update is called once per frame
    void Update () {
        if (timeUntilRespawn <= 0.0f) {
            if (respawnTime >= 1.0f) {
                respawnTime -= 0.05f;
            }
            timeUntilRespawn = respawnTime;
            var position = new Vector3 (Random.Range (-11.0f, 11.0f), 12f, 2.14f);
            Instantiate (prefabLatas, position, Quaternion.identity);
        }
        timeUntilRespawn -= Time.deltaTime;
    }
}
