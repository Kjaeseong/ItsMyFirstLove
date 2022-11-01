using UnityEngine;

public class OptionUI : MonoBehaviour
{
    private GameObject _uiObject;

    public void ObjectSet(GameObject UI)
    {
        _uiObject = UI;
    }

    private void OnDisable() 
    {
        _uiObject.SetActive(true);
    }
}
