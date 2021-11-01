using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 
/// 화면 탭 인식 처리를 위한 스크립트.   
/// UI레이어가 아닌걸 눌렀을 때 재화를 획득시켜주자! 뿌슝빠슝!!
/// 
/// </summary>

public class ScreenTouchController : MonoBehaviour
{
    public GameManager gameManager;


    Touch tempTouches;

    // Update is called once per frame
    void Update()
    {
        //손가락 여러개 인식시키기로 변경하기 위해 변경.
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    tempTouches = Input.GetTouch(i);
                    if (tempTouches.phase == TouchPhase.Began)
                    {
                        gameManager.OnScreenBtnTouched();
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !IsPointerOverUIObject())
            {
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
                if (hitInformation.collider != null)
                {
                    //We should have hit something with a 2D Physics collider! 
                    GameObject touchedObject = hitInformation.transform.gameObject;
                    //touchedObject should be the object someone touched.
                    if (touchedObject.layer == 8)
                    {
                        //Debug.Log("터치 성공!!! :  " + touchedObject.name);

                        gameManager.OnScreenBtnTouched();
                    }

                }

            }
        }

 




    }

    // UI터치 시 GameObject 터치 무시하는 코드 -> 변형 해서 BottomUI가 터치 안됐을때만 재화 획득하게 만들것.
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        bool isBottomUI = false;

        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("BottomUI"))
            {
                isBottomUI = true;
            }
        }


        return isBottomUI;
    }
}
