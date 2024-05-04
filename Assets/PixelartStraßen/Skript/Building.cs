using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Building : MonoBehaviour
{
    public  bool Placed { get; private set; }
    public BoundsInt area;
    public int PopulationCapIncrease;
    public int price_wood, price_stone, price_iron, price_money, price_worker;
    public int upkeep_wood, upkeep_stone, upkeep_iron, upkeep_money;
    public int production_wood, production_stone, production_iron, production_money, production_culture;
    private populationController populationController;
    private resourceController resourceController;
    
    #region Build Methods

    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if (GridBuildingSystem.current.CanTakeArea(areaTemp))
        {
            return true;
        }

        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.current.TakeArea(areaTemp);
        populationController.ChangeMaxPopulation(PopulationCapIncrease);
        populationController.ChangeWorkingPopulation(price_worker);

        //adjusts storage for the cost of the building
        adjuststorage();
        //adjusts the global production of goods
        adjustproduction();
        //adjusts the global upkeep of goods
        adjustupkeep();

    }

    void adjuststorage()
    {
        resourceController.change_wood(price_wood);
        resourceController.change_stone(price_stone);
        resourceController.change_iron(price_iron);
        resourceController.change_money(price_money);
    }

    void adjustproduction()
    {
        resourceController.change_production_culture(production_culture);
        resourceController.change_production_iron(production_iron);
        resourceController.change_production_money(production_money);
        resourceController.change_production_stone(production_stone);
        resourceController.change_production_wood(production_wood);
    }

    void adjustupkeep()
    {
        resourceController.change_upkeep_iron(upkeep_iron);
        resourceController.change_upkeep_money(upkeep_money);
        resourceController.change_upkeep_stone(upkeep_stone);
        resourceController.change_upkeep_wood(upkeep_wood);
    }

    #endregion
}
