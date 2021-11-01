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

    public bool isAlreadyGrown;


    //나무오브젝트 정보. 프리팹. 
    public GameObject treeObject;
    //나무심을곳
    public GameObject tree__PointObj;

    //new 아이콘
    public GameObject newicon_tree;

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

        //눈물30 이상, 요정 10 이상
        if (GameObject.Find("PlayerData").GetComponent<PlayerData>().lvl_item_Tear>= 30 && GameObject.Find("PlayerData").GetComponent<PlayerData>().lvl_Item0_RoseElf>=10 )
        {
            if (isAlreadyGrown == false)
            {
                //버튼 개방.
                btnObj.SetActive(true);
                btnCover_notYet.SetActive(false);
                btnCover_AlreadyGrown.SetActive(false);

                //버튼 개방시 new 알림 추가.
                newicon_tree.SetActive(true);
            }
            else
            {
                //이미 키웠어요~!
                btnObj.SetActive(false);
                btnCover_notYet.SetActive(false);
                btnCover_AlreadyGrown.SetActive(true);

                //new 알림 종료.
                newicon_tree.SetActive(false);
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
        prefObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 195f);
        //prefObj.transform.SetParent(tree__PointObj.transform);
        //prefObj.transform.position = new Vector3(0, 1.5f, 0f);
        //prefObj.transform.position = new Vector3(0f, 0f, 0f);
        //prefObj.transform.localScale = Vector3.one;

        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.create);
    }
}
