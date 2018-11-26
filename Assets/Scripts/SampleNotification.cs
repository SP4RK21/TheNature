using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleNotification : MonoBehaviour
{
    public TextAsset evntInfo;
    public string[] InfluenceType;
    public int[] InfluencePower;
    public Text EventInfo;
    Dictionary<string, int> evnt_effect = new Dictionary<string, int>();


    public GameObject earth;
    MainAlgorythm algorythm;

    private Events evnt;
    private NotificationScroll scrollList;
    
    void Start()
    {
        //earth = GameObject.Find("Earth");
        //algorythm = earth.GetComponent<MainAlgorythm>();
    }
    public void Setup(Events currentEvent, NotificationScroll currentScrollList)
    {
        evnt_effect.Clear();
        earth = GameObject.Find("Earth");
        algorythm = earth.GetComponent<MainAlgorythm>();
        evnt = currentEvent;
        int AmountOfEffects = 0;
        InfluenceType = evnt.InfluenceType;
        InfluencePower = evnt.InfluencePower;
        string[] eventInformation = currentEvent.evntInfo.text.Split('\n');
        EventInfo.text = eventInformation[0];
        algorythm.AnimalsAffected = int.Parse(eventInformation[1])== 1;
        algorythm.PlantsAffected = int.Parse(eventInformation[2]) == 1;
        algorythm.AirAffected = int.Parse(eventInformation[3]) == 1;
        algorythm.WaterAffected = int.Parse(eventInformation[4]) == 1;
        AmountOfEffects = InfluenceType.Length;
        //int.TryParse(eventInformation[5], out AmountOfEffects);
        print(AmountOfEffects);
        for (int i = 0; i < AmountOfEffects; i++)
        {
            evnt_effect.Add(InfluenceType[i], -1);
            print(InfluenceType[i]);
            print(InfluencePower[i]); 
            algorythm.game_info[InfluenceType[i]] += InfluencePower[i];
            //print(InfluenceType[i]);
            //print(InfluencePower[i]);
            //switch (InfluenceType[i].ToString()) {
            //    case "goal_water_animals": algorythm.game_info["goal_water_animals"] += 110; break;
            //    case "goal_water_composition": algorythm.game_info["goal_water_composition"] += 110; break;
            //    case "goal_water_cycle": algorythm.game_info["goal_water_cycle"] += 110; break;
            //    case "goal_air_composition": algorythm.game_info["goal_air_composition"] += 110;  break;
            //    case "goal_air_winds": algorythm.game_info["goal_air_winds"] += 110; break;
            //    case "goal_air_temperature": algorythm.game_info["goal_air_temperature"] += 110; break;
            //    case "goal_plants_photosynthesis": algorythm.game_info["goal_plants_photosynthesis"] += 110; break;
            //    case "goal_plants_spreading": algorythm.game_info["goal_plants_spreading"] += 110; break;
            //    case "goal_plants_soil": algorythm.game_info["goal_plants_soil"] += 110; break;
            //    case "goal_animals_survival": algorythm.game_info["goal_animals_survival"] += 110; break;
            //    case "goal_animals_immunity": algorythm.game_info["goal_animals_immunity"] += 110;  break;
            //    case "goal_animals_reproduction": algorythm.game_info["goal_animals_reproduction"] += 110; break;
            //}
           
        }
        algorythm.EventsEffect.Add(evnt_effect);
        
        scrollList = currentScrollList;

    }
}