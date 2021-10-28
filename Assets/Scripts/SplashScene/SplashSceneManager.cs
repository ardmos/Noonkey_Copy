using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 스플래시 씬을 관장하는 스크립트입니다. 
/// 
/// 1. 씬 시작시 스플래시 이미지 출력 애니메이션 실행.
/// 2. 애니메이션이 끝나면 호출되는 애니메이션 이벤트로 샘플씬으로의 씬 전환 메서드 호출.  (애니메이션 이벤트 -> 해당 Image에 붙어있는 SplashImageScript -> 현 스크립트의 씬 전환 메서드)
/// 
/// </summary>

public class SplashSceneManager : MonoBehaviour
{

    void Start()
    {
        // 1. 씬 시작시 스플래시 이미지 출력 애니메이션 실행.

    }


    // 2. 애니메이션이 끝나면 호출되는 애니메이션 이벤트로 샘플씬으로의 씬 전환 메서드 호출.  (애니메이션 이벤트 -> 해당 Image에 붙어있는 SplashImageScript -> 현 스크립트의 씬 전환 메서드)
    public void LoadSampleScene()
    {
        try
        {
            SceneManager.LoadScene("SampleScene");
        }
        catch (System.Exception)
        {

            throw;
        }        
    }

}
