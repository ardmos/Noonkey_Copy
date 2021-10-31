using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 일단은 팝업들 열고닫는것만 처리해주는 스크립트.
/// </summary>
public class TopUIController : MonoBehaviour
{
    public GameObject boxPopup, cupPopup, settingsPopup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnBoxBtnClicked()
    {
        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.tear);
        boxPopup.SetActive(true);
    }

    public void OnCupBtnClicked()
    {
        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.tear);
        cupPopup.SetActive(true);
    }

    public void OnSettingsBtnClicked()
    {
        //효과음!
        GameObject.Find("SFX").GetComponent<SFX_Controller>().PlaySFX(SFX_Controller.Sounds.tear);
        settingsPopup.SetActive(true);
    }

}
