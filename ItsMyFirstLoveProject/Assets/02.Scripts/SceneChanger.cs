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
}
