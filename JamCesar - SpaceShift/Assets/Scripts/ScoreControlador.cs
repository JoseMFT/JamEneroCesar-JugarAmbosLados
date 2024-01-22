using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreControlador : MonoBehaviour
{
    public static ScoreControlador instanceControlador;
    [SerializeField]
    TextMeshProUGUI marcoPutnuacion;
    public float velocidad = 1f;
    public float puntuacionJugador = 0f;
    float timerSumarPuntos = 1f, puntosPorTiempo = 100f;
    int puntuacionReal = 0;
    int currentScore = 0, prevScore = 0;

    // Start is called before the first frame update

    private void Awake () {
        instanceControlador = this;
    }
    void Start()
    {
        CambiarPutuacionTexto();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = puntuacionReal;

        puntuacionJugador += Time.deltaTime;
        puntuacionReal = Mathf.FloorToInt(puntuacionJugador);

        if (velocidad < 2f) {
            if (Mathf.Approximately(puntuacionJugador % 60f, 0f) == true) {
                velocidad += .1f;
            }
        }

        if (prevScore != currentScore) {
            CambiarPutuacionTexto();
        }
        prevScore = currentScore;
    }

    public void CambiarPutuacionTexto () {
        marcoPutnuacion.text = "Score: " + currentScore.ToString();
    }
}
