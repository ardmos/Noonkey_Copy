using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전체적인 흐름을 관장합니다. 
/// 1. 가장 중요한 터치 인식.  빠른 터치인지 느린 터치인지 확인 후 캐릭터컨트롤러에서 알맞은 메서드 호출
/// 2. 씬이 열릴 때 마다 현재 날짜를 확인하여 출석체크를 해줍니다. 마지막 출석날짜와 현재 날짜가 다르다면 PlayerData에 총 출석 일수를 +1 해줍니다. 출석일수를 증가시킨 후에는 마지막 출석날짜를 갱신해줍니다.  추가로 만약 지난번 출석 날짜가 오늘-1 과 같다면 PlayerData의 연속출석을 +1 해줍니다. 다르다면 연속출석을 0로 만듭니다.
/// </summary>

public class GameManager : MonoBehaviour
{
    //마지막 출석일
    public DateTime lastDateTime;

    //플레이어 정보
    public PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        CheckToDayDate();
    }

    // Update is called once per frame
    void Update()
    {

    }



    #region 출석체크 하는 부분
    /// 1. 씬이 열리면 현재 날짜 확인    
    /// 2. 혹시 마지막 날짜 +1이 현재 날짜면 연속출석+1 해줌.  아니라면 연속출석 0으로 만듦
    /// 3. 마지막 날짜와 현재 날짜가 다르다면 전체 출석 날짜 +1 해주고 현재 날짜를 마지막 출석일에 넣어줌
    ///

    //1. 씬이 열리면 현재 날짜 확인
    void CheckToDayDate()
    {
        DateTime currentDateTime = DateTime.Now;
        Debug.Log(currentDateTime);

        //2.
        if (lastDateTime.Date.AddDays(1) == currentDateTime.Date)
        {
            playerData.continuityCheckDay += 1;
        }
        else
        {
            playerData.continuityCheckDay = 0;
        }

        //3.
        if (lastDateTime != currentDateTime)
            RenewalLastDateTime(currentDateTime);
                
    }

    // 3. 전체 출석 날짜 +1 해주고 현재 날짜를 마지막 출석일에 넣어줌
    void RenewalLastDateTime(DateTime dateTime)
    {
        playerData.entireCheckDay += 1;
        lastDateTime = dateTime;
    }



    #endregion

}
