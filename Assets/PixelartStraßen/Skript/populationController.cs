using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class populationController : MonoBehaviour
{   
    public int PopulationCount;
    public int MaxPopulation;
    public int MinPopulation;
    public int PopulationGrowth;
    public int WorkingPopulation;
    private resourceController resourceController;
 


    void Start()
    {
        MinPopulation = 0;
        StartCoroutine(UpdatePopulation());

    }

    public void ChangeMaxPopulation(int change)
    {
        MaxPopulation = MaxPopulation + change;
        resourceController.change_upkeep_culture(change);
    }

    public void ChangeWorkingPopulation(int change)
    {
       WorkingPopulation = WorkingPopulation + change;
    }

    IEnumerator UpdatePopulation()
    {
        while (true)
        {
            // do population calc here
            PopCalc();
            yield return new WaitForSeconds(10);
        }
    }

    void PopCalc()
    {
        PopulationGrowth = (int) (400/((MaxPopulation - PopulationCount) * 1/2) + 50);
        PopulationCount += PopulationGrowth;
        WorkingPopulation += PopulationGrowth;
    }
}
