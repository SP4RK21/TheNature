using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTutorial : MonoBehaviour {

    public Sprite NextTut;
    public Button StartBtn;
    private Image spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void Clicked()
    {
        StartBtn.gameObject.SetActive(true);
        spriteRenderer.sprite = NextTut;

    }
}
