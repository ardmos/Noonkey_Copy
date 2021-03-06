using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전체적인 흐름을 관장합니다. 
/// 0. 터치횟수, 하트 증가
/// 1. 가장 중요한 터치 인식.  빠른 터치인지 느린 터치인지 확인 후 캐릭터컨트롤러에서 알맞은 메서드 호출
/// 
/// 
/// 2. 씬이 열릴 때 마다 현재 날짜를 확인하여 출석체크를 해줍니다. 마지막 출석날짜와 현재 날짜가 다르다면 PlayerData에 총 출석 일수를 +1 해줍니다. 출석일수를 증가시킨 후에는 마지막 출석날짜를 갱신해줍니다.  추가로 만약 지난번 출석 날짜가 오늘-1 과 같다면 PlayerData의 연속출석을 +1 해줍니다. 다르다면 연속출석을 0로 만듭니다.
/// 
/// 3. Android 백버튼 눌리면 게임 종료 여부 물어보는 팝업 출력. 
///
/// 
/// </summary>

public class GameManager : MonoBehaviour
{
    //마지막 출석일
    public DateTime lastDateTime;

    //플레이어 정보
    public PlayerData playerData;
    //캐릭터 컨트롤러
    public CharacterController_m characterController_M;
    //오버헤드메세지 컨트롤러
    public OverHeadMessageController overHeadMessageController;

    //최근 터치 시간, 현재 터치 시간
    public DateTime lastTouchTime, currentTouchTime;

    //백버튼눌렸을 때 게임종료여부 물어보는 팝업.
    public GameObject exitPopupObj;

    // Start is called before the first frame update
    void Start()
    {
        CheckToDayDate();

    }

    // Update is called once per frame
    void Update()
    {
        // 3. Android 백버튼 눌리면 게임 종료 여부 물어보는 팝업 출력. 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPopupObj.SetActive(true);
        }
    }

    #region 터치 인식해서 눈물 만드는 부분.
    /// 0. 터치횟수, 하트 증가, 머리 위에 획득 하트 표시!
    /// 1. 가장 중요한 터치 인식.  빠른 터치인지 느린 터치인지 확인 후 캐릭터컨트롤러에서 알맞은 눈물 흘리기 메서드 호출
    /// 2. 처음 터치인 경우 터치간격 계산 안하고 바로 최근 터치 시간 갱신, 슬로우로 하나 발사.
    /// 3. 최근 터치 시간 - 현재 터치 시간 값이 0.5초 이내면 빠른터치로 간주.
    /// 
    //1. 가장 중요한 터치 인식.  빠른 터치인지 느린 터치인지 확인 후 캐릭터컨트롤러에서 알맞은 메서드 호출
    public void OnScreenBtnTouched()
    {

        //0. 터치횟수, 하트 증가, 머리 위에 획득 하트 표시!
        playerData.AddTotalTapCount();  
        playerData.AddHeart(playerData.GetCurrentCureAtOneTap());
        overHeadMessageController.OverHeadMessageGenerator(playerData.GetCurrentCureAtOneTap());

        //2. 처음 터치인 경우 터치간격 계산 안하고 바로 최근 터치 시간 갱신, 슬로우로 하나 발사.
        if (FistTouchCheck()) {
            characterController_M.MakeSadFace("slow");
            return;
        }

        //처음 터치가 아닐 경우에만 아래 내용 진행
        //3. 최근 터치 시간 - 현재 터치 시간 값이 0.2초 이내면 빠른터치로 간주.
        if (CalcTouchinterval().TotalSeconds <= 0.2f){
            //빠른 터치인 경우
            characterController_M.MakeSadFace("fast");
            //Debug.Log("빠른 터치 입니다!");
        }
        else
        {
            //느린 터치인 경우
            characterController_M.MakeSadFace("slow");
            //Debug.Log("느린 터치 입니다!");
        }

        //최근 터치 시간 갱신
        lastTouchTime = currentTouchTime;

    }

    //2. 처음 터치인 경우 터치간격 계산 안하고 바로 최근 터치 시간 갱신.
    bool FistTouchCheck()
    {
        DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0);
        if (lastTouchTime == dateTime)
        {
            lastTouchTime = DateTime.Now;
            //Debug.Log("첫 터치 입니다. 터치 시간 갱신!");
            return true;
        }
        else return false;
    }

    //3. 최근 터치 시간 - 현재 터치 시간 값이 0.5초 이내면 빠른터치로 간주.
    TimeSpan CalcTouchinterval()
    {
        TimeSpan intervalTime;

        currentTouchTime = DateTime.Now;
        intervalTime = currentTouchTime - lastTouchTime;
        //Debug.Log("터치 인터벌 타임: " + intervalTime);

        return intervalTime;
    }

    

    #endregion



    #region 출석체크 하는 부분
    /// 1. 씬이 열리면 현재 날짜 확인    
    /// 2. 혹시 마지막 날짜 +1이 현재 날짜면 연속출석+1 해줌.  아니라면 연속출석 0으로 만듦
    /// 3. 마지막 날짜와 현재 날짜가 다르다면 전체 출석 날짜 +1 해주고 현재 날짜를 마지막 출석일에 넣어줌
    ///

    //1. 씬이 열리면 현재 날짜 확인
    void CheckToDayDate()
    {
        DateTime currentDateTime = DateTime.Now;
        //Debug.Log(currentDateTime);

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
