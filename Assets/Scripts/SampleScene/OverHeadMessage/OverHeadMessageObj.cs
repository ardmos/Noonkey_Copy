using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 메세지 내용 변경 기능. int 전달받음
/// 메세지 출력 애니메이션이 끝날 때 애니메이션 이벤트로 호출돼서 파괴.
/// </summary>

public class OverHeadMessageObj : MonoBehaviour
{    
    public void SetMessage(int num)
    {
        GetComponentInChildren<Text>().text = num.ToString();
    }

    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }
}
