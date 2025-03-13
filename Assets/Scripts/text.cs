using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public static text Instance { get; private set; }
    public Text timetext;
    public Text cointext;
    public Text lifetext;
    public float currentTime;
    public float totalTime = 360f;

    private void Start()
    {
        Instance = this;
        GameManager.Instance.OnCoinCountChanged += UpdateCoinCount;
        UpdateLife();
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        int remainingTime = (int)(totalTime - currentTime);

        timetext.text = remainingTime.ToString();
        if (remainingTime <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void UpdateCoinCount(int coins)
    {
        cointext.text = "X " + coins.ToString();
    }

    // Update the life counter text
    private void UpdateLife()
    {
        lifetext.text = GameManager.Instance.lives.ToString();
    }
    public void UpdateLifeEnd()
    {
        lifetext.text = "0";
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnCoinCountChanged -= UpdateCoinCount;
    }
}