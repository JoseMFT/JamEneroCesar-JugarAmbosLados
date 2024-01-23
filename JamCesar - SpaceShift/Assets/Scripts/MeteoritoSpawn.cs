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
        timerMeteoritos = FloatAleatorio (.3f, 3.5f - ScoreControlador.instanceControlador.velocidad);
    }

    // Update is called once per frame
    void Update()
    {
        if (OptionUI.instanceOpciones.isPaused == false) {
            if (timerMeteoritos > 0f) {
                timerMeteoritos -= Time.deltaTime;
            } else {
                timerMeteoritos = FloatAleatorio(1f, 3.5f - ScoreControlador.instanceControlador.velocidad);
                CrearMeteorito();
            }
        }
    }

    public void CrearMeteorito () {
        int indexSpawn = IntAleatorio(0f, 1.99f);
        indexMeteoritos = IntAleatorio(0f, meteoritosPool.Length - .01f);
        Instantiate(meteoritosPool [indexMeteoritos], spawnsMeteoritos[indexSpawn].transform.position, new Quaternion (FloatAleatorio(0f, 1f), FloatAleatorio(0f, 1f), FloatAleatorio (0f, 1f), FloatAleatorio(0f, 1f)));
    }

    public float FloatAleatorio (float valMin, float valMax) {
        float x;
        x = Random.Range(valMin, valMax);
        return x;
    }

    public int IntAleatorio (float valMin, float valMax) {
        int x;
        x = Mathf.FloorToInt(FloatAleatorio(valMin, valMax));
        return x;
    }
}
