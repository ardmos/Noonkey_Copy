using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 열매 두 가지 중 하나를 랜덤으로 골라서 순서대로 맺히게 한다.   쿨 5초.   남은 자리가 없으면 안맺힌다.
/// 
/// </summary>
public class Tree1 : MonoBehaviour
{
    //열매 두 가지, 열매포인트 두 곳.
    public GameObject appleBig, appleNormal, applePoint1Obj, applePoint2Obj;
        

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(CheckTreeApples());
    }


    IEnumerator CheckTreeApples()
    {
        yield return new WaitForSeconds(5f);

        //열매 포인트 차례대로 확인. 
        if (applePoint1Obj.GetComponent<RectTransform>().childCount == 0)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    GameObject prefObj0 = Instantiate(appleBig) as GameObject;
                    prefObj0.GetComponent<RectTransform>().SetParent(applePoint1Obj.GetComponent<RectTransform>());
                    prefObj0.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    break;
                case 1:
                    GameObject prefObj1 = Instantiate(appleNormal) as GameObject;
                    prefObj1.GetComponent<RectTransform>().SetParent(applePoint1Obj.GetComponent<RectTransform>());
                    prefObj1.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    break;
                default:
                    break;
            }
        }
        else if (applePoint2Obj.GetComponent<RectTransform>().childCount == 0)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    GameObject prefObj0 = Instantiate(appleBig) as GameObject;
                    prefObj0.GetComponent<RectTransform>().SetParent(applePoint2Obj.GetComponent<RectTransform>());
                    prefObj0.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                    break;
                case 1:
                    GameObject prefObj1 = Instantiate(appleNormal) as GameObject;
                    prefObj1.GetComponent<RectTransform>().SetParent(applePoint2Obj.GetComponent<RectTransform>());
                    prefObj1.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
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
