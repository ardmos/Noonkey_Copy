using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 하단 인디케이터 바에 정보 출력하는 스크립트.
/// </summary>
public class IndecatorBarController : MonoBehaviour
{
    //플레이어 데이타
    public PlayerData playerData;

    //인디케이터 텍스트들
    public Text heartText, tearText, elfText, diaText;

    public BottomUIController bottomUIController;

    //이미 elf회복량 텍스트가 점멸중인지
    public bool isElfTextBlink;
    //점멸 애니메이션
    public Animator elfTextBlinkAnimator;

    // Update is called once per frame
    void Update()
    {
        ShowDataOnIndecatorBar();   // 정보를 매 프레임마다 갱신시켜준다.
    }

    //하단 인디케이터 바에 정보 출력하는 부분
    void ShowDataOnIndecatorBar()
    {
        heartText.text = playerData.GetHeartCount().ToString();
        tearText.text = playerData.GetCurrentCureAtOneTap().ToString();
        elfText.text = playerData.heartOneSec.ToString();
        //elf의 초당 회복량이 10 이상일 때 인디케이터 텍스트 점멸.
        if (isElfTextBlink == false && playerData.heartOneSec >= 10)
        {
            isElfTextBlink = true;
            elfTextBlinkAnimator.SetBool("blink", true);
        }
        diaText.text = playerData.GetDiaCount().ToString();
    }


    public void UpAnimEnd()
    {
        GetComponent<Animator>().SetTrigger("upped");
        //스크롤뷰 출력
        bottomUIController.OpenRecentScrollView();
    }
    public void DownAnimEnd()
    {
        GetComponent<Animator>().SetTrigger("downed");
    }



}
