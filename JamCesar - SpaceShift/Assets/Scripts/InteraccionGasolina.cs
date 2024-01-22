using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionGasolina : MonoBehaviour
{
    public float gasolina = 100;
    public float gasolinaSpeed = 4;
    public float recargaGasolina = 10;
    public bool pierdeGasolina = true;
    public float delayGasolina = 0.5f;

    private void Update()
    {
        gasolina = Mathf.Clamp(gasolina, 0, 100);
        if (pierdeGasolina == true)
        {
            gasolina -= Time.deltaTime * gasolinaSpeed;
        }
        //MuertePorFaltaDeGasolina:
        if (gasolina < 0)
        {
            Debug.Log("NaveExplota");
        } 
        Debug.Log(gasolina);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "gasolina")
        {
            gasolina -= Time.deltaTime;
            if (delayGasolina != 0.5)
            {
                gasolina = gasolina + recargaGasolina;
                delayGasolina = 0.5f;
            }
        }
    }
}
