using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class Building : MonoBehaviour
{
    public bool Placed { get; private set; }
    public BoundsInt area;
    public int PopulationCapIncrease;
    public double price_wood, price_stone, price_iron, price_money, price_worker;
    public double upkeep_wood, upkeep_stone, upkeep_iron, upkeep_money;
    public double production_wood, production_stone, production_iron, production_money, production_culture;
    public double cap_wood, cap_stone, cap_iron, cap_money, cap_culture;
    private GameObject populationController;
    private GameObject resourceController;    
    public String unique_name;
    public Boolean isunique;
    private GameObject Button;

    #region Build Methods
    private void Awake()
    {
        populationController = GameObject.Find("populationController");
        resourceController = GameObject.Find("resourceController");
        Button = GameObject.Find(unique_name);
    }
    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

            if (GridBuildingSystem.current.CanTakeArea(areaTemp) /*&& GridBuildingSystem.current.StreetDetector(areaTemp)*/)
            {
                return true;
            }
            return false;
    }
    public bool StreetCanBePlaced()
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
        populationController populationcontroller = (populationController)populationController.GetComponent("populationController");
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.current.TakeArea(areaTemp);
        populationcontroller.ChangeMaxPopulation(PopulationCapIncrease);
        populationcontroller.ChangeWorkingPopulation((int)price_worker);
        if (isunique)
        {
            Button.SetActive(false);
        }
        //New modifier to allow negative adjustments: please only use 1/-1
        //adjusts storage for the cost of the building
        adjuststorage(1);
        //adjusts the global production of goods
        adjustproduction(1);
        //adjusts the global upkeep of goods
        adjustupkeep(1);
    }        
    public void StreetPlace()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;
        Placed = true;
        GridBuildingSystem.current.StreetTakeArea(areaTemp);
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            GameObject.Destroy(gameObject);            
            if(isunique)
            {
                Debug.Log(Button);
                Button.SetActive(true);
            }
            GridBuildingSystem.current.ClearArea();
            adjuststorage(-1);
            adjustproduction(-1);
            adjustupkeep(-1);
        }
    }
    void adjuststorage(int modifier)
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_wood(price_wood * modifier);
        resourcecontroller.change_stone(price_stone * modifier);
        resourcecontroller.change_iron(price_iron * modifier);
        resourcecontroller.change_money(price_money * modifier);
    }
    void adjustproduction(int modifier)
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_production_culture(production_culture * modifier);
        resourcecontroller.change_production_iron(production_iron * modifier);
        resourcecontroller.change_production_money(production_money * modifier);
        resourcecontroller.change_production_stone(production_stone * modifier);
        resourcecontroller.change_production_wood(production_wood * modifier);
    }
    void adjustupkeep(int modifier)
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_upkeep_iron(upkeep_iron * modifier);
        resourcecontroller.change_upkeep_money(upkeep_money * modifier);
        resourcecontroller.change_upkeep_stone(upkeep_stone * modifier);
        resourcecontroller.change_upkeep_wood(upkeep_wood * modifier);
    }
    void adjustcapacity(int modifier)
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_iron_cap(cap_iron * modifier);
        resourcecontroller.change_money_cap(cap_money * modifier);
        resourcecontroller.change_stone_cap(cap_stone * modifier);
        resourcecontroller.change_wood_cap(cap_wood * modifier);
        resourcecontroller.change_culture_cap(cap_culture * modifier);
    }

    Boolean canbebought()
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");

        
    }
    #endregion
}