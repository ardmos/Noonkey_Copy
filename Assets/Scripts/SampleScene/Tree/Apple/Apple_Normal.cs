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
        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.hearflower);

        int gainheart = GameObject.Find("PlayerData").GetComponent<PlayerData>().GetCurrentCureAtOneTap() * 100;
        GameObject.Find("PlayerData").GetComponent<PlayerData>().heart += gainheart;
        GameObject prefObj = Instantiate(gUTMC) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>().parent);
        prefObj.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + 10);
        prefObj.GetComponent<GoingUpTextMessageController>().StartGUTM(gainheart);

        Destroy(gameObject);
    }
}
