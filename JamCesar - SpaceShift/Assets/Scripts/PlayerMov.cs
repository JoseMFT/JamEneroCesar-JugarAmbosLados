using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField]
    Transform [] ladosSpawn;

    [SerializeField]
    GameObject [] portales;

    int indexLados = 0;
    float timerShift = 0f;
    const float kTiempoParaShift = .5f, kVelocidadDeMovimiento = 10f;
    bool puedeCambiar = true;
    Rigidbody rbPlayer;

    // Start is called before the first frame update

    private void Awake () {
        rbPlayer = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        TeleportarJugador();
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeCambiar == true) {

            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                puedeCambiar = false;
                TeleportarJugador();
            }

        } else {

            if (timerShift < kTiempoParaShift) {
                timerShift += Time.deltaTime;
            } else {
                timerShift = 0f;
                puedeCambiar = true;
            }
        }
    }

    private void FixedUpdate () {

        float movHorizontal = Input.GetAxis("Horizontal");
        Vector3 destinoJugador = new Vector3(gameObject.transform.position.x + movHorizontal * Time.deltaTime * kVelocidadDeMovimiento, gameObject.transform.position.y, gameObject.transform.position.z);
        rbPlayer.MovePosition (destinoJugador);

        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180f + 30f * movHorizontal * (-1f), 180f);

    }

    public void TeleportarJugador () {

        foreach (GameObject portal in portales) {
            if (portal.activeSelf == true) {
                portal.SetActive(false);
            }
        }

        foreach (GameObject portal in portales) {
            portal.SetActive(true);

            if (portal == portales [indexLados].gameObject) {
                Vector3 aparicionPortal = new Vector3(gameObject.transform.position.x, portal.transform.parent.position.y, portal.transform.parent.position.z);
                portal.transform.position = gameObject.transform.position;
            } else {

                portal.transform.position = portal.transform.parent.position;
            }
        }

        if (indexLados < ladosSpawn.Length - 1) {
            indexLados++;
        } else {
            indexLados = 0;
        }

        Vector3 posicionDeTP = new Vector3(ladosSpawn [indexLados].position.x, ladosSpawn [indexLados].position.y, gameObject.transform.position.z);
        gameObject.transform.position = posicionDeTP;


    }

    public void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name.Contains("Meteorito")) {
            ReiniciarConstraintsRb();
        }
    }
    public void ReiniciarConstraintsRb () {
        rbPlayer.constraints = RigidbodyConstraints.FreezeAll;
        rbPlayer.isKinematic = true;
        rbPlayer.useGravity = false;
        rbPlayer.isKinematic = false;
        rbPlayer.constraints &= ~RigidbodyConstraints.FreezePositionX;
    }
}
