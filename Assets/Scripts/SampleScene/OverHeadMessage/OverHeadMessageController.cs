using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 머리 위에 출력되는 획득하트양 애니메이션을 실행시켜주는 스크립트.
/// 1. 머리 위에 획득 하트양 표시해주는 프리팹 생성해주는 메서드. 게임메니저에서 터치될때마다 호출해준다.
/// </summary>

public class OverHeadMessageController : MonoBehaviour
{
    public GameObject overHeadMessagePref;

    
    public void OverHeadMessageGenerator(int num)   //출력할 하트 양을 전달받아서 전달한다!!
    {
        //Debug.Log("생산중!!" + num.ToString());
        GameObject prefObj = Instantiate(overHeadMessagePref) as GameObject;
        prefObj.GetComponent<OverHeadMessageObj>().SetMessage(num);
        prefObj.GetComponent<RectTransform>().SetParent(GetComponent<RectTransform>());
        prefObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
