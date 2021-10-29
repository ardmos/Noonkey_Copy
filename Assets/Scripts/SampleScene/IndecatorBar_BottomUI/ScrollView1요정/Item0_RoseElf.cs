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
    public GameObject btnObj, btnCovoerObj;


    //눈물스킬컨트롤러
    public Item_Tear item_Tear;

    //엘프 제너레이터
    public ElfGenerator elfGenerator;

    //소환조건에 맞는지
    public bool isSohwan;

    // Start is called before the first frame update
    void Start()
    {
        //초기화. 
        level = 0;
        heartOneSec = 10;
        heartOneSecIncreasement = 2;
        price = 20;
        qulificationTearLevel = 10;

        //처음엔 비활성화.
        btnObj.SetActive(false);
        btnCovoerObj.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //저장
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heartOneSec = heartOneSec;
        GameObject.Find("PlayerData").GetComponent<PlayerData>().elfProvidesOneSec_total = heartOneSec;

        //소환조건체크
        if (item_Tear.level>=10)
        {

            if (level == 0)
            {
                //소환버튼 활성화 
                btnObj.SetActive(true);
                btn_increaseText.text = "+" + heartOneSecIncreasement + " 치유력";
                btn_priceText.text = price.ToString();
                btnCovoerObj.SetActive(false);
            }
        }

        if (level == 0)
        {
            //데이터 UI에 맞춤적용.
            detailText.text = "초당 치유력 " + heartOneSec;
            levelText.text = "레벨 " + level;

            btnCover_Text.text = "눈물 레벨 " + qulificationTearLevel;
        }
        else if (level == 1)
        {
            //데이터 UI에 맞춤적용.
            detailText.text = "초당 치유력 " + heartOneSec;
            levelText.text = "레벨 " + level;

            btnCover_Text.text = " ";
        }

    }



    //버튼이 눌리면 소환!(엘프제너레이터한테 소환 부탁하자.) 버튼의 온클릭 속성으로 호출한다.
    public void OnGenerateRoseElfBtnClicked()
    {
        //소환 하면서 버튼 비활성화도 하고 상세내용도 업데이트 하고. 
 
        level ++;
        heartOneSec += heartOneSec + heartOneSecIncreasement;
        heartOneSecIncreasement = 2;
        price = 30;
        qulificationTearLevel = 10;

        btn_increaseText.text = "+" + heartOneSecIncreasement + " 치유력";
        btn_priceText.text = price.ToString();

        btnObj.SetActive(false);
        btnCovoerObj.SetActive(true);


        elfGenerator.GenerateRoseElf();
    }
}
