using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 눈물레벨 2때 개방되는 스킬. 
/// 역기서는 조건만 체크하고 실제 스킬 발동/종료는  스킬벨트에있는 버튼의 스크립트에서 진행한다. 
/// 
/// 1. 조건체크, 스킬벨트 스킬 활성화.
/// 
/// --- 스킬벨트 ---
/// 1. 사용시 화면 배경이 바뀐다.
/// 2. 1분간 초당 10회 자동탭 효과 (1초 지날때마다 획득량*10 획득시킴)
/// 3. 재사용대기시간 10분.
/// 4. 스킬 아이콘이 불투명해지면서 스킬 효과 지속시간을 표현하는 테두리 게이지가 줄어들면서 중앙에는 초당 획득량이 표시된다(텍스트는 점멸).
/// 5. 1분의 지속시간이 끝나면  재사용대기시간이 시작, 표시된다. 해당 불투명은 아래쪽부터 지난시간/남은 시간만큼 천천히 걷힌다.
/// </summary>

public class Item_SnowTear : MonoBehaviour
{
    public int level; //눈꽃스킬레벨
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

    //플레이어 데이타
    public PlayerData playerData;
    //눈물스킬컨트롤러
    public Item_Tear item_Tear;
    //Btn0_눈꽃눈물 컨트롤러
    public Btn0_SnowTearController btn0_SnowTearController;

    // Start is called before the first frame update
    void Start()
    {
        itemDetail.text = "1분간 초당 10회의 자동탭(재사용대기시간 10분)";
        itemLevel.text = "레벨 " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        switch (level)
        {
            case 0:
                //커버 켜고
                buttonCovoerObj.SetActive(true);
                //버튼 끄고
                buttonObj.SetActive(false);
                btnCover_qualification.text = "눈물레벨 2";

                //눈꽃눈물 스킬이 2일때 개방됨. 
                if (item_Tear.level >= 2 )
                {
                    //커버 끄고
                    buttonCovoerObj.SetActive(false);
                    //버튼 켜고
                    buttonObj.SetActive(true);
                }
                
                break;
            default:
                //커버 켜고
                buttonCovoerObj.SetActive(true);
                //버튼 끄고
                buttonObj.SetActive(false);
                btnCover_qualification.text = "";
                break;
        }
    }

    //버튼 기능 - 벨트에 있는 스킬 아이콘 활성화 시키기, 레벨업, 다시 버튼 닫고 커버 씌우기.
    public void OnSnowTearUpgradeBtnClicked()
    {
        //레벨업
        level++;
        //스킬벨트 Btn0_SnowTear스킬 활성화.

    }
}
