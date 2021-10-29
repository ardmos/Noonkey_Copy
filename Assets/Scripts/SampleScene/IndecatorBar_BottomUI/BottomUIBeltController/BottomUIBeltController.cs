using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 하단 벨트에 있는 버튼들.  하나 열면 다른애들 닫히게끔 해주는 컨트롤러.^^
/// </summary>

public class BottomUIBeltController : MonoBehaviour
{
    public GameObject btn0, btn1, btn2;
    public bool isbtn0, isbtn1, isbtn2;
    public Sprite[] spBtn0, spBtn1, spBtn2;

    public bool isScrollOpen;
    public GameObject ScrollView0, ScrollView1, ScrollView2;

    public IndecatorBarController indecatorBarController;
    public void OnBtn0Clicked()
    {
        btn0.GetComponent<Image>().sprite =spBtn0[1];
        btn1.GetComponent<Image>().sprite = spBtn1[0];
        btn2.GetComponent<Image>().sprite = spBtn2[0];

        if (isScrollOpen)
        {
            ScrollView0.SetActive(true);
            ScrollView1.SetActive(false);
            ScrollView2.SetActive(false);
        }
    }
    public void OnBtn1Clicked()
    {
        btn0.GetComponent<Image>().sprite = spBtn0[0];
        btn1.GetComponent<Image>().sprite = spBtn1[1];
        btn2.GetComponent<Image>().sprite = spBtn2[0];
        if (isScrollOpen)
        {
            ScrollView0.SetActive(false);
            ScrollView1.SetActive(true);
            ScrollView2.SetActive(false);
        }
    }
    public void OnBtn2Clicked()
    {
        btn0.GetComponent<Image>().sprite = spBtn0[0];
        btn1.GetComponent<Image>().sprite = spBtn1[0];
        btn2.GetComponent<Image>().sprite = spBtn2[1];
        if (isScrollOpen)
        {
            ScrollView0.SetActive(false);
            ScrollView1.SetActive(false);
            ScrollView2.SetActive(true);
        }
    }





    ///상하 슬라이드 버튼도 그냥 여기서 하자.
    ///
    public void OnUpDownBtnClicked()
    {
        if (isScrollOpen)
        {
            isScrollOpen = false;

            btn0.GetComponent<Image>().sprite = spBtn0[0];
            btn1.GetComponent<Image>().sprite = spBtn1[0];
            btn2.GetComponent<Image>().sprite = spBtn2[0];
            //열려있음 닫기 애니메이션 재생
            indecatorBarController.CloseBottomUI();
        }
        else
        {
            isScrollOpen = true;

            btn0.GetComponent<Image>().sprite = spBtn0[1];
            btn1.GetComponent<Image>().sprite = spBtn1[0];
            btn2.GetComponent<Image>().sprite = spBtn2[0];
            //닫혀있음 열기 애니메이션 재생
            indecatorBarController.OpenBottomUI();
        }
        
    }

}
