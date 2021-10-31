using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다이아 상점 팝업 관리 스크립트
/// 
/// 1. 팝업 닫기
/// 2.
/// 3.
/// 
/// </summary>

public class DressStore : MonoBehaviour
{
    public BottomUIController bottomUIController;
    public void ClosePopup()
    {
        bottomUIController.HighlightRecentBtn();
        gameObject.SetActive(false);
    }
}
