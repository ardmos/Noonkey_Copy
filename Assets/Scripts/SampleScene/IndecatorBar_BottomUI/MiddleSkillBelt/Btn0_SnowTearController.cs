using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// (스킬)눈꽃눈물 기능 구현 부분
/// 
/// 0. 스킬 활성화 메서드. 
/// 
/// --- 스킬벨트 ---
/// 1. 사용시 화면 배경이 바뀐다.
/// 2. 1분간 초당 10회 자동탭 효과 (1초 지날때마다 획득량*10 획득시킴)
/// 3. 재사용대기시간 10분.
/// 4. 스킬 아이콘이 불투명해지면서 스킬 효과 지속시간을 표현하는 테두리 게이지가 줄어들면서 중앙에는 초당 획득량이 표시된다(텍스트는 점멸).
/// 5. 1분의 지속시간이 끝나면  재사용대기시간이 시작, 표시된다. 해당 불투명은 아래쪽부터 지난시간/남은 시간만큼 천천히 걷힌다.
/// </summary>


public class Btn0_SnowTearController : MonoBehaviour
{
    //커버 이미지, 옐로우 게이지 이미지
    public GameObject image_Cover, image_YellowGage;
    //텍스트 오브젝트
    public GameObject textObject;



}
