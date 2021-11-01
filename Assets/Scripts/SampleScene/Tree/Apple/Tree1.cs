using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 열매 두 가지 중 하나를 랜덤으로 골라서 순서대로 맺히게 한다.   쿨 5초.   남은 자리가 없으면 안맺힌다.
/// 
/// 항상 소환 전에 캔버스에 위치하는 applePoint1,2 의 위치를 월드좌표상에 존재하는 애플포인트들의 스크린상 위치로 수정해준다.
/// 
/// </summary>
public class Tree1 : MonoBehaviour
{
    //열매 두 가지, 열매포인트 두 곳.
    public GameObject appleBig, appleNormal, applePoint1Obj, applePoint2Obj; //, canvasApplePoint0, canvasApplePoint1 ;
        

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(CheckTreeApples());

        //canvasApplePoint0 = GameObject.Find("canvasApplePoint0");
        //canvasApplePoint1 = GameObject.Find("canvasApplePoint1");

        //canvasApplePoint0.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(applePoint1Obj.transform.position);
        //canvasApplePoint1.GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(applePoint2Obj.transform.position);
    }


    IEnumerator CheckTreeApples()
    {
        yield return new WaitForSeconds(5f);

        //열매 포인트 차례대로 확인. 
        //if (canvasApplePoint0.GetComponent<RectTransform>().childCount == 0)
        if (applePoint1Obj.GetComponent<RectTransform>().childCount == 0)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    GameObject prefObj0 = Instantiate(appleBig) as GameObject;
                    prefObj0.GetComponent<RectTransform>().SetParent(applePoint1Obj.GetComponent<RectTransform>());
                    prefObj0.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    break;
                case 1:
                    GameObject prefObj1 = Instantiate(appleNormal) as GameObject;
                    prefObj1.GetComponent<RectTransform>().SetParent(applePoint1Obj.GetComponent<RectTransform>());
                    prefObj1.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    break;
                default:
                    break;
            }
        }
        //else if (canvasApplePoint1.GetComponent<RectTransform>().childCount == 0)
        else if (applePoint2Obj.GetComponent<RectTransform>().childCount == 0)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    GameObject prefObj0 = Instantiate(appleBig) as GameObject;
                    prefObj0.GetComponent<RectTransform>().SetParent(applePoint2Obj.GetComponent<RectTransform>());
                    prefObj0.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    break;
                case 1:
                    GameObject prefObj1 = Instantiate(appleNormal) as GameObject;
                    prefObj1.GetComponent<RectTransform>().SetParent(applePoint2Obj.GetComponent<RectTransform>());
                    prefObj1.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    break;
                default:
                    break;
            }
        }
        else
        {
            Debug.Log("두 포인트 모두 열매가 존재...");
        }

        StartCoroutine(CheckTreeApples());
    }
}
