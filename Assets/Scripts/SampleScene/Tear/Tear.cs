using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 발사되는 눈물 프리팹. 
/// 하는 일: 바닥이나 의자 콜라이더에 닿으면 자식으로 TearBlast 프리팹을 소환하고 현 오브젝트는 파괴된다. (TearBlast는 애니메이션이 끝나면 알아서 파괴된다. TearBlast의 애니메이션의 끝에는 Tear 오브젝트를 삭제하는 메서드를 호출하는 애니메이션 이벤트가 있다.)
///         + (회전 효과)
/// </summary>

public class Tear : MonoBehaviour
{
    //회전방향 설정을 위한 변수 캐릭터 컨트롤러에서 프리팹으로 눈물을 만들 때 방향을 정해준다.
    public bool tcd;
    public GameObject tearBlastPref;

    private void Update()
    {
        //true면 시계방향, false면 반시계 방향으로 회전
        if (tcd)
        {
            //Debug.Log(gameObject.GetComponent<RectTransform>().eulerAngles.z);        
            if (gameObject.GetComponent<RectTransform>().eulerAngles.z >= 30f)
            {
                transform.Rotate(0, 0, -80 * Time.deltaTime);
            }
        }
        else
        {
            if (gameObject.GetComponent<RectTransform>().eulerAngles.z >= 30f)                           
                transform.Rotate(0, 0, 80 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CallThisWhenTearDropped();
    }

    //바닥에 닿으면 호출되는 메서드. 지금 위치에 TearBlast 프리팹을 소환하고 현 오브젝트를 파괴시킨다.
    public void CallThisWhenTearDropped()
    {
        GameObject tearBlast = Instantiate(tearBlastPref) as GameObject;

        tearBlast.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>());
        tearBlast.GetComponent<RectTransform>().position = gameObject.GetComponent<RectTransform>().position;

        Destroy(gameObject);    //Tear는 파괴
    }
}
