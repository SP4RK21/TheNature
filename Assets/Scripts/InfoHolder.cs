using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHolder : MonoBehaviour
{

    [HideInInspector]public string[] InfluenceType;
    [HideInInspector]public int[] InfluencePower;
    [HideInInspector]public TextAsset UpgradeInfo;
    
    [HideInInspector]public int water_animals_price;
    [HideInInspector]public int water_composition_price;
    [HideInInspector]public int water_cycle_price;
    [HideInInspector]public int air_composition_price;
    [HideInInspector]public int air_winds_price;
    [HideInInspector]public int air_temperature_price;
    [HideInInspector]public int plants_photosynthesis_price;
    [HideInInspector]public int plants_spreading_price;
    [HideInInspector]public int plants_soil_price;
    [HideInInspector]public int animals_survival_price;
    [HideInInspector]public int animals_immunity_price;
    [HideInInspector]public int animals_reproduction_price;

}

