using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 종료 여부를 묻는 팝업 스크립트. 
/// 
/// 1. 예 버튼 클릭시 프로그램 종료.
/// 2. 아니요 버튼 클릭 시 팝업 닫기.
/// 
/// </summary>

public class ExitPopup : MonoBehaviour
{
    public void OnYesBtnClicked()
    {
        Application.Quit();
    }
    public void OnNoBtnClicked()
    {
        gameObject.SetActive(false);
    }
}
