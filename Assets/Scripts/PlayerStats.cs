using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static float Money;
    public float startMoney = 400f;

    public static int Rounds;

    private float incomePerSecond = 1f;

    public static float hitpoints;
    public float startHitPoints = 10f;

    public Text GoldAmount;
    public Text LivessAmount;

    void Start()
    {
        Rounds = 0;
        Money = startMoney;
        hitpoints = startHitPoints;
    }

 
    public void Update()
    {
        // UI updates and money income
        Money += incomePerSecond * Time.deltaTime;
        GoldAmount.text = Mathf.Round(Money).ToString();
        LivessAmount.text = hitpoints.ToString();
    }
  
}
