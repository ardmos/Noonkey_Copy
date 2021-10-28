using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 캐릭터의 모션을 관장하는 메서드들의 모음입니다.
/// 1. 눈물 흘리는 메서드 (느린 터치 / 빠른 터치)
/// 2. 알맞은 캐릭터 이미지 배치 메서드 (눈나0은 Wig 비활성화)
/// </summary>

public class CharacterController_m : MonoBehaviour
{
    //캐릭터 파츠들
    public GameObject body, lArm, lHand, rArm, rHand, sadFace, wig;

    //알맞은 이미지들 (바디, 왼팔, 왼손, 오른팔, 오른손, 얼굴, 가발 순서)
    public Sprite[] level0, level2, level6;

    //플레이어 데이터
    public PlayerData playerData;

    //눈물발사 터치 스피드
    public string touchspeed;
    //눈물흘리기 애니메이션
    public Animator sadFace_animator;

    private void Start()
    {
        try
        {
            InitCharacter(playerData.playerLevel);
        }
        catch (System.Exception)
        {

            throw;
        }
    }


    //2.알맞은 캐릭터 이미지 배치 (눈나0은 Wig 비활성화)  레벨업 할 때마다 호출되어야함.  sadface는 비활성화 해뒀다가 터치발생시에만 활성화해줘야함(애니메이션으로 처리. 애니메이션 시작할 때 눈물 발사 메서드를 애니메이션이벤트로 호출). 
    void InitCharacter(int playerlevel)
    {
        switch (playerlevel)
        {
            case 0:
            case 1:
                body.GetComponent<Image>().sprite = level0[0];
                lArm.GetComponent<Image>().sprite = level0[1];
                lHand.GetComponent<Image>().sprite = level0[2];
                rArm.GetComponent<Image>().sprite = level0[3];
                rHand.GetComponent<Image>().sprite = level0[4];
                sadFace.GetComponent<Image>().sprite = level0[5];
                sadFace.GetComponent<Image>().enabled = false;
                wig.GetComponent<Image>().enabled = false;
                break;
            case 2:
            case 3:
            case 4:
            case 5:
                body.GetComponent<Image>().sprite = level2[0];
                lArm.GetComponent<Image>().sprite = level2[1];
                lHand.GetComponent<Image>().sprite = level2[2];
                rArm.GetComponent<Image>().sprite = level2[3];
                rHand.GetComponent<Image>().sprite = level2[4];
                sadFace.GetComponent<Image>().sprite = level2[5];
                sadFace.GetComponent<Image>().enabled = false;
                wig.GetComponent<Image>().sprite = level2[6];
                break;
            case 6:
                body.GetComponent<Image>().sprite = level6[0];
                lArm.GetComponent<Image>().sprite = level6[1];
                lHand.GetComponent<Image>().sprite = level6[2];
                rArm.GetComponent<Image>().sprite = level6[3];
                rHand.GetComponent<Image>().sprite = level6[4];
                sadFace.GetComponent<Image>().sprite = level6[5];
                sadFace.GetComponent<Image>().enabled = false;
                wig.GetComponent<Image>().sprite = level6[6];
                break;

            default:
                break;
        }
    }



    #region 눈물 흘리기 구현 부분. 슬픈얼굴, 눈물발사 처리
    //1. 눈물 흘리는 메서드(공통) : sadface, 4가지 눈물 발사 메서드는 sadface 애니메이션에서 애니메이션 이벤트로 호출해서 발사함.

    //화면 터치 시 GameManager로부터 호출되는 sadFace 애니메이션 실행 메서드.
    public void MakeSadFace(string touchspeed)
    {      
        //터치스피드는 일단 저장. sadface 애니메이션에서 호출되는 MakeTear 메서드에서 사용됨.
        this.touchspeed = touchspeed;
        //sadface 애니메이션 실행.
        sadFace_animator.SetTrigger("cry");       
    }

    //sadface 애니메이션에서 애니메이션 이벤트로 호출되는 메서드. (애니메이션 이벤트 -> SadFace.cs -> 현 메서드)
    public void MakeTear()
    {
        Debug.Log("눈물 발사!!" + touchspeed);
        //눈물 발사 4가지 


        //1. 눈물 흘리는 메서드(느린) : 발사 프리팹(티어드랍)
        if (touchspeed == "slow")
        {

        }
        //1. 눈물 흘리는 메서드(빠른) : 발사 프리팹(티어스톰), 어깨들썩애니메이션 실행
        else if (touchspeed == "fast")
        {

        }
        else Debug.Log("MakeTear에 잘못된 파라미터가 넘어왔습니다. slow나 fast 둘 중 하나로 변경해주세요.");
    }
    #endregion



}
