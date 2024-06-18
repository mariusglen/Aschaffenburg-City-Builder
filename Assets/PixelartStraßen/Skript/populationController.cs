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
    public resourceController resourceController;
    public Happyness Population_Satisfaction;

    void Start()
    {
        MinPopulation = 0;
        StartCoroutine(UpdatePopulation());
    }

    public void ChangeMaxPopulation(int change)
    {
        MaxPopulation = MaxPopulation + change;
        //resourceController.change_upkeep_culture(change);
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

    public string check_happyness()
    {
        return Population_Satisfaction.ToString();
    }

    void PopCalc()
    {
        PopulationGrowth = (int) (400/((MaxPopulation - PopulationCount) * 1/2 +1) + 50);
        PopulationCount += PopulationGrowth;
        WorkingPopulation += PopulationGrowth;

        if(PopulationCount > MaxPopulation ) PopulationCount = MaxPopulation;
        resourceController.set_upkeep_culture((double)PopulationCount);

        double culture_storage, culture_upkeep, culture_production;
        culture_storage = resourceController.get_culture();
        culture_upkeep = resourceController.get_culture_upkeep();
        culture_production = resourceController.get_culture_production();

        if((culture_storage + culture_production) > 1.5 * culture_upkeep)
        {
            Population_Satisfaction = Happyness.Very_Happy;
        }
        else if((culture_storage + culture_production) > 1 * culture_upkeep)
        {
            Population_Satisfaction = Happyness.Happy;
        }
        else if((culture_storage + culture_production) > 0.75 * culture_upkeep)
        {
            Population_Satisfaction = Happyness.Content;
        }
        else if((culture_storage + culture_production) > 0.5 * culture_upkeep)
        {
            Population_Satisfaction = Happyness.Sad;
        }
        else
        {
            Population_Satisfaction = Happyness.Depressed;
        }
    }
}

public enum Happyness
    {
        Very_Happy, //2x
        Happy, //1.5x
        Content, // 1x
        Sad, // 0.75x
        Depressed // 0.5x
    }