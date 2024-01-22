using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoBehavior : MonoBehaviour
{
    Vector3 destinoMeteorito, spawn;
    float velocidadMeteorito = 10f;
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
            ScoreControlador.instanceControlador.puntuacionJugador += 100f;
            Destroy(gameObject, .1f);
        }
    }
}
