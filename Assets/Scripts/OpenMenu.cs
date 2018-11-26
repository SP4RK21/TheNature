using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{

    public GameObject PanelToSwitch;
    public GameObject GameScreen;
    public GameObject UpgradeScreen;
    public GameObject UpgradesPanel;
    public bool ifBack;
    public Animation MenuOpening;


    public void Clicked()
    {
        if (ifBack == false)
        {
            PanelToSwitch.SetActive(true);
            MenuOpening = UpgradesPanel.GetComponent<Animation>();
            MenuOpening.Play("OpenMenu");
        }
        else
        {
            MenuOpening = UpgradesPanel.GetComponent<Animation>();
            MenuOpening.Play("CloseMenu");
            Time.timeScale = 1;
            GameScreen.SetActive(true);
            Invoke("DisableMenu",0.4f);
        }
    }

    public void DisableMenu()
    {
        PanelToSwitch.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && UpgradeScreen.activeInHierarchy == false)
        {
            UpgradesPanel.GetComponent<Animation>().Play("CloseMenu");
            Invoke("DisableMenu", 0.4f);
            Time.timeScale = 1;
        }
    }
}


