using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ConfirmUpdate : MonoBehaviour
{

    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    string upgradeName;
    int upgradePower;
    string subupgradeName;
    int subupgradePower;
    GameObject earth;
    MainAlgorythm algorythm;
    InfoHolder holder;
    public UnityEngine.UI.Text upgradeBtn;
    int price;

    void Start()
    {
        earth = GameObject.Find("Earth");
        algorythm = earth.GetComponent<MainAlgorythm>();
        holder = earth.GetComponent<InfoHolder>();
        upgradeName = holder.InfluenceType[0];
        upgradePower = holder.InfluencePower[0];
        subupgradeName = holder.InfluenceType[0];
        subupgradePower = holder.InfluencePower[0];
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
    }

    void PlaySound()
    {
        source.PlayOneShot(sound, 0.39f);
    }

    void Update()
    {
        upgradeName = holder.InfluenceType[0];
        upgradePower = holder.InfluencePower[0];
        subupgradeName = holder.InfluenceType[0];
        subupgradePower = holder.InfluencePower[0];
        price = algorythm.game_info[upgradeName+"_price"];
        upgradeBtn.text = "Улучшить за " + price;
    }

    public void Clicked()
    {

        upgradeName = holder.InfluenceType[0];
        upgradePower = holder.InfluencePower[0];
        subupgradeName = holder.InfluenceType[1];
        subupgradePower = holder.InfluencePower[1];
        if(algorythm.energy >= algorythm.game_info[upgradeName+"_price"])
                {
            PlaySound();
            algorythm.EventsEffect[algorythm.current_index]["goal_" + upgradeName] = 0;
            algorythm.game_info[upgradeName] += upgradePower;
            algorythm.game_info[subupgradeName] += subupgradePower;
            algorythm.energy -= algorythm.game_info[upgradeName + "_price"];
            algorythm.game_info[upgradeName + "_price"] = (int)(algorythm.game_info[upgradeName + "_price"] * 1.21);
            algorythm.CheckEvent();
        }


    }
}

