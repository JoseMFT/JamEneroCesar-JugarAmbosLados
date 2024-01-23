using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private GameObject options;

    public void OpenOptions()
    {
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
    }
}
