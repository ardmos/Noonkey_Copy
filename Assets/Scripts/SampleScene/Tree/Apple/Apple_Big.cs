using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 큰사과.  누르면 현재 탭 당 획득량의 200배. 
/// </summary>


public class Apple_Big : MonoBehaviour
{
    public GameObject gUTMC;

    public void OnButtonClicked()
    {
        int gainheart = GameObject.Find("PlayerData").GetComponent<PlayerData>().GetCurrentCureAtOneTap() * 200;
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heart += gainheart;
        GameObject prefObj = Instantiate(gUTMC) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>().parent);
        prefObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + 10);
        prefObj.GetComponent<GoingUpTextMessageController>().StartGUTM(gainheart);

        Destroy(gameObject);
    }
}
