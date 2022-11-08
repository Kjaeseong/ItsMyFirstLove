using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_UI : MonoBehaviour
{
    [SerializeField] private GameObject _drawingUI;
    private GameObject _drawingPanel;


    public void ActivateDrawingUI()
    {
        _drawingUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ActivateDrawingPanelButton()
    {
        if(_drawingPanel != null)
        {
            _drawingPanel.transform.position = Camera.main.transform.forward * 1.5f;
            _drawingPanel.transform.LookAt(Camera.main.transform.position);
            _drawingPanel.SetActive(true);
        }
        
    }

    public void GameObjectSet(GameObject Obj)
    {
        _drawingPanel = Obj;
    }
}
