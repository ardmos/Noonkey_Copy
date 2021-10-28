using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전체적인 흐름을 관장합니다. 
/// 1. 가장 중요한 터치 인식.  빠른 터치인지 느린 터치인지 확인 후 캐릭터컨트롤러에서 알맞은 메서드 호출
/// 2. 씬이 열릴 때 마다 현재 날짜를 확인하여 출석체크를 해줍니다. 마지막 출석날짜와 현재 날짜가 다르다면 PlayerData에 총 출석 일수를 +1 해줍니다.  추가로 만약 지난번 출석 날짜가 오늘-1 과 같다면 PlayerData의 연속출석을 +1 해줍니다. 다르다면 연속출석을 0로 만듭니다.
/// </summary>

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
