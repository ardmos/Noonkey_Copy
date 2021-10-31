﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다이아 상점 팝업 관리 스크립트
/// 
/// 1. 팝업 닫기
/// 2. 상품탭 선택
/// 3.
/// 
/// </summary>

public class DressStore : MonoBehaviour
{
    public BottomUIController bottomUIController;

    public GameObject hatobj, wandobj, wingobj;

    private void Start()
    {
        hatobj.SetActive(true);
        wandobj.SetActive(false);
        wingobj.SetActive(false);
    }

    public void ClosePopup()
    {
        bottomUIController.HighlightRecentBtn();
        gameObject.SetActive(false);
    }

    //2. 상품 탭 선택
    public void OnHatListBtnClicked()
    {
        hatobj.SetActive(true);
        wandobj.SetActive(false);
        wingobj.SetActive(false);
    }
    public void OnWandListBtnClicked()
    {
        hatobj.SetActive(false);
        wandobj.SetActive(true);
        wingobj.SetActive(false);
    }
    public void OnWingListBtnClicked()
    {
        hatobj.SetActive(false);
        wandobj.SetActive(false);
        wingobj.SetActive(true);
    }
}
