using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadFiller: MonoBehaviour {
    Image image;
    // Start is called before the first frame update
    void Start () {
        image.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update () {
        image.fillAmount -= Time.deltaTime * 2.5f;
    }
}
