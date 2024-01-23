using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FondoMovimiento : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed = 4.0f;

    private void Start()
    { 
        startPosition = transform.position;
    }
    private void Update()
    {
        if (OptionUI.instanceOpciones.isPaused == false && SceneManager.GetActiveScene().name == "Partida copia") {
            transform.Translate(translation: Vector3.down * speed * Time.deltaTime * ScoreControlador.instanceControlador.velocidad);
            if (transform.position.y < -10.56) {
                transform.position = startPosition;
            }
        }
    }
}
