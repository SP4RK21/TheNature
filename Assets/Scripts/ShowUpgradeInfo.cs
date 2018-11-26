using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpgradeInfo : MonoBehaviour
{

    public string UpgradeName = "";
    public string AboutUpgrade = "";
    public string PlusText = "";
    public UnityEngine.UI.Text UpgradeText;
    public GameObject upgradePanel;
    GameObject earth;
    InfoHolder holder;
    TextAsset TextUpgradeInfo;
    public UnityEngine.UI.Text text_UpgradeName;
    public UnityEngine.UI.Text text_AboutUpgrade;
    public UnityEngine.UI.Text text_plus;

    void Start()
    {
        earth = GameObject.Find("Earth");
        holder = earth.GetComponent<InfoHolder>();
    }

    public void open(TextAsset txt)
    {
        string[] linesInFile = txt.text.Split('\n');
        UpgradeName = linesInFile[0];
        AboutUpgrade = linesInFile[1];
        PlusText = linesInFile[2];
        text_UpgradeName.text = UpgradeName;
        text_AboutUpgrade.text = AboutUpgrade;
        text_plus.text = PlusText;
        upgradePanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && upgradePanel.activeInHierarchy == true)
        {
            upgradePanel.SetActive(false);
        }
    }

}


