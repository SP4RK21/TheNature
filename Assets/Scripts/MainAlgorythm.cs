using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainAlgorythm : MonoBehaviour
{



    InfoHolder holder;
    public int starting_goal = 1000;
    public int staring_state = 1000;
    public int staring_price = 100;

    public Dictionary<string, int> game_info = new Dictionary<string, int>();
    
    public long population = 7512421267;
    public int energy = 0;
    private System.DateTime currentDate;
    private int water_animals_good = 0;
    private int water_composition_good = 0;
    private int water_cycle_good = 0;
    private int air_composition_good = 0;
    private int air_winds_good = 0;
    private int air_temperature_good = 0;
    private int plants_photosynthesis_good = 0;
    private int plants_spreading_good = 0;
    private int plants_soil_good = 0;
    private int animals_survival_good = 0;
    private int animals_immunity_good = 0;
    private int animals_reproduction_good = 0;

    public int AmountOfEvents;
    int temp;

    [HideInInspector]public GameObject waterButton;
    [HideInInspector]public GameObject airButton;
    [HideInInspector]public GameObject plantsButton;
    [HideInInspector]public GameObject animalsButton;

    public  bool AnimalsAffected;
    public  bool PlantsAffected;
    public  bool WaterAffected;
    public  bool AirAffected;

    public Color waterButtonColor;
    public Color airButtonColor;
    public Color plantsButtonColor;
    public Color animalsButtonColor;

    public int growFallSpeed = 2;
    public int possible_difference = 0;
    public float timeToAffect;

    public UnityEngine.UI.Text text_energy;
    public UnityEngine.UI.Text text_population;
    public UnityEngine.UI.Text curDate;
    [HideInInspector]public bool gameWon = false;

    GameObject earth;


    [HideInInspector]public GameObject[] ShowedEvents;
    [HideInInspector]public bool[] FixedEvents;
    public int current_index = -1;
    [HideInInspector]public List<Dictionary<string, int>> EventsEffect = new List<Dictionary<string, int>>();

    private IEnumerator[] coroutine_water = new IEnumerator[6];
    private IEnumerator[] coroutine_air = new IEnumerator[6];
    private IEnumerator[] coroutine_plants = new IEnumerator[6];
    private IEnumerator[] coroutine_animals = new IEnumerator[6];



    void Start()
    {
        ShowedEvents = new GameObject[AmountOfEvents];
        FixedEvents = new bool[AmountOfEvents];

        game_info.Add("goal_water_animals", starting_goal);
        game_info.Add("goal_water_composition", starting_goal);
        game_info.Add("goal_water_cycle", starting_goal);
        game_info.Add("goal_air_composition", starting_goal);
        game_info.Add("goal_air_winds", starting_goal);
        game_info.Add("goal_air_temperature", starting_goal);
        game_info.Add("goal_plants_photosynthesis", starting_goal);
        game_info.Add("goal_plants_spreading", starting_goal);
        game_info.Add("goal_plants_soil", starting_goal);
        game_info.Add("goal_animals_survival", starting_goal);
        game_info.Add("goal_animals_immunity", starting_goal);
        game_info.Add("goal_animals_reproduction", starting_goal);
        game_info.Add("water_animals", starting_goal);
        game_info.Add("water_composition", starting_goal);
        game_info.Add("water_cycle", starting_goal);
        game_info.Add("air_composition", starting_goal);
        game_info.Add("air_winds", starting_goal);
        game_info.Add("air_temperature", starting_goal);
        game_info.Add("plants_photosynthesis", starting_goal);
        game_info.Add("plants_spreading", starting_goal);
        game_info.Add("plants_soil", starting_goal);
        game_info.Add("animals_survival", starting_goal);
        game_info.Add("animals_immunity", starting_goal);
        game_info.Add("animals_reproduction", starting_goal);
        game_info.Add("animals", staring_state);
        game_info.Add("plants", staring_state);
        game_info.Add("air", staring_state);
        game_info.Add("water", staring_state);

        game_info.Add("water_animals_price", staring_price);
        game_info.Add("water_composition_price", staring_price);
        game_info.Add("water_cycle_price", staring_price);
        game_info.Add("air_composition_price", staring_price);
        game_info.Add("air_winds_price", staring_price);
        game_info.Add("air_temperature_price", staring_price);
        game_info.Add("plants_photosynthesis_price", staring_price);
        game_info.Add("plants_spreading_price", staring_price);
        game_info.Add("plants_soil_price", staring_price);
        game_info.Add("animals_survival_price", staring_price);
        game_info.Add("animals_immunity_price", staring_price);
        game_info.Add("animals_reproduction_price", staring_price);


        game_info.Add("hint_price", staring_price/2);

        earth = GameObject.Find("Earth");
        animalsButtonColor = animalsButton.GetComponent<Image>().color;
        airButtonColor = airButton.GetComponent<Image>().color;
        waterButtonColor = waterButton.GetComponent<Image>().color;
        plantsButtonColor = plantsButton.GetComponent<Image>().color;
        currentDate = System.DateTime.Today;
        InvokeRepeating("IncreaseDate", 56f, 56f);
        InvokeRepeating("IncreaseEnergy", 0f, 0.265f);
        holder = earth.GetComponent<InfoHolder>();

        act();
    }

    public void GameOver_()
    {
        if (gameWon == true)
            Application.LoadLevel("GameOver_win");
        else
            Application.LoadLevel("GameOver");
    }
    void Update()
    {
        setCondition();

        holder.water_animals_price = game_info["water_animals_price"];
        holder.water_composition_price = game_info["water_composition_price"];
        holder.water_cycle_price = game_info["water_cycle_price"];
        holder.air_composition_price = game_info["air_composition_price"];
        holder.air_winds_price = game_info["air_winds_price"];
        holder.air_temperature_price = game_info["air_temperature_price"];
        holder.plants_photosynthesis_price = game_info["plants_photosynthesis_price"];
        holder.plants_spreading_price = game_info["plants_spreading_price"];
        holder.plants_soil_price = game_info["plants_soil_price"];
        holder.animals_survival_price = game_info["animals_survival_price"];
        holder.animals_immunity_price = game_info["animals_immunity_price"];
        holder.animals_reproduction_price = game_info["animals_reproduction_price"];

        if (game_info["animals"] <= 0) game_info["animals"] = 0;
        if (game_info["water"] <= 0) game_info["water"] = 0;
        if (game_info["air"] <= 0) game_info["air"] = 0;
        if (game_info["plants"] <= 0) game_info["plants"] = 0;
        if ((game_info["air"] <= 0) || (game_info["water"] <= 0) || (game_info["animals"] <= 0) || (game_info["plants"] <= 0) || ((game_info["plants"] + game_info["animals"] + game_info["water"] + game_info["air"]) <= 2500))
        {
            
            gameWon = false;
            GameOver_();
        }

        airButton.GetComponent<Image>().color = new Color32(255, (byte)(game_info["air"] * 0.255f), (byte)(game_info["air"] * 0.255f), 255);
        animalsButton.GetComponent<Image>().color = new Color32(255, (byte)(game_info["animals"] * 0.255f), (byte)(game_info["animals"] * 0.255f), 255);
        waterButton.GetComponent<Image>().color = new Color32(255, (byte)(game_info["water"] * 0.255f), (byte)(game_info["water"] * 0.255f), 255);
        plantsButton.GetComponent<Image>().color = new Color32(255, (byte)(game_info["plants"] * 0.255f), (byte)(game_info["plants"] * 0.255f), 255);

        curDate.text = currentDate.ToString("yyyy");
        text_energy.text = energy.ToString();
        text_population.text = population.ToString();

        //CheckEvent();
    }

    public void CheckEvent()
    {
        for (int i = 0; i < EventsEffect.Count; i++)
        {
            int sum = 0;
            foreach (var item in EventsEffect[i].Keys)
            {
                sum += EventsEffect[i][item];
            }
            if (sum >= 0)
            {
                print(i);
                FixedEvents[i] = true;
            }
        }
        for (int i = 0; i < EventsEffect.Count; i++)
        {
            if (FixedEvents[i] == true)
            {
                ShowedEvents[i].GetComponent<Image>().color = new Color32(21, 255, 21, 255);
            }
        }
    }

    void IncreaseDate()
    {
        currentDate = currentDate.AddYears(1);
    }
    void IncreaseEnergy()
    {
        energy += Random.Range(2,7);
    }

    public int checkIfInRadius(int current, int goal, int radius)
    {
        int diff = Mathf.Abs(goal - current);
        if (diff >= radius)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    void setCondition()
    {
        temp = water_animals_good;
        water_animals_good = checkIfInRadius(game_info["water_animals"], game_info["goal_water_animals"], possible_difference);
        if (water_animals_good != temp) act();
        temp = water_composition_good;
        water_composition_good = checkIfInRadius(game_info["water_composition"], game_info["goal_water_composition"], possible_difference);
        if (water_composition_good != temp) act();
        temp = water_cycle_good;
        water_cycle_good = checkIfInRadius(game_info["water_cycle"], game_info["goal_water_cycle"], possible_difference);
        if (water_cycle_good != temp) act();
        temp = air_composition_good;
        air_composition_good = checkIfInRadius(game_info["air_composition"], game_info["goal_air_composition"], possible_difference);
        if (air_composition_good != temp) act();
        temp = air_winds_good;
        air_winds_good = checkIfInRadius(game_info["air_winds"], game_info["goal_air_winds"], possible_difference);
        if (air_winds_good != temp) act();
        temp = air_temperature_good;
        air_temperature_good = checkIfInRadius(game_info["air_temperature"], game_info["goal_air_temperature"], possible_difference);
        if (air_temperature_good != temp) act();
        temp = plants_photosynthesis_good;
        plants_photosynthesis_good = checkIfInRadius(game_info["plants_photosynthesis"], game_info["goal_plants_photosynthesis"], possible_difference);
        if (plants_photosynthesis_good != temp) act();
        temp = plants_spreading_good;
        plants_spreading_good = checkIfInRadius(game_info["plants_spreading"], game_info["goal_plants_spreading"], possible_difference);
        if (plants_spreading_good != temp) act();
        temp = plants_soil_good;
        plants_soil_good = checkIfInRadius(game_info["plants_soil"], game_info["goal_plants_soil"], possible_difference);
        if (plants_soil_good != temp) act();
        temp = animals_survival_good;
        animals_survival_good = checkIfInRadius(game_info["animals_survival"], game_info["goal_animals_survival"], possible_difference);
        if (animals_survival_good != temp) act();
        temp = animals_immunity_good;
        animals_immunity_good = checkIfInRadius(game_info["animals_immunity"], game_info["goal_animals_immunity"], possible_difference);
        if (animals_immunity_good != temp) act();
        temp = animals_reproduction_good;
        animals_reproduction_good = checkIfInRadius(game_info["animals_reproduction"], game_info["goal_animals_reproduction"], possible_difference);
        if (animals_reproduction_good != temp) act();
    }

    void act()
    {

        coroutine_water[0] = WaitAndDo(timeToAffect, "water", growFallSpeed);
        coroutine_water[1] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_water[2] = WaitAndDo(timeToAffect, "water", growFallSpeed);
        coroutine_water[3] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_water[4] = WaitAndDo(timeToAffect, "water", growFallSpeed);
        coroutine_water[5] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);

        coroutine_air[0] = WaitAndDo(timeToAffect, "air", growFallSpeed);
        coroutine_air[1] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_air[2] = WaitAndDo(timeToAffect, "air", growFallSpeed);
        coroutine_air[3] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_air[4] = WaitAndDo(timeToAffect, "air", growFallSpeed);
        coroutine_air[5] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);

        coroutine_animals[0] = WaitAndDo(timeToAffect, "animals", growFallSpeed);
        coroutine_animals[1] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_animals[2] = WaitAndDo(timeToAffect, "animals", growFallSpeed);
        coroutine_animals[3] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_animals[4] = WaitAndDo(timeToAffect, "animals", growFallSpeed);
        coroutine_animals[5] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);

        coroutine_plants[0] = WaitAndDo(timeToAffect, "plants", growFallSpeed);
        coroutine_plants[1] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_plants[2] = WaitAndDo(timeToAffect, "plants", growFallSpeed);
        coroutine_plants[3] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);
        coroutine_plants[4] = WaitAndDo(timeToAffect, "plants", growFallSpeed);
        coroutine_plants[5] = WaitAndDo(timeToAffect * 0.1f, "people", -growFallSpeed);

        switch (water_animals_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_water[1]);
                StopCoroutine(coroutine_water[0]);
                StartCoroutine(coroutine_water[0]);
                break;
            case 2:
                StopCoroutine(coroutine_water[0]);
                StopCoroutine(coroutine_water[1]);
                StartCoroutine(coroutine_water[1]);
                break;
            case 0:
                StopCoroutine(coroutine_water[0]);
                StopCoroutine(coroutine_water[1]);
                break;
        }
        switch (water_composition_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_water[3]);
                StopCoroutine(coroutine_water[2]);
                StartCoroutine(coroutine_water[2]);
                break;
            case 2:
                StopCoroutine(coroutine_water[2]);
                StopCoroutine(coroutine_water[3]);
                StartCoroutine(coroutine_water[3]);
                break;
            case 0:
                StopCoroutine(coroutine_water[2]);
                StopCoroutine(coroutine_water[3]);
                break;
        }
        switch (water_cycle_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_water[5]);
                StopCoroutine(coroutine_water[4]);
                StartCoroutine(coroutine_water[4]);
                break;
            case 2:
                StopCoroutine(coroutine_water[4]);
                StopCoroutine(coroutine_water[5]);
                StartCoroutine(coroutine_water[5]);
                break;
            case 0:
                StopCoroutine(coroutine_water[4]);
                StopCoroutine(coroutine_water[5]);
                break;
        }
        switch (air_composition_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_air[1]);
                StopCoroutine(coroutine_air[0]);
                StartCoroutine(coroutine_air[0]);
                break;
            case 2:
                StopCoroutine(coroutine_air[0]);
                StopCoroutine(coroutine_air[1]);
                StartCoroutine(coroutine_air[1]);
                break;
            case 0:
                StopCoroutine(coroutine_air[0]);
                StopCoroutine(coroutine_air[1]);
                break;
        }
        switch (air_winds_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_air[3]);
                StopCoroutine(coroutine_air[2]);
                StartCoroutine(coroutine_air[2]);
                break;
            case 2:
                StopCoroutine(coroutine_air[2]);
                StopCoroutine(coroutine_air[3]);
                StartCoroutine(coroutine_air[3]);
                break;
            case 0:
                StopCoroutine(coroutine_air[2]);
                StopCoroutine(coroutine_air[3]);
                break;
        }
        switch (air_temperature_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_air[5]);
                StopCoroutine(coroutine_air[4]);
                StartCoroutine(coroutine_air[4]);
                break;
            case 2:
                StopCoroutine(coroutine_air[4]);
                StopCoroutine(coroutine_air[5]);
                StartCoroutine(coroutine_air[5]);
                break;
            case 0:
                StopCoroutine(coroutine_air[4]);
                StopCoroutine(coroutine_air[5]);
                break;
        }
        switch (plants_photosynthesis_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_plants[0]);
                StopCoroutine(coroutine_plants[1]);
                StartCoroutine(coroutine_plants[0]);
                break;
            case 2:
                StopCoroutine(coroutine_plants[0]);
                StopCoroutine(coroutine_plants[1]);
                StartCoroutine(coroutine_plants[1]);
                break;
            case 0:
                StopCoroutine(coroutine_plants[0]);
                StopCoroutine(coroutine_plants[1]);
                break;
        }
        switch (plants_spreading_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_plants[3]);
                StopCoroutine(coroutine_plants[2]);
                StartCoroutine(coroutine_plants[2]);
                break;
            case 2:
                StopCoroutine(coroutine_plants[2]);
                StopCoroutine(coroutine_plants[3]);
                StartCoroutine(coroutine_plants[3]);
                break;
            case 0:
                StopCoroutine(coroutine_plants[2]);
                StopCoroutine(coroutine_plants[3]);
                break;
        }
        switch (plants_soil_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_plants[4]);
                StopCoroutine(coroutine_plants[5]);
                StartCoroutine(coroutine_plants[4]);
                break;
            case 2:
                StopCoroutine(coroutine_plants[4]);
                StopCoroutine(coroutine_plants[5]);
                StartCoroutine(coroutine_plants[5]);
                break;
            case 0:
                StopCoroutine(coroutine_plants[4]);
                StopCoroutine(coroutine_plants[5]);
                break;
        }
        switch (animals_survival_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_animals[0]);
                StopCoroutine(coroutine_animals[1]);
                StartCoroutine(coroutine_animals[0]);
                break;
            case 2:
                StopCoroutine(coroutine_animals[1]);
                StopCoroutine(coroutine_animals[0]);
                StartCoroutine(coroutine_animals[1]);
                break;
            case 0:
                StopCoroutine(coroutine_animals[0]);
                StopCoroutine(coroutine_animals[1]);
                break;
        }
        switch (animals_immunity_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_animals[3]);
                StopCoroutine(coroutine_animals[2]);
                StartCoroutine(coroutine_animals[2]);
                break;
            case 2:
                StopCoroutine(coroutine_animals[2]);
                StopCoroutine(coroutine_animals[3]);
                StartCoroutine(coroutine_animals[3]);
                break;
            case 0:
                StopCoroutine(coroutine_animals[2]);
                StopCoroutine(coroutine_animals[3]);
                break;
        }
        switch (animals_reproduction_good)
        {
            case 1:
                print("bump");
                StopCoroutine(coroutine_animals[4]);
                StopCoroutine(coroutine_animals[5]);
                StartCoroutine(coroutine_animals[4]);
                break;
            case 2:
                StopCoroutine(coroutine_animals[4]);
                StopCoroutine(coroutine_animals[5]);
                StartCoroutine(coroutine_animals[5]);
                break;
            case 0:
                StopCoroutine(coroutine_animals[4]);
                StopCoroutine(coroutine_animals[5]);
                break;
        }
    }
    

    public IEnumerator WaitAndDo(float waitTime, string affects, int speed)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
                    game_info[affects] -= speed;
            }
        }
    }
