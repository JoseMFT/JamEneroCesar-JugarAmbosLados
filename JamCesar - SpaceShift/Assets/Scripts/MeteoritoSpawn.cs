using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject [] meteoritosPool;

    [SerializeField]
    GameObject [] spawnsMeteoritos;

    int indexMeteoritos = 0;
    float timerMeteoritos;
    const float kTiempoEntreMeteoritos = 5f;

    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerMeteoritos < kTiempoEntreMeteoritos) {
            timerMeteoritos += Time.deltaTime;
        } else {
            timerMeteoritos = 0f;
            CrearMeteorito();
        }
    }

    public void CrearMeteorito () {
        int indexSpawn = Mathf.FloorToInt(Random.Range(0f, 1.1f));
        indexMeteoritos = Mathf.FloorToInt(Random.Range(0f, meteoritosPool.Length - .01f));
        Instantiate(meteoritosPool [indexMeteoritos], spawnsMeteoritos[indexSpawn].transform.position, Quaternion.identity);
    }
}
