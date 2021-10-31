using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 보통사과.  누르면 현재 탭 당 획득량의 100배. 
/// </summary>

public class Apple_Normal : MonoBehaviour
{
    public GameObject gUTMC;

    public void OnButtonClicked()
    {        
        int gainheart = GameObject.Find("PlayerData").GetComponent<PlayerData>().GetCurrentCureAtOneTap() * 100;
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heart += gainheart;
        GameObject prefObj = Instantiate(gUTMC) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>());
        prefObj.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        prefObj.GetComponent<GoingUpTextMessageController>().StartGUTM(gainheart);
    }
}
