using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// 마법의 눈물샘 컨트롤러
/// 
/// - 하는 일 -
/// 1. 현재 스킬 내용 detail에 설명.
///  현재 레벨 출력. level
///  현재 버튼 변화량 출력 deference (업그레이드 되면 변화량만큼 탭 당 하트 증가수가 증가합니다.)
///  얘네부터는 개방 조건도 있음 개방조건 출력
///  업그레이드 가능 불가능 
/// 
/// 2. 업그레이드할 시 달라질 내용 버튼difference에 설명 
/// 3. 개방 조건 충족 여부에 따라 Btn커버 켜고 끄고, 커버에 개방조건 글씨도 출력..   커버 켤 시에는 버튼은 비활성화. 
/// 
/// 4. 개방 조건 충족 시 버튼 기능 처리. 탭 카운트해서 2000탭이 될 때마다 1분간 버프 발동. 탭카운트 초기화. 
/// 
/// 5. 현 스킬 개방 조건 설정. 조건은 두 개
///   눈물의 치유력 레벨  5때 개방-3000탭 1분간 2배,  30때 개방- 2000탭 3분간 4배
///   
/// 개방하면 저 내용.
/// 
/// </summary>

public class Item_MagicTearStream : MonoBehaviour
{
    //IconImage
    public Image IconImage;
    //MiddleText - Name, Detail, Level
    public GameObject middleTextObj;
    public Text itemName, itemDetail, itemLevel;
    //Button - difference;
    public GameObject buttonObj;    
    //ButtonCover_Img - BGimg, icon, qualification;
    public GameObject buttonCovoerObj;
    public Image btnCover_BGimg, btnCover_icon;
    public Text btnCover_qualification;

    //스킬 정보
    //현재 레벨
    public int level;
    //쳐야하는 탭 개수 
    public int qualification_TabCount;
    //성공시 유지되는 버프 시간 (분)
    public int bufftime_min;
    //성공시 상승하는 탭 당 치유력 (몇 배.  배단위 숫자임.)
    public int buff_power;
    //업그레이드하려면 필요 레벨
    public int needLevel;
    //업그레이드 가능여부
    public bool isCanUpGrade;
    //개방조건 만족했는지
    public bool good = false;
    //눈물스킬 레벨 확인하기
    public int tearLevelCheck;


    //플레이어 데이타
    public PlayerData playerData;
    //눈물스킬
    public Item_Tear item_Tear;
    //좌측 UI 컨트롤러
    public LeftUIController leftUIController;

    void Start()
    {
        Init();
    }

    //초기화
    private void Init()
    {
        level = 0;
        isCanUpGrade = false;
        qualification_TabCount = 10;
        bufftime_min = 1;
        buff_power = 2;
        needLevel = 5;
    }
    void Update()
    {
        tearLevelCheck = item_Tear.level;

        switch (level)
        {
            case 0:
                qualification_TabCount = 10;
                bufftime_min = 1;
                buff_power = 2;
                needLevel = 5;
                break;
            case 1:
                qualification_TabCount = 10;
                bufftime_min = 1;
                //버퍼파워는 1씩 증가하니까 아래에서 처리해줬다
                needLevel = 10;
                break;
            case 2:
                qualification_TabCount = 100;
                bufftime_min = 3;
                //버퍼파워는 1씩 증가하니까 아래에서 처리해줬다
                needLevel = 20;
                break;
            default:
                //나머지 레벨 미구현. 

                //커버 켜고
                buttonCovoerObj.SetActive(true);
                //버튼 끄고
                buttonObj.SetActive(false);
                btnCover_qualification.text = "";
                return;                
        }

        // 1. 현재 스킬 내용 detail에 설명.
        itemDetail.text = qualification_TabCount  + "탭 달성시 " + bufftime_min + "분간 탭치유력 "+ buff_power + "배";
        // 현재 레벨 출력. level
        itemLevel.text = "레벨 " + level.ToString();

        //개방조건 확인. 
        if (CheckQualification())
        {
            //개방조건 만족했을 경우
            isCanUpGrade = true;

            //커버 끄고
            buttonCovoerObj.SetActive(false);
            //버튼 켜고
            buttonObj.SetActive(true);
        }
        else
        {
            //개방조건 불만족했을 경우 
            isCanUpGrade = false;

            //커버 켜고
            buttonCovoerObj.SetActive(true);
            //버튼 끄고
            buttonObj.SetActive(false);
            btnCover_qualification.text = "눈물레벨 " + needLevel.ToString();
        }


    }

    //개방조건을 충족했는가??? 확인해주는 메서드.
    bool CheckQualification()
    {
        //개방조건은 마법의눈물샘레벨1 - 눈물의치유력 레벨 5,  마법의눈물샘레벨2 - 눈물의치유력레벨30

        if (level == 0)
        {
            if (item_Tear.level >= needLevel)
            {
                //조건 만족! 
                good = true;
            }
            else good = false;
        }
        else if (level == 1)
        {
            if (item_Tear.level >= needLevel)
            {
                //조건 만족! 
                good = true;
            }
            else good = false;
        }
        else { } //Debug.Log("나머지 마법의눈물샘 레벨은 미개발."); }

        return good;
    }

    /// 4. 개방 조건 충족 시 버튼 기능 처리. 탭 카운트해서 2000탭이 될 때마다 1분간 버프 발동. 탭카운트 초기화. 
    public void OnUpgradeButtonClicked()
    {
        if (!isCanUpGrade) return;

        //커버 켜고
        buttonCovoerObj.SetActive(true);
        //버튼 끄고
        buttonObj.SetActive(false);
        //레벨올리고
        level++;
        //버퍼파워1 씩 증가
        buff_power++;

        //좌측슬라이더UI의 버프상세내용 설정 메서드 호출.   탭 카운트 초기화도 여기서 해줄거임.     
        //바뀐내용 적용
        leftUIController.SetBuffDetails();

    }
}
