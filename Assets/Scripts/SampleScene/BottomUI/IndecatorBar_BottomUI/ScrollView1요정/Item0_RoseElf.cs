using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 장미의 요정 소환 버튼 아이템 스크립트. 
/// 
/// 하는 일: 조건을 체크하다가, 소환 조건을 만족하면 버튼을 활성화.  버튼이 눌리면 소환!(엘프제너레이터한테 소환 부탁하자.) . 다음 조건으로 업데이트. 
/// 
/// </summary>

public class Item0_RoseElf : MonoBehaviour
{
    //장미 엘프 레벨
    public int level;
    //초당 치유력
    public int heartOneSec;
    //버튼 - 상향될 치유력, 소모 하트
    public int heartOneSecIncreasement, price;
    //레벨제한
    public int qulificationTearLevel;



    //UI
    public Text detailText, levelText, btn_increaseText, btn_priceText, btnCover_Text;
    public GameObject generateBtnObj, upgradeBtnObj, coverBtnObj;

    //엘프 제너레이터
    public ElfGenerator elfGenerator;

    //소환조건에 맞는지, 이미 소환되었는가?
    public bool isSohwan, isalreadySohwaned;

    //new 아이콘
    public GameObject newicon_elf;

    PlayerData playerData;


    // Start is called before the first frame update
    void Start()
    {
        //초기화. 
        level = 0;
        heartOneSec = 0;
        heartOneSecIncreasement = 2;
        price = 20;
        qulificationTearLevel = 10;

        //처음엔 비활성화.
        generateBtnObj.SetActive(false);
        coverBtnObj.SetActive(true);

        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        playerData.lvl_Item0_RoseElf = level;
        GameObject.Find("=====BottomUI=====").GetComponent<NewIconController>().lvl_RoseElf = level;    //new 아이콘을 위한 갱신
        //저장
        playerData.heartOneSec = heartOneSec;
        playerData.elfProvidesOneSec_total = heartOneSec;

        //소환조건체크
        if (playerData.lvl_item_Tear >= 10)
        {

            if (level == 0)
            {
                //소환버튼 활성화 
                generateBtnObj.SetActive(true);
                btn_increaseText.text = "+" + heartOneSecIncreasement + " 치유력";
                btn_priceText.text = price.ToString();
                coverBtnObj.SetActive(false);

                //new 아이콘 활성화
                newicon_elf.SetActive(true);
            }
        }

        //업그레이드 조건 체크
        if (isalreadySohwaned)
        {
            if (playerData.heart >= price)
            {
                GameObject.Find("=====BottomUI=====").GetComponent<NewIconController>().roseElf_CanUpgrade = true;
                upgradeBtnObj.SetActive(true);
                coverBtnObj.SetActive(false);
            }
            else
            {
                GameObject.Find("=====BottomUI=====").GetComponent<NewIconController>().roseElf_CanUpgrade = false;
                coverBtnObj.SetActive(true);
                upgradeBtnObj.SetActive(false);
            }
        }



        if (level == 0)
        {
            //데이터 UI에 맞춤적용.
            detailText.text = "초당 치유력 " + heartOneSec;
            levelText.text = "레벨 " + level;

            btnCover_Text.text = "눈물 레벨 " + qulificationTearLevel;
        }
        else { 
            //데이터 UI에 맞춤적용.
            detailText.text = "초당 치유력 " + heartOneSec;
            levelText.text = "레벨 " + level;
            //btnCover_Text.text = " ";
        }

    }



    //소환 버튼이 눌림!!(엘프제너레이터한테 소환 부탁하자.) 버튼의 온클릭 속성으로 호출한다.
    public void OnGenerateRoseElfBtnClicked()
    {
        //소환 하면서 상세내용도 업데이트 하고. 
 
        level ++;
        heartOneSec += heartOneSecIncreasement;
        heartOneSecIncreasement = 10;
        price = 30;
        //qulificationTearLevel = 10;

        btn_increaseText.text = "+" + heartOneSecIncreasement + " 치유력";
        btn_priceText.text = price.ToString();

        generateBtnObj.SetActive(false);
        //btnCovoerObj.SetActive(true);
        //upgradeBtnObj.SetActive(true);

        elfGenerator.GenerateRoseElf();

        isalreadySohwaned = true;

        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.skill);
    }

    //업그레이드 버튼이 눌림!!
    public void OnUpgradeRoseElfBtnClicked()
    {
        level++;
        heartOneSec += heartOneSecIncreasement;
        heartOneSecIncreasement = 1*level;
        price += 110*level;
        //qulificationTearLevel = 10;

        btn_increaseText.text = "+" + heartOneSecIncreasement + " 치유력";
        btn_priceText.text = price.ToString();


        //비용 지불
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heart -= price;

        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.levelup);
    }
}
