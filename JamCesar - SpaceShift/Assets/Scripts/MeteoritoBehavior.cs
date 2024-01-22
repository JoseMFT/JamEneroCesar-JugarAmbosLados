using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoBehavior : MonoBehaviour
{
    Vector3 destinoMeteorito, spawn;
    float velocidadMeteorito = 5f;

    [SerializeField]    
    GameObject explosionFX;
    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;
        destinoMeteorito = new Vector3(Random.Range(spawn.x - 5.1f, spawn.x + 5.1f), -5f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate () {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, destinoMeteorito, Time.deltaTime * velocidadMeteorito * ScoreControlador.instanceControlador.velocidad);
        if (gameObject.transform.position == destinoMeteorito) {
            Destroy(gameObject, .1f);
        }
    }

    private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.name.Contains("Laser")) {
            ScoreControlador.instanceControlador.puntuacionJugador += 15f;
            Destroy(gameObject, .1f);
        } else if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<FuelControlador>().RestarCombustible();
            gameObject.GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }

    public void DestruirObjeto () {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        explosionFX.SetActive(true);
        Destroy(gameObject, .3f);
    }
}
