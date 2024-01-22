using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBehavior : MonoBehaviour
{
    float velocidadCombustible = 5f;

    [SerializeField]
    GameObject [] hijosActivosArray;

    public int numeroDeHijosActivos;
    // Start is called before the first frame update

    private void Awake () {
        numeroDeHijosActivos = hijosActivosArray.Length - 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > -15f) {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Time.deltaTime * velocidadCombustible * ScoreControlador.instanceControlador.velocidad, 0f);
        } else {
            Destroy(gameObject, .1f);
        }

        if (numeroDeHijosActivos <= 0) {
            Destroy(gameObject, .1f);
        }
    }
}
