using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 우는 얼굴 애니메이션의 애니메이션 이벤트를 처리하는 메서드. 
/// 하는 일: 우는 얼굴 애니메이션 실행 시, 캐릭터컨트롤러의 MakeTear 메서드를 호출한다.
/// </summary>

public class SadFace : MonoBehaviour
{
    public CharacterController_m characterController_M;
    public void CallMakeTearMethod()
    {
        characterController_M.MakeTear();
    }
}
