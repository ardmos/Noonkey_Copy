using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 장미 프리팹.!  터치하면 현재 Item0_RoseElf의 초당 치유량 * 10 만큼 얻어짐!  장미프리팹 머리 위에 뾰롱 하고 뜨기도 함. 
/// 


public class RoseObj : MonoBehaviour
{
    public GameObject gUTMprefObj;

    //아래에 도착했나?  도착했을때만 터치 되게끔.
    public bool isarrived;

    private void Start()
    {
        isarrived = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isarrived = true;
    }

    //터치하면 호출되는 메서드.  인스펙터에서 버튼 온클릭 속성으로 호출한다.
    public void OnRoseClick()
    {
        if (!isarrived)
        {
            return;
        }
        int gainheart = GameObject.Find("Item0(장미의 요정)").GetComponent<Item0_RoseElf>().heartOneSec * 10;
        //현재 Item0_RoseElf의 초당 치유량 * 10 만큼 얻어짐!
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heart += gainheart;
        //머리 위에 얻은 양이 뾰롱 하고 뜨기도 함. 
        GameObject prefObj = Instantiate(gUTMprefObj) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>());
        prefObj.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        prefObj.GetComponent<GoingUpTextMessageController>().StartGUTM(gainheart);
        //마지막으로 스스로 파괴
        Destroy(gameObject);
    }
}
