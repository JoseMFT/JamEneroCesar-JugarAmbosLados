using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPartida : MonoBehaviour
{
    public static ControladorPartida gameController;
    // Start is called before the first frame update
    private void Awake () {
        gameController = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinalizarPartida () {
    }
}