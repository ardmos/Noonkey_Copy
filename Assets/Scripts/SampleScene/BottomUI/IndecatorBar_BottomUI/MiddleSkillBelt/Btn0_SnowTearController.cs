using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// (스킬)눈꽃눈물 기능 구현 부분
/// 
/// 0. 스킬 활성화 메서드. 
/// 
/// --- 스킬벨트 ---
/// 1. 사용시 화면 배경이 바뀐다.(눈꽃 내리는 효과들도 재생) -> 스킬 끝나면 다시 돌아와야함. 
/// 2. 1분간 초당 10회 자동탭 효과 (1초 지날때마다 획득량*10 획득시킴)
/// 3. 재사용대기시간 1분.
/// 4. 스킬 아이콘이 불투명해지면서 스킬 효과 지속시간을 표현하는 테두리 게이지가 줄어들면서 중앙에는 초당 획득량이 표시된다(텍스트는 점멸).
/// 5. 1분의 지속시간이 끝나면  재사용대기시간이 시작, 표시된다. 해당 불투명은 아래쪽부터 지난시간/남은 시간만큼 천천히 걷힌다.
/// </summary>


public class Btn0_SnowTearController : MonoBehaviour
{
    //전용 배경 이미지
    public GameObject bgImg;
    //커버 이미지, 옐로우 게이지 이미지
    public GameObject image_Cover, image_YellowGage;
    //텍스트 오브젝트
    public GameObject textObject;
    //플레이어데이타
    public PlayerData playerData;


    private void Start()
    {
        //초기화

        bgImg.SetActive(false);
        image_Cover.SetActive(true);
        image_YellowGage.SetActive(false);
        textObject.GetComponent<Text>().text = "";
        textObject.SetActive(false);

    }


    //스킬 버튼 활성화 메서드
    public void ActivateButton()
    {
        //커버 끄기
        image_Cover.SetActive(false);
    }

    //스킬 발동 메서드  버튼의 온클릭 속성으로 호출됨.
    public void OnActivateSkillButtonClicked()
    {
        //스킬 발동!
        Debug.Log("스킬 발동!");

        // 1. 사용시 화면 배경이 바뀐다.
        bgImg.SetActive(true);
        image_Cover.GetComponent<Image>().fillAmount = 1f;
        image_Cover.SetActive(true);
        image_YellowGage.GetComponent<Image>().fillAmount = 1f;
        image_YellowGage.SetActive(true);
        textObject.SetActive(true);
        // 2. 1분간 초당 10회 자동탭 효과 (1초 지날때마다 획득량*10 획득시킴)
        StartCoroutine(AutoTap());               
    }

    // 2. 1분간 초당 10회 자동탭 효과 메서드 (1초 지날때마다 획득량*10 획득시킴)
    IEnumerator AutoTap()
    {
 
        for (int i = 60; i > 0; i--)
        {            
            // 2. 1분간 초당 10회 자동탭 효과 (1초 지날때마다 획득량*10 획득시킴)
            playerData.AddHeart(playerData.currentCureAtOneTap * 10);
            // 4. 스킬 아이콘이 불투명해지면서 스킬 효과 지속시간을 표현하는 테두리 게이지가 줄어들면서 중앙에는 초당 획득량이 표시된다(텍스트는 점멸)
            //Debug.Log((float)i + ", " + (float)60);
            image_YellowGage.GetComponent<Image>().fillAmount = (float)i / (float)60;
            textObject.GetComponent<Text>().text = (playerData.currentCureAtOneTap * 10).ToString();
            textObject.GetComponent<Animator>().SetBool("blink", true);
            yield return new WaitForSeconds(1f);
        }
        textObject.GetComponent<Animator>().SetBool("blink", false);
        image_YellowGage.SetActive(false);
        //끝나면! 배경 다시 원래대로 해주고 5번으로.
        bgImg.SetActive(false);
        StartCoroutine(CoolTime());
    }

    // 5. 1분의 지속시간이 끝나면 재사용대기시간(1분)이 시작, 표시된다. 해당 불투명은 아래쪽부터 지난시간/남은 시간만큼 천천히 걷힌다.
    IEnumerator CoolTime()
    {        
        for (int i = 60; i > 0; i--)
        {            
            textObject.GetComponent<Text>().text = i.ToString();

            //Debug.Log((float)i + ", " + (float)60);
            image_Cover.GetComponent<Image>().fillAmount = (float)i / (float)60;
            yield return new WaitForSeconds(1f);
        }
        image_Cover.SetActive(false);
        textObject.SetActive(false);
    }
}
