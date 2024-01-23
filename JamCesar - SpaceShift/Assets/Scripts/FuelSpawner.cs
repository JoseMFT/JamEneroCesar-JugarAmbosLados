using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    [SerializeField]
    Transform [] spawners;

    [SerializeField]
    GameObject [] prefabsCombustibles;

    int spawnerAElegir;
    float tiempoParaSpawn = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        tiempoParaSpawn = Random.Range(7.5f, 15f - 2.5f * ScoreControlador.instanceControlador.velocidad);
    }

    // Update is called once per frame
    void Update()
    {
        if (OptionUI.instanceOpciones.isPaused == false) {
            if (tiempoParaSpawn > 0f) {
                tiempoParaSpawn -= Time.deltaTime;
            } else {
                InstanciarCombustibles();
                tiempoParaSpawn = Random.Range(7.5f, 15f - 2.5f * ScoreControlador.instanceControlador.velocidad);
            }
        }
    }

    public void InstanciarCombustibles () {

        Vector3 posicionSpawn = spawners [Mathf.FloorToInt(Random.Range(0f, 1.99f))].position;
        int columnaASpawnear = Mathf.FloorToInt(Random.Range(0f, prefabsCombustibles.Length - .01f));
        Instantiate(prefabsCombustibles [columnaASpawnear], posicionSpawn, Quaternion.identity);
    }
}
