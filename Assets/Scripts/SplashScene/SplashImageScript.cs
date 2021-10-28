using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스플래시 씬의 스플래시 이미지 애니메이션이 끝났을 때 호출되는 메서드가 있는 스크립트. 
/// 하는 역할은 단순. SplashSceneManager의 씬 전환 메서드를 호출하는것. 
/// 
/// </summary>

public class SplashImageScript : MonoBehaviour
{
    public SplashSceneManager sceneManager;
    public void SplashImageAnimIsEnd()
    {
        sceneManager.LoadSampleScene();
    }
}
