using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 장미 엘프의 움직임을 관장하는 스크립트. 
/// 1. 좌<->우 이동.  (상하로 조금씩 움직이면서)
/// 2. 날개짓 (이미지 교체)
/// 3. 10초마다 장미 떨어뜨려야해요! 최대 4개! 
///    (장미는 프리팹.!  터치하면 현재 Item0_RoseElf의 초당 치유량 * 10 만큼 얻어짐!  장미프리팹 머리 위에 뾰롱 하고 뜨기도 함.)
/// </summary>

public class RoseElfController : MonoBehaviour
{
    RectTransform rectTransform;
    //떨어뜨릴 장미 프리팹 오브젝트
    public GameObject rosePrefObj;

    //날개짓으로 보여줄 날개 이미지 두 장
    public Sprite[] wingSprites;

    //좌우상하 이동지점. 
    public RectTransform leftMoveEndPoint, rightMoveEndPoint, topMoveEndPoint, bottomMoveEndPoint;

    //스피드
    public float speed;

    //좌우방향
    public enum ElfDir
    {
        Left,
        Right
    }
    public ElfDir elfDir;
    //상하방향
    public enum ElfDirUD
    {
        Up,
        Down
    }
    public ElfDirUD elfDirUD;

    // Start is called before the first frame update
    void Start()
    {                

        StartCoroutine(DropRose(10));
        StartCoroutine(FlappingWings());

        leftMoveEndPoint = GameObject.Find("LeftMoveEndPoint").GetComponent<RectTransform>();
        rightMoveEndPoint = GameObject.Find("RightMoveEndPoint").GetComponent<RectTransform>();
        topMoveEndPoint = GameObject.Find("TopMoveEndPoint").GetComponent<RectTransform>();
        bottomMoveEndPoint = GameObject.Find("BottomMoveEndPoint").GetComponent<RectTransform>();
        rectTransform = gameObject.GetComponent<RectTransform>();
        speed = 100f;
    }


    private void Update()
    {
        MoveAndHovering();        
    }
    // 1. 좌<->우 이동.  (상하로 조금씩 움직이면서)
    void MoveAndHovering()
    {
        Vector2 position = rectTransform.anchoredPosition;

        //좌우 무빙
        if (position.x <= leftMoveEndPoint.anchoredPosition.x)
        {
            rectTransform.eulerAngles = new Vector3(0f, 180f, 0f);
            elfDir = ElfDir.Right;
        }else if (position.x >= rightMoveEndPoint.anchoredPosition.x)
        {
            rectTransform.eulerAngles = new Vector3(0f, 0, 0f);
            elfDir = ElfDir.Left;
        }

        switch (elfDir)
        {
            case ElfDir.Left:
                position.x -= Time.deltaTime * speed;
                break;
            case ElfDir.Right:
                position.x += Time.deltaTime * speed;
                break;
            default:
                break;
        }

        //상하 무빙
        if (position.y <= bottomMoveEndPoint.anchoredPosition.y)
        {
            elfDirUD = ElfDirUD.Up;
        }
        else if (position.y >= topMoveEndPoint.anchoredPosition.y)
        {
            elfDirUD = ElfDirUD.Down;
        }
        switch (elfDirUD)
        {
            case ElfDirUD.Up:
                position.y += Time.deltaTime * speed/4;
                break;
            case ElfDirUD.Down:
                position.y -= Time.deltaTime * speed/4;
                break;
            default:
                break;
        }



        //최종 적용
        rectTransform.anchoredPosition = position;
    }


    // 2. 날개짓 (이미지 교체)
    IEnumerator FlappingWings()
    {
        
        if (transform.GetChild(0).GetComponent<Image>().sprite == wingSprites[0])
        {
            transform.GetChild(0).GetComponent<Image>().sprite = wingSprites[1];
        }
        else transform.GetChild(0).GetComponent<Image>().sprite = wingSprites[0];
        yield return new WaitForSeconds(0.3f);

        StartCoroutine(FlappingWings());
    }



    //3. 10초마다 장미 떨어뜨려야해요! 최대 4개! 
    IEnumerator DropRose(int intervalTime)
    {
        yield return new WaitForSeconds(10f);
        //장미프리팹 생성하기 
        GameObject prefObj = Instantiate(rosePrefObj) as GameObject;
        prefObj.GetComponent<RectTransform>().SetParent(GameObject.Find("=====Elves=====").GetComponent<RectTransform>());        
        prefObj.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;

        StartCoroutine(DropRose(10));
    }
}
