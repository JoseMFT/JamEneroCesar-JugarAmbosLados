using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPartida : MonoBehaviour
{
    /*[SerializeField]
    GameObject endUI;*/
    public static ControladorPartida gameController;
    int endScore;
    // Start is called before the first frame update
    private void Awake () {
        
        gameController = this;
    }

    void Start()
    {
        Time.timeScale = 1.0f;
        //endUI.SetActive(false);
        Debug.Log("MaxScore:" + PlayerPrefs.GetInt("MaxScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinalizarPartida () 
    {
        Time.timeScale = 0f;
        endScore = ScoreControlador.instanceControlador.currentScore;
        if (PlayerPrefs.GetInt("MaxScore") < ScoreControlador.instanceControlador.currentScore)
        {
            PlayerPrefs.SetInt("MaxScore", ScoreControlador.instanceControlador.currentScore);
        }
        //endUI.SetActive(true);
    }
}
