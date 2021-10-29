using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 하단 인디케이터 바에 정보 출력하는, 위 아래 이동 버튼 기능 처리하는 스크립트.
/// </summary>
public class IndecatorBarController : MonoBehaviour
{
    //플레이어 데이타
    public PlayerData playerData;

    //인디케이터 텍스트들
    public Text heartText, tearText, elfText, diaText;


    //스크롤뷰들
    public GameObject scrollView0, scrollView1, scrollView2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
        diaText.text = playerData.GetDiaCount().ToString();
    }



    //위 아래 이동 버튼 기능 처리 부분.  위<->아래 이동, 이동시작시 스크롤뷰 노출. 이동 종료시 스크롤뷰 숨김.   어떤 스크롤뷰 보고있는중인지 스테이터스 저장 기능. 

    //스크롤뷰 위아래로 열기 닫기
    //열기
    public void OpenBottomUI()
    {
        gameObject.GetComponent<Animator>().SetTrigger("up");
    }
    //닫기
    public void CloseBottomUI()
    {
        gameObject.GetComponent<Animator>().SetTrigger("down");
    }

    //스크롤뷰 노출 컨트롤. 
    public void UPSlide()
    {
        scrollView0.SetActive(true);
        scrollView1.SetActive(false);
        scrollView2.SetActive(false);
    }

    //ㅅ크롤뷰 숨김
    public void DownSlide()
    {
        scrollView0.SetActive(false);
        scrollView1.SetActive(false);
        scrollView2.SetActive(false);
    }

}
