using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCans : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            ScoreControlador.instanceControlador.puntuacionJugador += 2f;
            transform.parent.GetComponent<FuelBehavior>().numeroDeHijosActivos--;
            gameObject.SetActive(false);
        }
    }
}
