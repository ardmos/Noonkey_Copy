using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 엘프 소환을 담당하는 메서드가 있는 스크립트.
/// 
/// 엘프소환담당메서드  -->> 얘네들 다 RoseElfDDADDan에서 함.  3번 빼고.
///   1,2번 애니메이션으로 해결하자. 애니메이션만 호출하면 되게끔. 
///   1. 요정 등장화면 출력
///   2. 요정이 밑에서 스르르 생긴 다음 수직 상승 후 10시 방향으로 작아지면서 날아감.
///   
///   3. 애니메이션 다 끝나고나면 장미엘프 오브젝트 생성. 돌아다니고 장미 떨어뜨리는. 
/// </summary>
public class ElfGenerator : MonoBehaviour
{
    public GameObject roseElf등장Obj, roseElfPrefObj;


    private void Start()
    {
        roseElf등장Obj.SetActive(false);
    }


    //등장애니메이션 호출 메서드 
    public void GenerateRoseElf()
    {
        Debug.Log("장미요정 소환 메서드가 호출되었어요!");

        roseElf등장Obj.SetActive(true);
    }

    //등장애니메이션 종료시 호출되는 메서드
    public void GiveLifeRoseElf()
    {
        //=====Elves===== 프리팹을 만들어서 자식으로 넣어준다. 
        GameObject prefObj = Instantiate(roseElfPrefObj) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(GameObject.Find("=====Elves=====").GetComponent<RectTransform>());
        prefObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
