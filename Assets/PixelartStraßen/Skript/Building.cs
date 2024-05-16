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

    private GameObject populationController;
    private GameObject resourceController;


    #region Build Methods
    private void Awake()
    {
        populationController =  GameObject.Find("populationController");
        resourceController =    GameObject.Find("resourceController");
    }


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
        populationController populationcontroller = (populationController) populationController.GetComponent("populationController");

        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.current.TakeArea(areaTemp);
        populationcontroller.ChangeMaxPopulation(PopulationCapIncrease);
        populationcontroller.ChangeWorkingPopulation(price_worker);

        //adjusts storage for the cost of the building
        adjuststorage();
        //adjusts the global production of goods
        adjustproduction();
        //adjusts the global upkeep of goods
        adjustupkeep();

    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            GameObject.Destroy(gameObject);
        }
    }

    void adjuststorage()
    {
        resourceController resourcecontroller = (resourceController) resourceController.GetComponent("resourceController");
        resourcecontroller.change_wood(price_wood);
        resourcecontroller.change_stone(price_stone);
        resourcecontroller.change_iron(price_iron);
        resourcecontroller.change_money(price_money);
    }

    void adjustproduction()
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_production_culture(production_culture);
        resourcecontroller.change_production_iron(production_iron);
        resourcecontroller.change_production_money(production_money);
        resourcecontroller.change_production_stone(production_stone);
        resourcecontroller.change_production_wood(production_wood);
    }

    void adjustupkeep()
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_upkeep_iron(upkeep_iron);
        resourcecontroller.change_upkeep_money(upkeep_money);
        resourcecontroller.change_upkeep_stone(upkeep_stone);
        resourcecontroller.change_upkeep_wood(upkeep_wood);
    }

    #endregion
}
