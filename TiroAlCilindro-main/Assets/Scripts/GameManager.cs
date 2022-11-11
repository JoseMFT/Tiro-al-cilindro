using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager: MonoBehaviour {
    public Material hitMaterial;
    public AudioClip shotCan, shotAir, shotSound, reloadGun, gunCocking;
    public Canvas canvasUI;
    //public GameObject reloadBar;
    private AudioSource gunAudioSource;

    [SerializeField]
    TextMeshProUGUI puntuacion, tiempo, municion;

    float shotStrength = 50f, timeInSeconds = 0f, reloadTime = 2.5f;
    int timeInMinutes = 0, score = 0;
    int ammo = 6;

    void Awake () {
        gunAudioSource = GetComponent<AudioSource> ();
        //reloadBar.SetActive (false);

    }
    // Update is called once per frame
    void Update () {

        timeInSeconds += Time.deltaTime;
        if (timeInSeconds >= 60.0f) {
            timeInSeconds = 0.0f;
            timeInMinutes++;
        }
        tiempo.text = timeInMinutes.ToString () + ":" + timeInSeconds.ToString ("00");
        puntuacion.text = "SCORE: " + score.ToString ();
        municion.text = ammo.ToString () + " /6";

        // Si el número de veces clicado en pantalla es mayor o igual que uno Y se ha dejado de pulsar el clic izquierdo, o si se ha dejado de pulsar el botón:
        if (((Input.touchCount >= 1 && Input.GetTouch (0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp (0)) && ammo >= 1)) // (0 = botón izq., 1 = botón cent., 2= botón der.)
        {
            gunAudioSource.PlayOneShot (shotSound);
            ammo--;
            Vector3 pos = Input.mousePosition;
            // Se ejecuta si el juego está corriendo en Android
            if (Application.platform == RuntimePlatform.Android) {
                pos = Input.GetTouch (0).position;
            }

            Ray rayo = Camera.main.ScreenPointToRay (pos);
            RaycastHit hitInfo;
            if (Physics.Raycast (rayo, out hitInfo)) {
                if (hitInfo.collider.tag.Equals ("Lata")) {
                    gunAudioSource.PlayOneShot (shotCan);
                    score += 10;
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody> ();
                    rigidbodyLata.AddForce (rayo.direction * shotStrength, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer> ().material = hitMaterial;

                } else if (hitInfo.collider.tag.Equals ("Vacio")) {
                    gunAudioSource.PlayOneShot (shotAir);
                    score -= 5;
                }
            }

        } else if (((ammo <= 0) || Input.GetKey ("r")) && reloadTime >= 0.0f) {
            //reloading ();
            reloadTime -= Time.deltaTime;

        } else if (reloadTime <= 0.0f) {
            reloadTime = 2.5f;
            gunAudioSource.PlayOneShot (gunCocking);
            ammo = 6;

        } else if (((ammo <= 0) || Input.GetKey ("r")) && reloadTime >= 2.5f) {
            gunAudioSource.PlayOneShot (reloadGun);
        }

        /*void reloading () {
            reloadBar.SetActive (true);
        }*/
    }
}
