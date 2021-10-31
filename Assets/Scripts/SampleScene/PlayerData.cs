using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 다양한 플레이어의 상태 정보를 저장해주는 친구.
/// 1. 출석일수 (총 출석일수, 연속출석일수)
/// 2. 플레이어 레벨
/// 3. 현재 탭 당 획득(치유력)
/// 4. 총 터치 횟수
/// 5. 보유 재화 : 하트, 다이아
/// 6. 초당 엘프가 생산하는 하트 수
/// </summary>


public class PlayerData : MonoBehaviour
{
    //총 출석일수, 연속 출석일수
    public int entireCheckDay, continuityCheckDay;
    //플레이어 레벨
    public int playerLevel;
    //현재 탭 당 획득(치유력)
    public int currentCureAtOneTap;
    //총 터치 횟수
    public int totalTapCount;
    //보유 재화 : 하트, 다이아
    public int heart, dia;
    //초당 엘프가 생산하는 총 하트 수
    public int elfProvidesOneSec_total;
    //장미, 튤립, 수선화, 샤프란, 아도니스, 양귀비, 칼라, 백일홍, 아몬드, 매화  각각의 요정이 제공하는 하트 양
    public int[] elfProvidesOneSec_Each;

    //
    public int heartOneSec;
    //마법의 샘 스킬을 위한 정보
    public int qualification_TabCount;
    public int buff_power, bufftime_min;


    private void Start()
    {
        currentCureAtOneTap = 1;    //1로 시작

        //마법의 샘 스킬 초기정보 세팅
        InitMagicTearStreamData();
    }

    #region 탭 당 획득 관련(치유력)
    public int GetCurrentCureAtOneTap() { return currentCureAtOneTap; }
    public void SetCurrentCureAtOneTap(int num)
    {
        currentCureAtOneTap = num;
    }
    #endregion



    #region 총 터치 횟수
    public void AddTotalTapCount()
    {
        totalTapCount++;
    }
    public int GetTotalTapCount()
    {
        return totalTapCount;
    }
    #endregion


    #region 총 재화
    public int GetHeartCount()
    {
        return heart;
    }
    public void AddHeart(int num)
    {
        heart += num;
    }

    public int GetDiaCount()
    {
        return dia;
    }
    public void AddDia(int num)
    {
        dia += num;
    }
    #endregion

    #region 초당 엘프가 생산하는 하트 수
    public int GetTotalElfProvidesHeartInOneSecCount()  //하단UI 인디케이터바에서 호출해서 씀. 
    {
        elfProvidesOneSec_total = 0;

        foreach (int elfProvides in elfProvidesOneSec_Each)
        {
            elfProvidesOneSec_total += elfProvides;
        }

        return elfProvidesOneSec_total;
    }
    #endregion

    #region 마법의 샘 스킬을 위한 정보들. 
    void InitMagicTearStreamData()
    {
        qualification_TabCount = 10;
        bufftime_min = 1;
        buff_power = 2;
    }
    #endregion
}
