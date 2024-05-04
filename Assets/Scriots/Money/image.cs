using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class image: MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI nameText; // 이름을 표시할 TextMeshProUGUI
    public TextMeshProUGUI percentageText; // 백분율을 표시할 TextMeshProUGUI
    public Sprite[] images; // 장갑 이미지 배열 
    public string[] names; // 장갑 이름 배열
    public string[] percentages; // 확률 배열 

    public int[] UpgradeGold; // 업그레이드 비용 배열
    public int[] SellGold; // 판매가격 비용 배열

    private int currentIndex = 0; // 현재 이미지의 인덱스 위치
    private Image imageComponent; 

    void Start()
    {
        imageComponent = GetComponent<Image>(); // 시작 시 Image 컴포넌트를 찾아서 저장
        UpdateImageAndText(); // 첫 번째 이미지와 텍스트로 설정
    }

    // 이미지, 이름, 백분율을 변경하는 메소드
    public void ChangeToNextImage()
    {
        if (TryEnhanceSuccess()) // 강화 시도
        {
            currentIndex = (currentIndex + 1) % images.Length; // 성공하면 다음 인덱스로 이동
        }
        else
        {
            currentIndex = 0; // 실패하면 처음으로 돌아감
            Debug.Log("강화실패");
        }
        UpdateImageAndText(); // 이미지와 텍스트 업데이트
    }

    // 강화 성공 여부를 결정하는 메소드
  private bool TryEnhanceSuccess()
{
    // percentages 배열
     string percentageString = percentages[currentIndex].Replace("강화확률 :", "").Replace("%", "").Trim();

    // 문자열을 정수로 변환을 시도합니다.
    int successChance;
    bool parseResult = int.TryParse(percentageString, out successChance);
    if (!parseResult)
    {
        Debug.LogError($"'percentages' 배열의 형식이 잘못되었습니다: {percentages[currentIndex]}");
        return false; 
    }

    // 성공 확률 랜덤 수
    int randomChance = Random.Range(0, 101);
    // 무작위 수를 통한 성공 확률 로그
    Debug.Log($"무작위 수 : {randomChance}, 필요한 성공 확률: {successChance}");

    return randomChance <= successChance;
}
    // 이미지와 텍스트를 현재 인덱스에 맞게 업데이트하는 메소드
    private void UpdateImageAndText()
    {
        if (images.Length > 0 && currentIndex < images.Length)
        {
            imageComponent.sprite = images[currentIndex]; // 이미지 변경
            nameText.text = names[currentIndex]; // 이름 변경
            percentageText.text = percentages[currentIndex]; // 백분율 변경
            Debug.Log($"현재 이미지: {images[currentIndex].name}, 이름: {names[currentIndex]}, 확률: {percentages[currentIndex]}");
        }
    }
}
