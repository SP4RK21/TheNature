using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class Click : MonoBehaviour
{
    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public int[] upgradePower;
    public string[] upgradeName;
    public TextAsset TextUpgradeInfo;
    GameObject earth;
    InfoHolder holder;
    public GameObject UpgradePanel;
    public GameObject myButton;
    public Sprite commonSprite;
    public Sprite pressedSprite;
    private Sprite currentSprite;
    private Image spriteRenderer;
    private Transform scale;

    public Button btn1;
    public Button btn2;

    void Start()
    {
        earth = GameObject.Find("Earth");
        holder = earth.GetComponent<InfoHolder>();
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        spriteRenderer = GetComponent<Image>();
    }

    void Update()
    {

        if (UpgradePanel.activeInHierarchy == false)
        {
            spriteRenderer.sprite = commonSprite;
            myButton.transform.localScale = new Vector3(1f, 1f, 0);

        }

    }
    void PlaySound()
    {
        source.PlayOneShot(sound);
    }
    public void revertButtons() {
        btn1.GetComponent<Image>().sprite = commonSprite;
        btn2.GetComponent<Image>().sprite = commonSprite;
        btn1.transform.localScale = new Vector3(1f, 1f, 0);
        btn2.transform.localScale = new Vector3(1f, 1f, 0);
    }
    public void Clicked()
    {
        PlaySound();
        holder.InfluenceType = upgradeName;
        holder.InfluencePower = upgradePower;
        holder.UpgradeInfo = TextUpgradeInfo;
        spriteRenderer.sprite = pressedSprite;
        myButton.transform.localScale = new Vector3(2.5f, 2.5f, 0);
        UpgradePanel.GetComponent<ShowUpgradeInfo>().open(TextUpgradeInfo);

    }
}
