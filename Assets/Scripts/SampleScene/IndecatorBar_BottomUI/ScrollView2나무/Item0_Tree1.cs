using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 나무1단계~~~ 스크립트~~ 
/// 
/// 하는 일: 조건 체크, 버튼 개방. 버튼 누르면 뒤편에 나무오브젝트 생성.(열매 두 개 자동으로 열리는)   버튼 누르고나면 성장완료커버 씌워두기.
/// 
/// </summary>

public class Item0_Tree1 : MonoBehaviour
{
    public GameObject btnObj, btnCover_notYet, btnCover_AlreadyGrown;

    public Item_Tear item_Tear;
    public Item0_RoseElf item0_RoseElf;

    public bool isAlreadyGrown;


    //나무오브젝트 정보. 프리팹. 
    public GameObject treeObject;
    //나무심을곳
    public GameObject tree__PointObj;

    // Start is called before the first frame update
    void Start()
    {
        //초기화  
        btnObj.SetActive(false);
        btnCover_notYet.SetActive(true);
        btnCover_AlreadyGrown.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //눈물10 이상, 요정 1 이상
        if (item_Tear.level>=10 && item0_RoseElf.level>=1 )
        {
            if (isAlreadyGrown == false)
            {
                //버튼 개방.
                btnObj.SetActive(true);
                btnCover_notYet.SetActive(false);
                btnCover_AlreadyGrown.SetActive(false);
            }
            else
            {
                //이미 키웠어요~!
                btnObj.SetActive(false);
                btnCover_notYet.SetActive(false);
                btnCover_AlreadyGrown.SetActive(true);
            }

        }
    }

    //버튼 누르면 발동하는 메서드. 온클릭 속성으로 이어준다.
    public void OnGenerateTree1ButtonClicked()
    {
        isAlreadyGrown = true;

        //나무 오브젝트 생성
        GameObject prefObj = Instantiate(treeObject) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(tree__PointObj.GetComponent<RectTransform>());
        prefObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

    }
}
