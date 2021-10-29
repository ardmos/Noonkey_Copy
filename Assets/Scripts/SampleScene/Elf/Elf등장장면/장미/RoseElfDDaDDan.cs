using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 장미엘프 등장장면에 있는 스크립트. 
/// 
/// 장미엘프 등장 애니메이션 끝 부분에 있는 애니메이션 이벤트로 호출되는 메서드가 여기 있음.
/// 
/// 호출되면 두 가지.
/// 
/// 1. 장미엘프 생성
/// 2. 등장장면 닫기
/// 
/// 
/// </summary>


public class RoseElfDDaDDan : MonoBehaviour
{
    public GameObject RoseDDaObj;
    public ElfGenerator elfGenerator;

    public void DDaDDanEnd()
    {
        //장미엘프 생성
        elfGenerator.GiveLifeRoseElf();

        //등장장면 닫기
        RoseDDaObj.SetActive(false);
    }
}
