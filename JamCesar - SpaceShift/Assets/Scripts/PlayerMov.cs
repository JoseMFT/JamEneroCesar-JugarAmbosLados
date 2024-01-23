using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField]
    GameObject [] prefabsPortales;

    [SerializeField]
    GameObject [] portales;

    int indexLados = 0;
    float timerShift = 0f, movHorizontal;
    const float kTiempoParaShift = .5f, kVelocidadDeMovimiento = 10f;
    bool puedeCambiar = true;
    Rigidbody rbPlayer;
    bool pararDeCopiarPosicion = false;

    Vector3 currentPos, prevPos;

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
        if (OptionUI.instanceOpciones.isPaused == false) {
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


    }

    private void FixedUpdate () {

        movHorizontal = Input.GetAxis("Horizontal");

        switch (movHorizontal) {
            case <= -1f:
                movHorizontal = -1.000f;
                break;

            case >= 1f:
                movHorizontal = 1.000f;
                break;

            default:
                break;
        }

        Vector3 destinoJugador = new Vector3(gameObject.transform.position.x + (movHorizontal * Time.deltaTime * kVelocidadDeMovimiento), gameObject.transform.position.y, gameObject.transform.position.z);

        gameObject.transform.position = destinoJugador;

        gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x, 180f + 30f * movHorizontal * (-1f), 180f);
        UnityEngine.Debug.Log(rbPlayer.velocity.ToString());


         if (indexLados == 0) {
             portales [indexLados].gameObject.transform.position = new Vector3(gameObject.transform.position.x, portales [indexLados].transform.position.y, portales [indexLados].transform.position.z);
             portales [1].gameObject.transform.position = new Vector3(-gameObject.transform.position.x, portales [1].transform.position.y, portales [1].transform.position.z);
         } else {
             portales [indexLados].gameObject.transform.position = new Vector3(gameObject.transform.position.x, portales [indexLados].transform.position.y, portales [indexLados].transform.position.z);
             portales [0].gameObject.transform.position = new Vector3(-gameObject.transform.position.x, portales [0].transform.position.y, portales [0].transform.position.z);
         }



        if (rbPlayer.velocity.x != 0.0f) {
            ReiniciarConstraintsRb();
        }

        //prevPos = currentPos;
    }

    public void TeleportarJugador () {

        foreach (GameObject portal in portales) {
            if (portal == portales [0]) {
                GameObject portalCreado;
                portalCreado = Instantiate(prefabsPortales [0], portales[0].transform.position, Quaternion.Euler(90f, 0f, 0f));
                Destroy(portalCreado, 5f);
            } else {
                GameObject portalCreado;
                portalCreado = Instantiate(prefabsPortales [1], portales [1].transform.position, Quaternion.Euler(90f, 0f, 0f));
                Destroy(portalCreado, 5f);
            }
        }

        if (indexLados == 0) {
            indexLados = 1;
        } else {
            indexLados = 0;
        }

        Vector3 posicionDeTP = new Vector3(portales [indexLados].transform.position.x, portales [indexLados].transform.position.y, gameObject.transform.position.z);
        gameObject.transform.position = posicionDeTP;
    }

    public void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name.Contains("Meteorito")) {
        }
    }
    public void ReiniciarConstraintsRb () {
        UnityEngine.Debug.Log("Reiniciando constraints rb");
        rbPlayer.constraints = RigidbodyConstraints.FreezeAll;
        rbPlayer.isKinematic = true;
        rbPlayer.useGravity = false;
        rbPlayer.isKinematic = false;
        rbPlayer.constraints &= ~RigidbodyConstraints.FreezePositionX;
    }
}
