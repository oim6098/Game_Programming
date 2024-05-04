using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Gold;
    public static GameManager instance; 
    public int currentGold = 1000000; // 초기 자금 1백만원

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateGoldUI();
    }

    // 자금 차감 메소드
    public bool DeductGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldUI(); // UI 업데이트
            return true; // 성공적으로 차감
        }
        else
        {
            return false; // 자금이 부족함
        }
    }

    // Gold Text UI 업데이트 메소드
    private void UpdateGoldUI()
    {
        Gold.text = "Gold : " + currentGold;
    }
}
