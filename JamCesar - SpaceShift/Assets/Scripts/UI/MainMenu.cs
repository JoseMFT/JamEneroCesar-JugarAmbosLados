using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region VARIABLES

    [Header("GameObjects")]
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject text_tittle;
    [SerializeField] private GameObject button_Play;
    [SerializeField] private GameObject button_Options;
    [SerializeField] private GameObject button_Credits;
    [SerializeField] private GameObject button_Exit;
    [SerializeField] private GameObject menu_Options;
    [SerializeField] private GameObject menu_Credits;

    #endregion

    #region METHODS

    private void Start()
    {
        background.SetActive(true);
        text_tittle.SetActive(true);
        
        menu_Options.SetActive(false);
        menu_Credits.SetActive(false);

        //Animation Tittle

        EntryButtons();
    }

    private void EntryButtons()
    {
        button_Play.SetActive(true);
        button_Options.SetActive(true);
        button_Credits.SetActive(true);
        button_Exit.SetActive(true);

        menu_Options.SetActive(false);
        menu_Credits.SetActive(false);
        //Animation Buttons
    }

    private void ExitButtons()
    {
        button_Play.SetActive(false);
        button_Options.SetActive(false);
        button_Credits.SetActive(false);
        button_Exit.SetActive(false);
    }

    public void EntryOptions()
    {
        ExitButtons();
        menu_Options.SetActive(true);
        //Animation Options
    }

    public void EntryCredits()
    {
        ExitButtons();
        menu_Credits.SetActive(true);
        //Animation Credits
    }

    #endregion
}
