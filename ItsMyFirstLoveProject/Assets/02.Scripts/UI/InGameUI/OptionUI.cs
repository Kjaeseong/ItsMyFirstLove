using UnityEngine;

public class OptionUI : MonoBehaviour
{
    private GameObject _uiObject;

    /// <summary>
    /// 함수 호출시의 UI오브젝트가 자신을 담아서 호출 <br/>
    /// 옵션창 비활성화시 자동으로 이전 오브젝트가 활성화
    /// </summary>
    public void ObjectSet(GameObject UI)
    {
        _uiObject = UI;
    }

    private void OnDisable() 
    {
        _uiObject.SetActive(true);
    }
}
