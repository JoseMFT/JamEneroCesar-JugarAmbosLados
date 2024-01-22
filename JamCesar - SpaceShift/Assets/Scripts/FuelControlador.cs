using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelControlador : MonoBehaviour
{
    [SerializeField]
    Slider sliderCombustible;

    float fuel = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel > 0f) {
            fuel -= Time.deltaTime * ScoreControlador.instanceControlador.velocidad;
        } else {
            ControladorPartida.gameController.FinalizarPartida();
        }
        
        sliderCombustible.value = fuel;
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.name.Contains("Combustible")) {
            if (fuel <= 97.5f) {
                SumarCombustible();
            }
        }
    }

    public void SumarCombustible () {
        fuel += 2.5f;
    }

    public void RestarCombustible () {
        fuel -= 5f;
    }
}
