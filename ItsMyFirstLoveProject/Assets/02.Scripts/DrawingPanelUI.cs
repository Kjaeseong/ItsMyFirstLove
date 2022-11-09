using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameFile;

public class DrawingPanelUI : MonoBehaviour
{
    // TODO : 방명록 기능에 대한 구체적인 기획안 확정시 추가작업 하겠음. 작성자 김재성
    [SerializeField] private GameObject _captureCam;
    private Camera _captureCamera;
    [SerializeField] private List<Material> _lineMaterials = new List<Material>(); 
    [SerializeField] private GameObject _drawingPanelPrefab;
    private Stack<GameObject> _lineStack = new Stack<GameObject>();


//--------------------- For Test --------------------------
    // 펜 색상 선택
    // 추후 UI 확정되면 버튼 선택으로 변경 예정
    // 0 : 검정
    // 1 : 하얀색
    // 2 : 분홍색
    // 3 : 하늘색
    [SerializeField][Range(0, 3)] private int _selectColor;
    private enum Color
    {
        BLACK = 0,
        WHITE,
        PINK,
        SKYBLUE
    }
//---------------------------------------------------------

    // For RayCast
    private LineRenderer curLine;
    private int positionCount = 2;
    private Vector3 PrevPos = Vector3.zero;
    private RaycastHit hit;
    private bool _canvasTouch;

    private void Update()
    {
        Drawtouch();
    }
    
    private void Start() 
    {
        _captureCamera = _captureCam.GetComponent<Camera>();
    }

    /// <summary>
    /// 메인카메라 기준 이미지 캡쳐. 지정된 파일 경로로 저장
    /// </summary>
    public void SaveImage()
    {
        Img.Save(_captureCam, Img.Size.Draw, Img.Name.Draw);
        EraserAll();
    }

    /// <summary>
    /// 선 전체 지우기
    /// </summary>
    public void EraserAll()
    {
        for(int i = 0; i < _lineStack.Count; i++)
        {
            Eraser();
        }
    }

    /// <summary>
    /// 지우기 기능(실행 취소)
    /// </summary>
    public void Eraser()
    {
        Destroy(_lineStack.Pop());
    }

    /// <summary>
    /// 저장된 이미지를 텍스쳐로 가진 방명록 생성
    /// </summary>
    public void CreateDrawingPanel()
    {
        // 객체 생성
        GameObject panel = Instantiate(_drawingPanelPrefab);
        // RawImage 컴포넌트 탐색
        RawImage _image = panel.GetComponentInChildren<RawImage>();
        // 가장 최근에 저장된 이미지 로드 후 텍스쳐 입힘
        _image.texture = Img.TextureLoad();

        panel.SetActive(false);
    }

    //테스트용 코드, 삭제가능
    public void SelectColor(int num)
    {
        _selectColor = num;
    }

    // 캔버스 건물 배치 (미완. 추후 배치 관련 기획안 수립시 작업요망)
    private void PositionSetToBuilding(GameObject Building)
    {
        // TODO : 건물에 배치하는 위치나 방식에 따라 추가 구현해야 함.
        transform.parent = Building.transform;
    }

    // 터치 동작시 Canvas에 선 그리는 함수
    private void Drawtouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = _captureCamera.ScreenPointToRay(touch.position);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.name == "DrawCanvas")
                {
                    Vector3 touchPos = _captureCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, hit.collider.transform.position.z - 0.4f));
                    if(touch.phase == TouchPhase.Began && _canvasTouch == false)
                    {
                        createLine(touchPos);
                        _canvasTouch = true;
                    }
                    if(touch.phase == TouchPhase.Moved && _canvasTouch == true)
                    {
                        connectLine(touchPos);
                    }
                    
                }
                if(touch.phase == TouchPhase.Ended)
                {
                    _canvasTouch = false;
                }
            }
        }
    }

    // 터치시 라인 생성
    private void createLine(Vector3 touchPos)
    {
        positionCount = 2;  
        GameObject line = new GameObject("Line");
        _lineStack.Push(line);
        LineRenderer lineRend = line.AddComponent<LineRenderer>();

        line.transform.parent = transform;
        line.transform.position = touchPos;
        line.layer = 12;

        lineRend.startWidth = 0.01f;
        lineRend.endWidth = 0.01f;
        lineRend.numCornerVertices = 5;
        lineRend.numCapVertices = 5;
        lineRend.material = _lineMaterials[_selectColor];
        lineRend.SetPosition(0, touchPos);
        lineRend.SetPosition(1, touchPos);

        curLine = lineRend;
    }

    // 터치시 라인을 그리던 중이었는지 확인
    private void connectLine(Vector3 touchPos)
    {
        if(PrevPos != null && Mathf.Abs(Vector3.Distance(PrevPos, touchPos)) >= 0.001f)
        {
            PrevPos = touchPos;
            positionCount++;
            curLine.positionCount = positionCount;
            curLine.SetPosition(positionCount - 1, touchPos);
        }
    }


// 미사용 메서드. 추후 확장 기능을 위해 임시 보관. 미사용시 삭제해도 무방함------------------------------------

    // 터치(레이캐스트) 획 지우기 작성중이었던 코드. 실행 취소로 대체함.
    
    // private void Eraser()
    // {
    //     if (Input.touchCount > 0)
    //     {
    //         Touch touch = Input.GetTouch(0);
    //         Ray ray = Camera.main.ScreenPointToRay(touch.position);
    //         Vector3 touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, hit.collider.transform.position.z - 0.1f));

    //         Debug.Log(touchPos);

    //         if(Physics.Raycast(ray, out hit, 100))
    //         {
    //             if(hit.collider.name == "Line")
    //             {
    //                 Destroy(hit.collider.gameObject);
    //             }
    //         }
    //     }
    // }

}
