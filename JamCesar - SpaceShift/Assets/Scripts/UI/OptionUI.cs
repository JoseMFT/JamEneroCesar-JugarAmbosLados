using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionUI : MonoBehaviour
{
    public static OptionUI instanceOpciones;
    [SerializeField] private GameObject options;
    bool opcionesAbiertas = false;
    public bool isPaused;


    private void Awake () {
        instanceOpciones = this;
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Partida copia") {
            opcionesAbiertas = !opcionesAbiertas;

            if (opcionesAbiertas == true) {
                isPaused = true;
                Time.timeScale = 0;
                OpenOptions();
                Cursor.visible = true;
            } else if (opcionesAbiertas == false) {
                CloseOptions();
                Time.timeScale = 1f;
                isPaused = false;
                Cursor.visible = false;
            }
        }
    }

    public void OpenOptions()
    {
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
    }
}
