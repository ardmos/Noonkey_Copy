using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 테스트용 재화 늘리기 버튼 입니다.
/// </summary>
/// 
public class TestButton : MonoBehaviour
{
    public void OnButtonClicked()
    {
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heart += 1500;
    }
}
