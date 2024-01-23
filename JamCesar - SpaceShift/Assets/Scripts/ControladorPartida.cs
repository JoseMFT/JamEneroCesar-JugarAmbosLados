using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPartida : MonoBehaviour
{
    /*[SerializeField]
    GameObject endUI;*/
    AudioSource audioMorirJugador;
    public static ControladorPartida gameController;
    int endScore;

    [SerializeField]
    GameObject explosion, player;
    Vector3 playerPosition;
    // Start is called before the first frame update

    IEnumerator IrAlFinal () {
        yield return new WaitForSeconds(1f);
        Cursor.visible = true;
        SceneManager.LoadScene(2);
    }
    private void Awake () {
        audioMorirJugador = player.GetComponent<AudioSource>();
        audioMorirJugador.playOnAwake = true;
        audioMorirJugador.enabled = false;
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
        audioMorirJugador.enabled = true;
        playerPosition = player.transform.position;
        player.SetActive(false);
        Instantiate(explosion, playerPosition, Quaternion.identity);
        ScoreControlador.instanceControlador.endGame = true;
        endScore = ScoreControlador.instanceControlador.currentScore;
        if (PlayerPrefs.GetInt("MaxScore") < ScoreControlador.instanceControlador.currentScore)
        {
            PlayerPrefs.SetInt("MaxScore", ScoreControlador.instanceControlador.currentScore);
        }
        StartCoroutine("IrAlFinal");
        //endUI.SetActive(true);
    }
}
