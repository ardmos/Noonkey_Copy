using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 눈물이 바닥에 닿았을 때 효과 프리팹을 담당하는 스크립트
/// 하는 일: 부모 오브젝트인 Tear가 바닥에 닿았을 시 호출해주는 메서드가 존재한다. TearBlast가 프리팹으로 소환되는 즉시 재생되는 Blast애니메이션이 있는데, 해당 애니메이션이 끝나게되면 호출되는 애니메이션 이벤트로 현 오브젝트의 파괴 메서드가 실행이 된다.
/// 2. 오브젝트 파괴 메서드
/// </summary>

public class TearBlast : MonoBehaviour
{
    /// 오브젝트 파괴 메서드. 애니메이션 이벤트로 호출된다.
    public void DestroyItSelf()
    {
        Destroy(gameObject);
    }

}
