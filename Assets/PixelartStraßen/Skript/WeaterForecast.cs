using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaterForecast : MonoBehaviour
{
    public GameObject Rain_1;
    public GameObject Rain_2;
    public GameObject Snow_1;
    public GameObject Snow_2;
    public GameObject Snow_3;
    public int counter = 0;

    void Start()
    {
        StartCoroutine(UpdateWeather());
    }

    IEnumerator UpdateWeather()
    {
        
        while (true)
        {   
            if(counter % 4 == 0)
            {
                Snow_1.SetActive(true);
                Snow_2.SetActive(true);
                Snow_3.SetActive(true);
                counter++;
            }
            else
            {
                Rain_1.SetActive(true);
                Rain_2.SetActive(true);
            }

            counter++;
            yield return new WaitForSeconds(50);
        };


    }
}
