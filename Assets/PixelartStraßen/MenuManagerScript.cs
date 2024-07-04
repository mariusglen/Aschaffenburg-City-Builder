using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerScript : MonoBehaviour
{
    public Canvas PauseMenu;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.gameObject.SetActive(!PauseMenu.gameObject.activeSelf);
        }
    }
}
