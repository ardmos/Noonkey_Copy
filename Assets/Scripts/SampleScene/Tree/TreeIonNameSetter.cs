using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 하단 UI 트리 스크롤뷰의 이름과 아이콘을 자동으로 설정해주는 스크립트.
/// 붙이기만 하면 됩니다!
/// </summary>

public class TreeIonNameSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string tmpObjName = gameObject.name;
        string[] tmpSplit = tmpObjName.Split('(');
        string elfname = null;
        for (int i = 0; i < tmpSplit[1].Length - 1; i++)
        {
            elfname += tmpSplit[1][i];
        }
        transform.GetComponentInChildren<Text>().text = elfname;

        string path = null;
        //Debug.Log(tmpSplit[0][tmpSplit[0].Length - 1]);
        if (tmpSplit[0][tmpSplit[0].Length - 1].CompareTo('0') == 0)
        {
            //Debug.Log("Here"+gameObject.name);
            path = "TreeIcons/TREE-10";
        }
        else
        {
            path = "TreeIcons/TREE-0" + tmpSplit[0][tmpSplit[0].Length - 1];
        }

        //Debug.Log(path);
        Sprite sprite = Resources.Load<Sprite>(path);
        transform.GetComponentInChildren<Image>().sprite = sprite;

    }

}
