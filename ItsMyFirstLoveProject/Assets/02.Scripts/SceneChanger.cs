using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// name : Scene 명칭 입력
    /// </summary>
    public void Change(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// 현재 실행되고 있는 씬 이름 반환
    /// </summary>
    public string GetName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
