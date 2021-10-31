using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 눈물의 치유력 컨트롤러
/// 
/// - 하는 일 -
/// 1. 현재 스킬 내용 detail에 설명.
///  현재 레벨 출력. level
///  현재 버튼 변화량 출력 deference (업그레이드 되면 변화량만큼 탭 당 하트 증가수가 증가합니다.)
///  현재 버튼 가격 출력 price
///  업그레이드 가능 불가능 
/// 1_2. if 현재 하트가 price보다 많으면 버튼 두근두근 애니메이션 발동.배경 색 밝아짐. 업그레이드 가능, 그리고 많으면 1, 아니면 업그레이드 불가능, 현재 하트/버튼price해서 버튼slider에 자동 반영, 배경 색 어두워짐. 
/// 2. 업그레이드할 시 달라질 내용 버튼difference에 설명, 업그레이드 비용도 btn_price에 설명. 
/// 3. Btn커버는 꺼둔다. 
/// 
/// 4. 업그레이드 가능 시 버튼 기능 처리. 스킬 업그레이드 처리. 
/// 
/// </summary>

public class Item_Tear : MonoBehaviour
{
    //IconImage
    public Image IconImage;
    //MiddleText - Name, Detail, Level
    public GameObject middleTextObj;
    public Text itemName, itemDetail, itemLevel;
    //Button - difference, icon, price, slider;
    public GameObject buttonObj;
    public Text btn_difference, btn_price;
    public Image btn_icon;
    public Slider btn_slider;
    //ButtonCover_Img - BGimg, icon, qualification;
    public GameObject buttonCovoerObj;
    public Image btnCover_BGimg, btnCover_icon;
    public Text btnCover_qualification;

    //스킬 정보
    //현재 레벨
    public int level;
    //현재 가격
    public int price;
    //가격 증가량
    public int price_increasement;
    //능력치 증가랑(탭 당 하트 획득량이 증가)
    public int difference;
    //업그레이드 가능 불가능 
    public bool isCanUpGrade;

    //플레이어 데이타
    public PlayerData playerData;
    //LeftUIController
    public LeftUIController leftUIController;

    void Start()
    {
        //3. btn커버 꺼두고 시작.
        buttonCovoerObj.SetActive(false);

        Init();
    }

    //초기화
    private void Init()
    {
        level = 0;
        price = 10;
        price_increasement = 10;
        difference = 1;
        isCanUpGrade = false;
    }
    void Update()
    {
        GameObject.Find("=====BottomUI=====").GetComponent<NewIconController>().lvl_tear = level;    //new 아이콘을 위한 갱신
        GameObject.Find("=====BottomUI=====").GetComponent<NewIconController>().price_tear = price;

        // 1. 현재 스킬 내용 detail에 설명.
        itemDetail.text = "탭당 치유력 " + playerData.GetCurrentCureAtOneTap().ToString();
        // 현재 레벨 출력. level
        itemLevel.text = "레벨 " + level.ToString();
        //현재 버튼 변화량 출력 deference (업그레이드 되면 변화량만큼 탭 당 하트 증가수가 증가합니다.)
        btn_difference.text = "+" + difference.ToString() +" 치유력";
        //현재 버튼 가격 출력 price
        btn_price.text = price.ToString();

        // 1_2. if 현재 하트가 price보다 많으면 버튼 두근두근 애니메이션 발동.배경 색 밝아짐. 업그레이드 가능, 그리고 많으면 1, 아니면 업그레이드 불가능, 현재 하트/버튼price해서 버튼slider에 자동 반영, 배경 색 어두워짐. 
        if (playerData.GetHeartCount() >= price)
        {
            buttonObj.GetComponent<Animator>().SetBool("activatePingPong", true);
            //업그레이드 가능
            isCanUpGrade = true;
            // 많으면 1
            btn_slider.value = 1f;
            // 배경 색 밝아짐
            buttonObj.GetComponent<Image>().color = new Color(0.4024564f, 0.7169812f, 0.6952899f, 1f);
        }
        else
        {            
            buttonObj.GetComponent<Animator>().SetBool("activatePingPong", false);
            //업그레이드 불가능
            isCanUpGrade = false;
            // 현재 하트/버튼price 해서 버튼슬라이더에 반영하기
            btn_slider.value = (float)playerData.GetHeartCount() / (float)price;
            // 배경 색 어두워짐
            buttonObj.GetComponent<Image>().color = new Color(0.1037736f, 0.1037736f, 0.1037736f, 1f);
        }                    
    }


    // 4. 업그레이드 가능 시 버튼 기능 처리. 스킬 업그레이드 처리. 
    public void OnUpgradeButtonClicked()
    {
        if (!isCanUpGrade) return; //업그레이드 불가능이면 그냥 무시. 

        //업그레이드 가능일 경우만 아래 내용 실행됨.

        //보유 하트 차감
        playerData.heart -= price;
        //탭 당 하트 획득량이 defference 만큼 증가.
        playerData.SetCurrentCureAtOneTap(playerData.GetCurrentCureAtOneTap() + difference);
        //price도 priceIncreasement만큼 증가.
        price += price_increasement;
        //레벨도 +1 증가.
        level++;
        //버튼 가격은 동결.

        //새로 갱신된 획득량을 버프에도 반영시키기 위해서 아래 메서드 호출.(버프 중에 레벨업했을 경우를 대비한 처사임.)
        leftUIController.SetBuffDetailsByItem_Tear(difference);
    }



}
