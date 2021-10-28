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


    private void Start()
    {
        currentCureAtOneTap = 1;    //1로 시작
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
}
