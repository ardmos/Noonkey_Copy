using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 하단 버튼들의 new 아이콘을 띄워주는 역할을 하는 스크립트. 
/// 
/// </summary>

public class NewIconController : MonoBehaviour
{
    //눈물 
    public int lvl_tear, price_tear, lvl_magicTearStream, lvl_snowTear;
    //요정
    public int lvl_RoseElf;
    public bool roseElf_CanUpgrade;
    //나무
    public int lvl_tree1;
    public bool isAlreadyGrown;

    //new 아이콘 오브젝트들.
    public GameObject newicon_tree, newicon_elf, newicon_tear;

    //플레이어데이타
    PlayerData playerData;

    public bool isnewicon_tearOn, isnewicon_elfOn;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        price_tear = 20;
    }

    // Update is called once per frame
    void Update()
    {
        isnewicon_tearOn = false;
        isnewicon_elfOn = false;
        #region 눈물
        //눈물 
        if (playerData.heart >= price_tear)
        {
            //newicon_tear.SetActive(true);
            isnewicon_tearOn = true;
        }
        else
        {
            //newicon_tear.SetActive(false);
        }
        //마법의 샘
        //개방조건은 마법의눈물샘레벨1 - 눈물의치유력 레벨 5,  마법의눈물샘레벨2 - 눈물의치유력레벨30
        if (lvl_magicTearStream == 1)
        {
            if (lvl_tear >= 5)
            {
                //조건 만족! 
                //new 아이콘 켜고
                //newicon_tear.SetActive(true);
                isnewicon_tearOn = true;
            }
            else
            {
                //new 아이콘 끄고
                //newicon_tear.SetActive(false);
            }
        }
        else if (lvl_magicTearStream == 2)
        {
            if (lvl_tear >= 30)
            {
                //조건 만족! 
                //new 아이콘 켜고
                //newicon_tear.SetActive(true);
                isnewicon_tearOn = true;
            }
            else
            {
                //new 아이콘 끄고
                //newicon_tear.SetActive(false);
            }
        }
        else { } //Debug.Log("나머지 마법의눈물샘 레벨은 미개발."); }

        //눈꽃
        switch (lvl_snowTear)
        {
            case 1:
                //눈꽃눈물 스킬이 20일때 개방됨. 
                if (lvl_tear >= 20)
                {
                    //new 아이콘 켜고
                    //newicon_tear.SetActive(true);
                    isnewicon_tearOn = true;
                }
                else
                {
                    //new 아이콘 끄고
                    //newicon_tear.SetActive(false);
                }

                break;
            default:
                break;
        }

        if (isnewicon_tearOn)
        {
            newicon_tear.SetActive(true);
        }
        else newicon_tear.SetActive(false);
        #endregion
        #region 요정
        if (playerData.lvl_item_Tear >= 10 && playerData.lvl_Item0_RoseElf == 0)
        {
            //new 아이콘 활성화
            isnewicon_elfOn = true;
        }
        //else newicon_elf.SetActive(false);
        if (roseElf_CanUpgrade)
        {
            isnewicon_elfOn = true;
        }
        //else newicon_elf.SetActive(false);


        if (isnewicon_elfOn)
        {
            newicon_elf.SetActive(true);
        }
        else newicon_elf.SetActive(false);

        #endregion
        #region 나무
        //나무 1
        if (playerData.lvl_item_Tear >= 30 && playerData.lvl_Item0_RoseElf >= 10)
        {
            if (isAlreadyGrown == false)
            {
                //버튼 개방시 new 알림 추가.
                newicon_tree.SetActive(true);
            }
            else
            {
                //new 알림 종료.
                newicon_tree.SetActive(false);
            }

        }
        #endregion




    }
}
