using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {
    public GameObject AnimalsHint;
    public GameObject PlantsHint;
    public GameObject AirHint;
    public GameObject WaterHint;
    public int hint_price;

    GameObject earth;
    MainAlgorythm algorythm;

    void Start () {
        earth = GameObject.Find("Earth");
        algorythm = earth.GetComponent<MainAlgorythm>();
    }

    public void Clicked()
    {
        if (algorythm.energy >= hint_price) {
            algorythm.energy -= hint_price;
            algorythm.game_info["hint_price"] = (int)(algorythm.game_info["hint_price"] * 1.21);

            HideHints();
            if (algorythm.AnimalsAffected == true) AnimalsHint.SetActive(true);
            if (algorythm.PlantsAffected == true) PlantsHint.SetActive(true);
            if (algorythm.AirAffected == true) AirHint.SetActive(true);
            if (algorythm.WaterAffected == true) WaterHint.SetActive(true);
            CancelInvoke();
            Invoke("HideHints", 10f);
        }

    }

    public void HideHints() {
        AnimalsHint.SetActive(false);
        PlantsHint.SetActive(false);
        AirHint.SetActive(false);
        WaterHint.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        hint_price = algorythm.game_info["hint_price"];
    }
}
