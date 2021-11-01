using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

/// <summary>
/// 다양한 플레이어의 상태 정보를 저장해주는 친구.
/// 1. 출석일수 (총 출석일수, 연속출석일수)
/// 2. 플레이어 레벨
/// 3. 현재 탭 당 획득(치유력)
/// 4. 총 터치 횟수
/// 5. 보유 재화 : 하트, 다이아
/// 6. 초당 엘프가 생산하는 하트 수
/// 
/// 
/// *** 재화 표기법 수정해서 넘겨주는 메서드도 갖고있습니다 ***
/// 
/// 
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
    public BigInteger heart;
    public int dia;
    //초당 엘프가 생산하는 총 하트 수
    public int elfProvidesOneSec_total;
    //장미, 튤립, 수선화, 샤프란, 아도니스, 양귀비, 칼라, 백일홍, 아몬드, 매화  각각의 요정이 제공하는 하트 양
    public int[] elfProvidesOneSec_Each;

    //
    public int heartOneSec;
    //마법의 샘 스킬을 위한 정보
    public int qualification_TabCount;
    public int buff_power, bufftime_min;


    //스킬들 정보
    public int lvl_Item0_RoseElf, lvl_item_Tear;



    //*** 재화 표기법 수정***
    public string GetHeartCount()
    {
        int placeN = 3; //자를 자릿수 단위
        BigInteger value = heart;   //전체 재화 복사해두기
        List<int> numList = new List<int>();    //자릿수별로 잘라서 저장할 리스트
        int p = (int)Mathf.Pow(10, placeN);  //이러면 p가 1000이 됨.    세 자릿수씩 자를때 쓸 수 있음. 

        do
        {
            numList.Add((int)(value%p));    //잘라서 저장.
            value /= p;
        } while (value >= 1);   //전부 다 잘라서 저장

        //int num = numList.Count < 2 ? numList[0] : numList[numList.Count - 1] * p + numList[numList.Count - 2];
        //float f = (num / (float)p);
        if (numList.Count < 2)
        {
            return numList[0].ToString();
        }
        else
        {
            float f = ((numList[numList.Count - 1] * p + numList[numList.Count - 2]) / (float)p);
            return f.ToString("N2") + " " + GetUnitText(numList.Count - 1);
        }        
    }
    private string GetUnitText(int index)
    {
        int idx = index - 1;
        if (idx < 0) return "";
        int repeatCount = (index / 26) + 1;
        string retStr = "";
        for (int i = 0; i < repeatCount; i++)
        {
            retStr += (char)(64 + index % 26);
        }

        return retStr;
    }




    private void Start()
    {
        //heart = 100000000;
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
    //public int GetHeartCount()
    //{
    //    return (int)heart;
    //}

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
        qualification_TabCount = 3000;
        bufftime_min = 1;
        buff_power = 2;
    }
    #endregion
}
