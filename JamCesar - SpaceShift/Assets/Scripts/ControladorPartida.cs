using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPartida : MonoBehaviour
{
    /*[SerializeField]
    GameObject endUI;*/
    public static ControladorPartida gameController;
    int endScore;

    [SerializeField]
    GameObject explosion, player;
    Vector3 playerPosition;
    // Start is called before the first frame update
    private void Awake () {
        gameController = this;
    }

    void Start()
    {
        //endUI.SetActive(false);
        Debug.Log("MaxScore:" + PlayerPrefs.GetInt("MaxScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinalizarPartida () 
    {
        playerPosition = player.transform.position;
        player.SetActive(false);
        Instantiate(explosion, playerPosition, Quaternion.identity);
        ScoreControlador.instanceControlador.endGame = true;
        endScore = ScoreControlador.instanceControlador.currentScore;
        if (PlayerPrefs.GetInt("MaxScore") < ScoreControlador.instanceControlador.currentScore)
        {
            PlayerPrefs.SetInt("MaxScore", ScoreControlador.instanceControlador.currentScore);
        }
        //endUI.SetActive(true);
    }
}
