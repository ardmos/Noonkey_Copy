using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 미구현 엘프들. 스크롤뷰 상에서 디테일 설명 문구 채워주기 위한 스크립트.
/// </summary>


public class Elf_Tmp : MonoBehaviour
{
    public string power_value;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponentsInChildren<Text>()[1].text = "초당 치유력 " + power_value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
