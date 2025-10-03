using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DisplayCandles : MonoBehaviour
{
    public ItemStorage item;
    public TMP_Text candleText;
    public string targetName = "Candle";
    public int totalAmount = 5;

    public void FixedUpdate()
    {
        UpdateDisplayText();
    }

    public void UpdateDisplayText()
    {
       
        int currentAmount = item.collected.Where(item => item.Name == targetName).Sum(item => item.Quantity);

        candleText.text = $"{currentAmount}/{totalAmount}"; ;
    }

}
