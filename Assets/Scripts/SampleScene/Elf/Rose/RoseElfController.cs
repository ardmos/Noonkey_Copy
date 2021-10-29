using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 10초마다 장미 떨어뜨려야해요! 최대 4개! 
/// 장미는 프리팹.!  터치하면 현재 Item0_RoseElf의 초당 치유량 * 10 만큼 얻어짐!  장미프리팹 머리 위에 뾰롱 하고 뜨기도 함. 
/// </summary>

public class RoseElfController : MonoBehaviour
{
    public GameObject rosePrefObj;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DropRose(10));
    }


    IEnumerator DropRose(int intervalTime)
    {
        yield return new WaitForSeconds(10f);
        //장미프리팹 생성하기 
        GameObject prefObj = Instantiate(rosePrefObj) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(GameObject.Find("=====Elves=====").GetComponent<RectTransform>());
        prefObj.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;

        StartCoroutine(DropRose(10));
    }
}
