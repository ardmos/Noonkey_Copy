using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//전달받은 텍스트값 노출, 샤아아 위로 올라가다가 셀프디스트로이. 
public class GoingUpTextMessageController : MonoBehaviour
{
    public void StartGUTM(int numtext)
    {
        GetComponent<Text>().text = numtext.ToString();

        //올라간다.
        StartCoroutine(GoingUp());


    }
    

    IEnumerator GoingUp()
    {
        for (int i = 0; i < 30; i+=5)
        {
            yield return new WaitForSeconds(0.1f);
            GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, i);
        }

        //셀프 디스트로이
        Destroy(gameObject);
    }

}
