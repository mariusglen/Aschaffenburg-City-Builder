using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestResource : MonoBehaviour
{
    private GameObject resourceController;
    public int PopulationCapIncrease;
    public int price_wood, price_stone, price_iron, price_money, price_worker;
    public int upkeep_wood, upkeep_stone, upkeep_iron, upkeep_money;
    public int production_wood, production_stone, production_iron, production_money, production_culture;
    void Start()
    {
        resourceController = GameObject.Find("resourceController");
        production_wood = 100;
        upkeep_wood = 20;
        adjuststorage();
        adjustproduction();
        adjustupkeep();
    }

    void adjuststorage()
    {
        resourceController resourcecontroller = (resourceController)resourceController.GetComponent("resourceController");
        resourcecontroller.change_wood(price_wood);
        resourcecontroller.change_stone(price_stone);
        resourcecontroller.change_iron(price_iron);
        resourcecontroller.change_money(price_money);
        resourcecontroller.change_wood_cap(100);
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
}
