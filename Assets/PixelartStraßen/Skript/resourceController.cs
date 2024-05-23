using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceController : MonoBehaviour
{
    public int storage_wood, storage_stone, storage_iron, storage_money, storage_culture; //Tracks global storage
    public int upkeep_wood, upkeep_stone, upkeep_iron, upkeep_money, upkeep_culture;  //Tracks global Upkeep
    public int production_wood, production_stone, production_iron, production_money, production_culture; //Tracks global Production


    //Saving System
    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        storage_wood = data.storage_wood;
        storage_stone = data.storage_stone;
        storage_iron = data.storage_iron;
        storage_money = data.storage_money;
        storage_culture = data.storage_culture;
        upkeep_wood = data.upkeep_wood;
        upkeep_stone = data.upkeep_stone;
        upkeep_iron = data.upkeep_iron;
        upkeep_money = data.upkeep_money;
        upkeep_culture = data.upkeep_culture;
        production_wood = data.production_wood;
        production_stone = data.production_stone;
        production_iron = data.production_iron;
        production_money = data.production_money;
        production_culture = data.production_culture;
    }

    // Start is called before the first frame update
    void Start()
    {
        storage_culture = 0;
        storage_iron = 0;
        storage_wood = 0;
        storage_stone = 0;
        storage_money = 0;
        StartCoroutine(UpdateResources());
    }

    IEnumerator UpdateResources()
    {
        while (true)
        {
            Debug.Log("Resource_Update");
            // do Resource calculation here
            ResourceCalculation();
            Check_storage();
            Check_production();
            Check_upkeep();
            yield return new WaitForSeconds(10);
        }
    }

    void ResourceCalculation()
    {
        //calculates the increase / decrease of Resources in regular intervals
        change_money(production_money - upkeep_money);
        change_iron(production_iron - upkeep_iron);
        change_wood(production_wood - upkeep_wood);
        change_stone(production_stone - upkeep_stone);
        change_culture(production_culture - upkeep_culture);
    }

    public void change_wood(int resourcechange)
    {
        storage_wood += resourcechange;
    }

    public void change_stone(int resourcechange)
    {
        storage_stone += resourcechange;
    }

    public void change_iron(int resourcechange)
    {
        storage_iron += resourcechange;
    }

    public void change_money(int resourcechange)
    {
        storage_money += resourcechange;
    }

    public void change_culture(int resourcechange)
    {
        storage_culture += resourcechange;
    }

    public void change_upkeep_wood(int resourcechange)
    {
        upkeep_wood += resourcechange;
    }

    public void change_upkeep_stone(int resourcechange)
    {
        upkeep_stone += resourcechange;
    }

    public void change_upkeep_iron(int resourcechange)
    {
        upkeep_iron += resourcechange;
    }

    public void change_upkeep_money(int resourcechange)
    {
        upkeep_money += resourcechange;
    }

    public void change_upkeep_culture(int resourcechange)
    {
        upkeep_culture += resourcechange;
    }

    public void change_production_wood(int resourcechange)
    {
        production_wood += resourcechange;
    }

    public void change_production_stone(int resourcechange)
    {
        production_stone += resourcechange;
    }

    public void change_production_iron(int resourcechange)
    {
        production_iron += resourcechange;
    }

    public void change_production_money(int resourcechange)
    {
        production_money += resourcechange;
    }

    public void change_production_culture(int resourcechange)
    {
        production_culture += resourcechange;
    }

    public int get_wood()
    {
        return storage_wood;
    }

    public int get_stone()
    {
        return storage_stone;
    }

    public int get_iron()
    {
        return storage_iron;
    }

    public int get_money()
    {
        return storage_money; 
    }

    public int get_culture()
    {
        return storage_culture;
    }

    public void Check_storage()
    {
        Debug.Log(
            "Storage: "
            + " Holz: "
            + storage_wood
            + " Stein: "
            + storage_stone
            + " Eisen: "
            + storage_iron
            + " Geld: "
            + storage_money
            + " Kultur: "
            + storage_culture);
    }

    public void Check_production()
    {
        Debug.Log(
            " Production: "
            + " Holz: " 
            + production_wood
            + " Stein: "
            + production_stone
            + " Eisen: "
            + production_iron
            + " Geld: "
            + production_money
            + " Kultur: "
            + production_culture);
    }

    public void Check_upkeep()
    {
        Debug.Log(
            " Upkeep: "
            + " Holz: "
            + upkeep_wood
            + " Stein: "
            + upkeep_stone
            + " Eisen: "
            + upkeep_iron
            + " Geld: "
            + upkeep_money
            + " Kultur: "
            + upkeep_culture);
    }
}
