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
    int puntuacionReal = 0;
    public int currentScore = 0, prevScore = 0;

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

        puntuacionJugador += Time.deltaTime * 1.25f;
        puntuacionReal = Mathf.FloorToInt(puntuacionJugador);

        if (velocidad < 2f) {
            velocidad = 1 + puntuacionJugador / 2000f;
        }

        if (prevScore != currentScore) {
            CambiarPutuacionTexto();
        }
        prevScore = currentScore;
    }

    public void CambiarPutuacionTexto () {
        UnityEngine.Debug.Log(velocidad.ToString());
        marcoPutnuacion.text = "Score: " + currentScore.ToString();
    }
}
