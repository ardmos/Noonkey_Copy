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
    //눈물 프리팹들
    public GameObject[] tear_drops, tear_storms;
    //눈물 발사 위치
    public GameObject lTearPoint, rTearPoint;

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
                //sadFace.GetComponent<Image>().enabled = false;   Idle애니메이션에서 해줍니다.
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
                //sadFace.GetComponent<Image>().enabled = false;   Idle애니메이션에서 해줍니다.
                wig.GetComponent<Image>().sprite = level2[6];
                break;
            case 6:
                body.GetComponent<Image>().sprite = level6[0];
                lArm.GetComponent<Image>().sprite = level6[1];
                lHand.GetComponent<Image>().sprite = level6[2];
                rArm.GetComponent<Image>().sprite = level6[3];
                rHand.GetComponent<Image>().sprite = level6[4];
                sadFace.GetComponent<Image>().sprite = level6[5];
                //sadFace.GetComponent<Image>().enabled = false;   Idle애니메이션에서 해줍니다.
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
        //Debug.Log("눈물 발사!!" + touchspeed);

        //1. 눈물 흘리는 메서드(느린) : 발사 프리팹(티어드랍)  
        if (touchspeed == "slow")
        {
            //2 가지 랜덤 발사
            TearGenerator(tear_drops[Random.Range(0, 2)]);
        }
        //1. 눈물 흘리는 메서드(빠른) : 발사 프리팹(티어스톰), 어깨들썩애니메이션 실행
        else if (touchspeed == "fast")
        {
            //2 가지 랜덤 발사
            TearGenerator(tear_storms[Random.Range(0, 2)]);
        }
        else Debug.Log("MakeTear에 잘못된 파라미터가 넘어왔습니다. slow나 fast 둘 중 하나로 변경해주세요.");
    }

    void TearGenerator(GameObject tearPrefabObj)
    {
        //눈물 프리팹 생성
        GameObject lTearObj = Instantiate(tearPrefabObj) as GameObject;
        GameObject rTearObj = Instantiate(tearPrefabObj) as GameObject;
        //우선 위치를 잡고
        lTearObj.GetComponent<RectTransform>().SetParent(lTearPoint.GetComponent<RectTransform>());
        lTearObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        rTearObj.GetComponent<RectTransform>().SetParent(rTearPoint.GetComponent<RectTransform>());
        rTearObj.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        //바로 발사도 해줘야함. 4 가지 각도 중 랜덤으로.
        int ranNum = Random.Range(0, 4); //랜덤넘버
        float mass = 10;//발사각을 조절해주는 매스
        switch (ranNum)
        {
            case 0:
                if (touchspeed == "slow") mass = 18;
                else mass = 12;
                break;
            case 1:
                if (touchspeed == "slow") mass = 20;
                else mass = 13;
                break;
            case 2:
                if (touchspeed == "slow") mass = 25;
                else mass = 14;                
                break;
            case 3:
                if (touchspeed == "slow") mass = 30;
                else mass = 15;                
                break;
            default:
                break;
        }

        //양쪽 눈가에서 똑같은게 반대로 발사되어야하는것을 잊지말자. lTearPoint, rTearPoint 두 곳에서 같은 값으로 동시 발사.
        lTearObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 120f);
        lTearObj.GetComponent<Tear>().tcd = true; //발사 방향을 결정해줍니다. 
        lTearObj.GetComponent<Rigidbody2D>().mass = mass;
        lTearObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(3000, 1500), ForceMode2D.Impulse);


        rTearObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, -120f);
        rTearObj.GetComponent<Rigidbody2D>().mass = mass;
        rTearObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3000, 1500), ForceMode2D.Impulse);


    }
    #endregion



}
