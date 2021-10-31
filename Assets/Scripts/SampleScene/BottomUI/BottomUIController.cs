using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// 1. 하단 UI 슬라이드 열기 닫기
/// 2. 하단 메뉴 버튼들 기능 구현 (눈물, 요정, 나무, 다이아상점, 꾸미기상점)
/// 
/// </summary>
/// 

public class BottomUIController : MonoBehaviour
{
    //현재 슬라이드 상태
    public enum UISlide_State
    {
        Closed,
        Opened
    }
    public UISlide_State slide_State;

    //현재 버튼들 상태
    public enum Button_State
    {
        Clicked,
        NonClicked
    }
    public Button_State[] btn_States;

    //버튼 Obj들
    public GameObject[] bottmBtns;
    public GameObject upDownBtns;

    //가장 최근에 열렸던 버튼 (눈물, 요정, 나무 중)
    public GameObject clickedBtn_recent;

    //버튼 이미지들
    [System.Serializable]
    public struct BtnSprites
    {        
        public Sprite[] sprites;
    }
    public List<BtnSprites> btnSprites;

    //스크롤뷰들
    public GameObject[] scrollView;
    //팝업들
    public GameObject popUp_DiaStore, popUp_DressStore;
    //슬라이드 열기닫기 애니메이터
    public Animator indecatoruiSlideAnimator;


    private void Start()
    {
        //처음엔 스크롤뷰 다 닫고 인디케이터바도 내려가있는 상태로 시작. 
        CloseEveryScrollView();
    }



    #region 슬라이드 열기 닫기 메서드.
    void OpenSlide()
    {
        //슬라이드 상태 갱신
        slide_State = UISlide_State.Opened;

        //업다운 버튼 이미지 갱신
        upDownBtns.GetComponent<Image>().sprite = btnSprites[5].sprites[1];

        //오픈 애니메이션 재생
        indecatoruiSlideAnimator.SetTrigger("up");

        //스크롤뷰도 열어줘야함   가장 최근에 열려있었던걸로. <-- 이건 애니메이션 끝날 때,  애니메이션 이벤트로 호출이 될거임. 인디케이터바컨트롤러-> 현 스크립트의 최근 스크롤뷰 열기 메서드.
    }
    //최근 스크롤뷰 열기 메서드. 애니메이션이벤트로 호출된 IndecatorBarController의 메서드에서 호출될것임.
    public void OpenRecentScrollView()
    {
        //Debug.Log("here");

        if (clickedBtn_recent == null)
        {
            clickedBtn_recent = bottmBtns[0];
        }
        if (clickedBtn_recent == bottmBtns[0]) OnButton0Clicked();
        else if (clickedBtn_recent == bottmBtns[1]) OnButton1Clicked();
        else if (clickedBtn_recent == bottmBtns[2]) OnButton2Clicked();
    }
    void CloseSlide()
    {
        //슬라이드 상태 갱신
        slide_State = UISlide_State.Closed;

        //업다운 버튼 이미지 갱신
        upDownBtns.GetComponent<Image>().sprite = btnSprites[5].sprites[0];

        //클로스 애니메이션 재생
        indecatoruiSlideAnimator.SetTrigger("down");

        //스크롤뷰도 닫아줘야함
        CloseEveryScrollView();
        //버튼 상태들 전부 nonclicked로 전환, 이미지도 전부 nonclicked로 변경
        for (int i = 0; i < btn_States.Length; i++)
        {
            btn_States[i] = Button_State.NonClicked;
        }
        for (int i = 0; i < bottmBtns.Length; i++)
        {
            bottmBtns[i].GetComponent<Image>().sprite = btnSprites[i].sprites[0];
        }
    }
    #endregion


    #region 눈물, 요정, 나무 스크롤뷰 띄우는 메서드.
    void OpenThisScrollView(int buttonIndex)
    {
        //최근열린버튼 갱신 
        clickedBtn_recent = bottmBtns[buttonIndex];
        //버튼 상태를 갱신해준다.
        MakeThisBtnStateClicked(btn_States[buttonIndex]);

        //버튼의 이미지도 갱신해준다
        MakeThisBtnHighlighted(bottmBtns[buttonIndex]);

        //슬라이드의 상태는 어떤가?
        if (slide_State == UISlide_State.Closed)
        {
            //닫혀있다면 열기 애니메이션을 실행시켜준다.
            OpenSlide();
            return;
        }

        for (int i = 0; i < this.scrollView.Length; i++)
        {
            if (this.scrollView[i] == scrollView[buttonIndex])
            {
                this.scrollView[i].SetActive(true);
            }
            else this.scrollView[i].SetActive(false);
        }
    }
    public void CloseEveryScrollView()
    {
        foreach (var item in this.scrollView)
        {
            item.SetActive(false);
        }
    }
    #endregion



    #region 버튼들 클릭됐을때 호출되는 OnClick 메서드들.
    public void OnButton0Clicked()
    {
        OpenThisScrollView(0);
    }
    public void OnButton1Clicked()
    {
        OpenThisScrollView(1);
    }
    public void OnButton2Clicked()
    {
        OpenThisScrollView(2);
    }

    public void OnButton3Clicked()
    {
        //버튼 상태를 갱신해준다.
        MakeThisBtnStateClicked(btn_States[3]);

        //버튼의 이미지도 갱신해준다
        MakeThisBtnHighlighted(bottmBtns[3]);

        //팝업을 열어준다
        popUp_DiaStore.SetActive(true);
    }
    public void OnButton4Clicked()
    {        
        //버튼 상태를 갱신해준다.
        MakeThisBtnStateClicked(btn_States[4]);

        //버튼의 이미지도 갱신해준다
        MakeThisBtnHighlighted(bottmBtns[4]);

        //팝업을 열어준다
        popUp_DressStore.SetActive(true);
    }
    public void OnButtonUpDownClicked()
    {
        //슬라이드 상태에 알맞는 메서드를 호출해준다.
        if (slide_State == UISlide_State.Closed)
        {
            //닫혀있다면 열기
            OpenSlide();
        }
        else
        {
            //열려있다면 닫기
            CloseSlide();
        }
    }
    #endregion

    #region 버튼의 상태를 갱신시켜주는 메서드.
    void MakeThisBtnStateClicked(Button_State button_State)
    {
        for (int i = 0; i < btn_States.Length; i++)
        {
            if (btn_States[i] == button_State)
            {
                btn_States[i] = Button_State.Clicked;
            }
            else btn_States[i] = Button_State.NonClicked;
        }
    }
    #endregion

    #region 클릭된 버튼의 이미지를 갱신시켜주는 메서드.
    void MakeThisBtnHighlighted(GameObject button)
    {
        for (int i=0; i<bottmBtns.Length; i++)
        {
            if (bottmBtns[i] == button)
            {
                bottmBtns[i].GetComponent<Image>().sprite = btnSprites[i].sprites[1];
            }
            else bottmBtns[i].GetComponent<Image>().sprite = btnSprites[i].sprites[0];
        }
    }
    #endregion

    #region 다이아상점, 꾸미기상점이 닫힐 때 호출되는 메서드. 최근 버튼 다시 하이라이트 시켜줌.
    public void HighlightRecentBtn()
    {
        MakeThisBtnHighlighted(clickedBtn_recent);
    }
    #endregion
}
