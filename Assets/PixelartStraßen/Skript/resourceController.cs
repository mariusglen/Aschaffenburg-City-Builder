using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq.Expressions;

public class resourceController : MonoBehaviour
{
    public double storage_wood, storage_stone, storage_iron, storage_money, storage_culture; //Tracks global storage
    public double upkeep_wood, upkeep_stone, upkeep_iron, upkeep_money, upkeep_culture;  //Tracks global Upkeep
    public double production_wood, production_stone, production_iron, production_money, production_culture; //Tracks global Production
    public double capacity_wood, capacity_stone, capacity_iron, capacity_money, capacity_culture; //Resource Capacity
    public TextMeshProUGUI wood, stone, iron, money, culture;
    public populationController population_controller;

    //Saving System
    /*
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
    */
    // Start is called before the first frame update
    void Start()
    {
        Check_UI();
        StartCoroutine(UpdateResources());
    }

    IEnumerator UpdateResources()
    {
        while (true)
        {
            Debug.Log("Resource_Update");
            // do Resource calculation here
            string Happyness = population_controller.check_happyness();
            double multiplier;

            if(Happyness == "Very_Happy")
            {
                multiplier = 2;
            }
            else if (Happyness == "Happy")
            {
                multiplier = 1.5;
            }
            else if (Happyness == "Content")
            {
                multiplier = 1;
            }
            else if (Happyness == "Sad")
            {
                multiplier = 0.75;
            }
            else
            {
                multiplier = 0.5;
            }

            Debug.Log(Happyness + "  mult: " + multiplier);
            
            ResourceCalculation(multiplier);
            Check_storage();
            Check_production();
            Check_upkeep();
            Check_Capacity_Overflow();
            Check_UI();

            yield return new WaitForSeconds(10);
        }
    }

    void ResourceCalculation(double happiness_mod)
    {
        //calculates the increase / decrease of Resources in regular intervals
        change_money((production_money * happiness_mod) - upkeep_money);
        change_iron((production_iron * happiness_mod) - upkeep_iron);
        change_wood((production_wood * happiness_mod) - upkeep_wood);
        change_stone((production_stone * happiness_mod) - upkeep_stone);
        change_culture(production_culture - upkeep_culture);
    }

    public void change_wood_cap(double capincrease)
    {
        capacity_wood += capincrease;
    }

    public void change_stone_cap(double capincrease)
    {
        capacity_stone += capincrease;
    }
    public void change_iron_cap(double capincrease)
    {
        capacity_iron += capincrease;
    }
    public void change_money_cap(double capincrease)
    {
        capacity_money += capincrease;
    }
    public void change_culture_cap(double capincrease)
    {
        capacity_culture += capincrease;
    }
    public void change_wood(double resourcechange)
    {
        storage_wood += resourcechange;
    }

    public void change_stone(double resourcechange)
    {
        storage_stone += resourcechange;
    }

    public void change_iron(double resourcechange)
    {
        storage_iron += resourcechange;
    }

    public void change_money(double resourcechange)
    {
        storage_money += resourcechange;
    }

    public void change_culture(double resourcechange)
    {
        storage_culture += resourcechange;
    }

    public void change_upkeep_wood(double resourcechange)
    {
        upkeep_wood += resourcechange;
    }

    public void change_upkeep_stone(double resourcechange)
    {
        upkeep_stone += resourcechange;
    }

    public void change_upkeep_iron(double resourcechange)
    {
        upkeep_iron += resourcechange;
    }

    public void change_upkeep_money(double resourcechange)
    {
        upkeep_money += resourcechange;
    }

    public void change_upkeep_culture(double resourcechange)
    {
        upkeep_culture += resourcechange;
    }

    public void change_production_wood(double resourcechange)
    {
        production_wood += resourcechange;
    }

    public void change_production_stone(double resourcechange)
    {
        production_stone += resourcechange;
    }

    public void change_production_iron(double resourcechange)
    {
        production_iron += resourcechange;
    }

    public void change_production_money(double resourcechange)
    {
        production_money += resourcechange;
    }

    public void change_production_culture(double resourcechange)
    {
        production_culture += resourcechange;
    }

    public void set_upkeep_culture(double upkeep_culture_change)
    {
        upkeep_culture = upkeep_culture_change;  
    }


    public double get_wood()
    {
        return storage_wood;
    }

    public double get_stone()
    {
        return storage_stone;
    }

    public double get_iron()
    {
        return storage_iron;
    }

    public double get_money()
    {
        return storage_money; 
    }

    public double get_culture()
    {
        return storage_culture;
    }

    public double get_culture_upkeep()
    {
        return upkeep_culture;
    }

    public double get_culture_production()
    {
        return production_culture;
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

    public void Check_Capacity_Overflow()
    {
        if(storage_wood > capacity_wood)
        {
            storage_wood = capacity_wood;
        }
        if (storage_stone > capacity_stone)
        {
            storage_stone = capacity_stone;
        }
        if (storage_iron > capacity_iron)
        {
            storage_iron = capacity_iron;
        }
        if (storage_money > capacity_money)
        {
            storage_money = capacity_money;
        }
        if (storage_culture > capacity_culture)
        {
            storage_culture = capacity_culture;
        }
    }

    public void Check_UI()
    {
        Debug.Log("Checking_UI");

        wood.SetText(storage_wood.ToString() + " / " + capacity_wood.ToString());
        stone.SetText(storage_stone.ToString() + " / " + capacity_stone.ToString());
        iron.SetText(storage_iron.ToString() + " / " + capacity_iron.ToString());
        money.SetText(storage_money.ToString() + " €" + " / " + capacity_money.ToString() + " €");
        culture.SetText(storage_culture.ToString() + " / " + capacity_culture.ToString());
    }

}
