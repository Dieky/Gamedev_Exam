using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static float Money;
    public float startMoney = 400f;

    private float incomePerSecond = 10f;

    private float hitpoints = 10f;

    public Text GoldAmount;
    public Text LivessAmount;

    void Start()
    {
        Money = startMoney;
    }

    public void AddMoney(float money)
    {
        Money += money;
    }

    public void Update()
    {
        // UI updates
        AddMoney(incomePerSecond * Time.deltaTime);
        GoldAmount.text = Mathf.Round(Money).ToString();
        LivessAmount.text = hitpoints.ToString();
    }
  
}
