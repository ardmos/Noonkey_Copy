using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 하단UI 요정 스크롤뷰에  요정 아이콘 이미지와 이름을 일일히 입력하기 번거로워서 만든 스크립트.
/// 디테일 입력은 다른곳에서 한다.  이곳은 아이콘과 이름만 설정해줌.
/// 
/// 사용법: 오브젝트에 붙이기만 하면 됩니당!
/// </summary>

public class ItemElfIconNameSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string tmpObjName = gameObject.name;
        string[] tmpSplit = tmpObjName.Split('(');
        string elfname = null;
        for (int i = 0; i < tmpSplit[1].Length-1; i++)
        {
            elfname += tmpSplit[1][i];
        }
        transform.GetComponentInChildren<Text>().text = elfname;

        string path = "Elf/elf_0" + tmpSplit[0][tmpSplit[0].Length - 1];
        Sprite sprite = Resources.Load<Sprite>(path);
        transform.GetComponentInChildren<Image>().sprite = sprite;
              
    }
}
