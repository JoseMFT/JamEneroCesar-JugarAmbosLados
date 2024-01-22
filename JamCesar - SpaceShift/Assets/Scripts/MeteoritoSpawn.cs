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

    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        timerMeteoritos = Random.Range(.3f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerMeteoritos > 0f) {
            timerMeteoritos -= Time.deltaTime;
        } else {
            timerMeteoritos = Random.Range (1f, 5f);
            CrearMeteorito();
        }
    }

    public void CrearMeteorito () {
        int indexSpawn = Mathf.FloorToInt(Random.Range(0f, 1.99f));
        indexMeteoritos = Mathf.FloorToInt(Random.Range(0f, meteoritosPool.Length - .01f));
        Instantiate(meteoritosPool [indexMeteoritos], spawnsMeteoritos[indexSpawn].transform.position, Quaternion.identity);
    }
}
