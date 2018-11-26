using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Events
{
    public TextAsset evntInfo;
    public string[] InfluenceType;
    public int[] InfluencePower;
}

public class NotificationScroll : MonoBehaviour
{

    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public List<Events> eventList;
    public Transform contentPnl;
    private int Rnd;
    List<int> usedValues = new List<int>();
    public GameObject earth;
    MainAlgorythm algorythm;

    public GameObject prefab;



    void Start()
    {
        earth = GameObject.Find("Earth");
        algorythm = earth.GetComponent<MainAlgorythm>();
        InvokeRepeating("LaunchEvent", 3f, 25f); 
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
    }

    void PlaySound()
    {
        source.PlayOneShot(sound, 0.21f);
    }

    void LaunchEvent()
    {
        algorythm.current_index++;
        PlaySound();
        Rnd = UniqueRandomInt(0, eventList.Count);
        Events evnt = eventList[Rnd];
        GameObject newEvent = Instantiate(prefab, contentPnl) as GameObject;
        newEvent.transform.SetAsFirstSibling();
        newEvent.transform.SetParent(contentPnl);
        newEvent.SetActive(true);
        SampleNotification sampleNotification = newEvent.GetComponent<SampleNotification>();
        sampleNotification.Setup(evnt, this);
        
        algorythm.ShowedEvents[algorythm.current_index] = newEvent;
    }


    public int UniqueRandomInt(int min, int max)
    {
        int val = Random.Range(min, max);
        while (usedValues.Contains(val))
        {
            val = Random.Range(min, max);
            if (usedValues.Count == 24)
            {
                algorythm.gameWon = true;
                algorythm.GameOver_();
                break;
            }
        }
        usedValues.Add(val);
        return val;
    }
}
