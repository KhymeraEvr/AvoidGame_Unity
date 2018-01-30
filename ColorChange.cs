using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour {
    public Color startColor;
    public Color endColor;
    public float changeSpeed = 1f;
    float startTime;
    GameManager GM;
    // Use this for initialization
    void Start () {
        GM = FindObjectOfType<GameManager>();
        startTime = Time.timeSinceLevelLoad;
        GM.changeDifficulty += updateDifficulty;
    }
	
	// Update is called once per frame
	void Update () {
        float T = (Time.timeSinceLevelLoad - startTime) * changeSpeed; // as the difficulty rises, color changes faster
        Color newColor = Color.Lerp(startColor, endColor, (Mathf.Sin(T)));
        newColor.a = 255;
        GetComponent<SpriteRenderer>().color = newColor;
    }

    void updateDifficulty()
    {
        changeSpeed += 0.5f;
    }

}
