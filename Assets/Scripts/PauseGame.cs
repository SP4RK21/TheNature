using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public GameObject GameScreen;
    public GameObject plants;
    public GameObject air;
    public GameObject animals;
    public GameObject water;
    public GameObject PanelToSwitch;
    public GameObject NotificationPanel;

    // Update is called once per frame
    public void Clicked()
    {
        Pause();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && plants.activeInHierarchy == false && air.activeInHierarchy == false && animals.activeInHierarchy == false && water.activeInHierarchy == false)
                Pause();
        


    }

    public void Pause()
    {
        if (PanelToSwitch.activeInHierarchy == false && GameScreen.activeInHierarchy == true)
        {
            NotificationPanel.SetActive(false);
            Time.timeScale = 0;
            GameScreen.SetActive(false);
            PanelToSwitch.SetActive(true);
        }
        else
        {
            NotificationPanel.SetActive(true);
            Time.timeScale = 1;
            GameScreen.SetActive(true);
            PanelToSwitch.SetActive(false);
        }


    }
}

