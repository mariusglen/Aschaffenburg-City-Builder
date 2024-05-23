using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int PopulationCount;
    public int MaxPopulation;
    public int MinPopulation;
    public int PopulationGrowth;
    public int WorkingPopulation;
    public int storage_wood, storage_stone, storage_iron, storage_money, storage_culture; //Tracks global storage
    public int upkeep_wood, upkeep_stone, upkeep_iron, upkeep_money, upkeep_culture;  //Tracks global Upkeep
    public int production_wood, production_stone, production_iron, production_money, production_culture; //Tracks global Production


    public GameData(resourceController resource)
    {
        /* PopulationCount = population.PopulationCount;
        MaxPopulation = population.MaxPopulation;
        MinPopulation = population.MinPopulation;
        PopulationGrowth = population.PopulationGrowth;
        WorkingPopulation = population.WorkingPopulation;*/
        storage_wood = resource.storage_wood;
        storage_stone = resource.storage_stone;
        storage_iron = resource.storage_iron;
        storage_money = resource.storage_money;
        storage_culture = resource.storage_culture;
        upkeep_wood = resource.upkeep_wood;
        upkeep_stone = resource.upkeep_stone;
        upkeep_iron = resource.upkeep_iron;
        upkeep_money = resource.upkeep_money;
        upkeep_culture = resource.upkeep_culture;
        production_wood = resource.production_wood;
        production_stone = resource.production_stone;
        production_iron = resource.production_iron;
        production_money = resource.production_money;
        production_culture = resource.production_culture;
    }
}