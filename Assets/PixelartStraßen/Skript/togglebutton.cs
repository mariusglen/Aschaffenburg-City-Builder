using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class togglebutton : MonoBehaviour
{
    public GameObject ToggleButton;
    // Start is called before the first frame update
    void Start()
    {
        if (ToggleButton  != null)
        {
            bool isActive = ToggleButton.activeSelf;
            ToggleButton.SetActive(isActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
