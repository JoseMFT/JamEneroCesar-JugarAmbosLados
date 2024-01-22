using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisparos : MonoBehaviour
{
    [SerializeField]
    GameObject [] laseres;
    public GameObject spawnLaseres;

    int indexLaseres = 0;
    const float tiempoParaEspacio = .33f;
    float timerEspacio = 0f;
    bool puedeDisparar = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puedeDisparar == true) {

            if (Input.GetKey(KeyCode.Space)) {
                puedeDisparar = false;
                DispararLaser();
            }
        } else {
            if (timerEspacio < tiempoParaEspacio) {
                timerEspacio += Time.deltaTime;
            } else {
                timerEspacio = 0f;
                puedeDisparar = true;
            }
        }
    }

    public void DispararLaser () {

        if (indexLaseres < laseres.Length - 1) {
            indexLaseres++;
        } else {
            indexLaseres = 0;
        }

        laseres [indexLaseres].SetActive(true);
        laseres [indexLaseres].transform.position = spawnLaseres.transform.position;
    }
}
