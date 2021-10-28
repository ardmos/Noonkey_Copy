using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 하단 인디케이터 바에 정보 출력하는, 위 아래 이동 버튼 기능 처리하는 스크립트.
/// </summary>
public class IndecatorBarController : MonoBehaviour
{
    //플레이어 데이타
    public PlayerData playerData;

    //인디케이터 텍스트들
    public Text heartText, tearText, elfText, diaText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowDataOnIndecatorBar();   // 정보를 매 프레임마다 갱신시켜준다.
    }

    //하단 인디케이터 바에 정보 출력하는 부분
    void ShowDataOnIndecatorBar()
    {
        heartText.text = playerData.GetHeartCount().ToString();
        tearText.text = playerData.GetCurrentCureAtOneTap().ToString();
        elfText.text = playerData.GetTotalElfProvidesHeartInOneSecCount().ToString();
        diaText.text = playerData.GetDiaCount().ToString();
    }



    //위 아래 이동 버튼 기능 처리 부분.  위<->아래 이동, 이동시작시 스크롤뷰 노출. 이동 종료시 스크롤뷰 숨김.   어떤 스크롤뷰 보고있는중인지 스테이터스 저장 기능. 

    


}
