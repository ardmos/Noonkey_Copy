using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 화면 좌측 UI 컨트롤러. 
/// 
/// 보유자산 : 슬라이더, 이미지, 커버이미지(텍스트)
/// 
/// 하는 일: 마법의눈물샘 발동조건 가시화(슬라이더, 이미지로). 마법의 눈물샘 버프 발동(슬라이더 용도 변경, 커버이미지 발동, 토탈탭 카운트 초기화), 종료 처리. 
/// 
/// 
/// (총 버프 유지시간) - (현재시간-버프시작시간)  / (총 버프 유지시간)분  만큼 좌측UI 슬라이더에 표시.  아래 아이콘에는 (x몇배) 라고 적음.까만뒷배경으로.
/// 버프 끝나면 if (총 버프 유지시간) - (현재시간-버프시작시간) <= 0 
/// 좌측 슬라이더 UI는 다시 토탈탭카운트/목표수치 를 표시하는 슬라이더로 역할 변경. 아래 아이콘도 얌전하게 마법의눈물샘 아이콘으로 돌아옴.
/// 
/// 
/// </summary>

public class LeftUIController : MonoBehaviour
{
    public Slider slider;
    public GameObject image, coverImage;
    public Text coverImageText;

    //플레이어데이타
    public PlayerData playerData;
    //마법의눈물샘 컨트롤러
    //public Item_MagicTearStream item_MagicTearStream;


    //버프 관련 정보
    //총 버프 유지시간
    public TimeSpan bufftime;
    //몇 배
    public int buff_power;
    //버프 시작 시간
    public DateTime buffStartTime;
    //현재 버프중인가??
    public bool isNowOnBuff;
    //버프 발동 가능한가?
    public bool isCanBuff;
    //저장해두는 버프받기 이전 탭 당 획득량.
    public int currentCureAtOneTap_BeforStartBuff;


    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
    }

    //평상시엔 슬라이더값으로 마법의눈물샘 발동조건을 가시화 시켜준다.
    void UpdateSlider()
    {
        //버프중인가??? 
        if (isNowOnBuff)
        {
            //버프중일때  
            //경과 시간
            TimeSpan passedtimeSpan = DateTime.Now - buffStartTime;            
            //버프 끝 체크. 
            if (bufftime.TotalSeconds - passedtimeSpan.TotalSeconds <= 0)
            {
                //버프 끝
                isNowOnBuff = false;
                //커버 비활성화
                coverImage.SetActive(false);
                //탭 당 배율 원래대로
                playerData.currentCureAtOneTap /= buff_power;
            }
            else
            {
                //버프 중
                                
                slider.value = ((float)bufftime.TotalSeconds - (float)passedtimeSpan.TotalSeconds) / (float)bufftime.TotalSeconds;
                //커버 활성화.
                coverImage.SetActive(true);
                coverImageText.text = "x" + buff_power.ToString();
            }
        }
        else
        {
            //버프중이 아닐 때
            //Debug.Log((float)playerData.GetTotalTapCount()/(float)playerData.qualification_TabCount);
            if((float)playerData.GetTotalTapCount() / (float)playerData.qualification_TabCount >= 1)
            {
                
                //버프중이 아닌데 버프 발동 가능할 때.  블링크 애니메이션 재생.  버프 버튼 클릭 가능.하다는 뜻. 
                image.GetComponent<Animator>().SetBool("springIsFull", true);
                isCanBuff = true;
                slider.value = 1f;
            }
            else
            {
                //버프중인 아닌데 버프 발동 불가능할때
                //slider.value = (float)playerData.GetTotalTapCount() / (float)playerData.qualification_TabCount;
                slider.value = (float)playerData.GetTotalTapCount() / (float)playerData.qualification_TabCount;
                
                isCanBuff = false;
            }

            coverImage.SetActive(false);            
        }
    }


    //버프 조건 변경 메서드..  마법의눈물샘 컨트롤러에서 호출함, 눈물마법(기본획득량증가)에서도 레벨업 할 때 호출함. 레벨업으로 증가된 획득량을 반영시키기 위해서.
    public void SetBuffDetails()
    {
        this.buff_power = playerData.buff_power;
        this.bufftime = new TimeSpan(0, playerData.bufftime_min, 0);
        //버프도중에 호출된거면. 탭 당 배율 증가를 갱신해준다.
        if (isNowOnBuff)
        {
            int tmp = currentCureAtOneTap_BeforStartBuff;
            tmp *= buff_power;   //탭 당 배율 증가.
            playerData.currentCureAtOneTap = tmp;
        }
    }
    public void SetBuffDetailsByItem_Tear(int tearIncreasement)
    {
        this.buff_power = playerData.buff_power;
        this.bufftime = new TimeSpan(0, playerData.bufftime_min, 0);

        //버프도중에 호출된거면. 탭 당 배율 증가를 갱신해준다.
        if (isNowOnBuff)
        {            
            currentCureAtOneTap_BeforStartBuff += tearIncreasement;
            int tmp = currentCureAtOneTap_BeforStartBuff;
            tmp *= buff_power;   //탭 당 배율 증가.
            playerData.currentCureAtOneTap = tmp;
        }
    }



    //버프 발동 메서드. 온클릭리스너로 인스펙터상에서 호출됨. 
    public void OnStartBuffButtonClicked()
    {
        //Debug.Log("버프 시작 버튼 클릭됐습니다!");
        if (!isCanBuff)
        {
            //버프가능한상황이 아니면 그냥 무시
            Debug.Log("무시됐습니다"); 
            return;
        }
        
        //버프파워, 버프타임 한 번 더 갱신. 혹시 모르니.
        this.buff_power = playerData.buff_power;
        this.bufftime = new TimeSpan(0, playerData.bufftime_min, 0);
        this.buffStartTime = DateTime.Now;
        isCanBuff = false;
        isNowOnBuff = true;
        image.GetComponent<Animator>().SetBool("springIsFull", false);  //블리크 애니메이션 종료.    
        currentCureAtOneTap_BeforStartBuff = playerData.currentCureAtOneTap; //배율 변경 전에 미리 저장.
        playerData.currentCureAtOneTap *= buff_power;   //탭 당 배율 증가.
        playerData.totalTapCount = 0;   //토탈 탭 카운트 초기화.

    }
}
