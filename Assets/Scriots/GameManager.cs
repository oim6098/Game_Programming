using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public TextMeshProUGUI GoldText; // Main_Canvas // Main_Canvas -> MoneyT 값 
    public int Gold = 1000000; // 초기 자금 
    void Start()
    {
        UpdateGoldUI();
    }

    public void UpdateGoldUI()
    {
        GoldText.text = "Gold : " + Gold;
    }
    


}
