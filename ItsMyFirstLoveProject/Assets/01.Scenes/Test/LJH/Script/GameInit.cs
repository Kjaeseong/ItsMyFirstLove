using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Maps.Examples;

public class GameInit : MonoBehaviour
{

    [SerializeField] private Transform _map;
    [SerializeField] private Transform _arCameraTransform;
    [SerializeField] private PositionSensor _pos;
    [SerializeField] private BasicExample _mapLoader;


    private float _tryInitTime = 0.1f;

    private void Start()
    {
        StartCoroutine(InitGame());
    }

    // �ٴ� �ν� �� �ڷ�ƾ ���� ���, �ڷ�ƾ ����Ǹ� UI�� �ǹ���ġ �̼� ���� �ʿ�
    IEnumerator InitGame()
    {
        while (true)
        {
            // GPS �� �޾ƿ� ��
            //if(_pos.GetIsGpsStart())
            //{
            if(_pos.GetLat() != 0 && _pos.GetLong() != 0)
            {
                _mapLoader.LoadMap(_pos.GetLat(), _pos.GetLong());

                // �� ȸ��
                InitMapRotate();

                break;
            }
            // �� �ε�
            
            //}
            yield return new WaitForSeconds(_tryInitTime);
        }
        StopCoroutine(InitGame());
    }

    /// <summary>
    /// Extensions���� ���ʰ� ���� AR ī�޶��� ���� ���� �̿��Ͽ� ���� ȸ����Ű�� �Լ�
    /// </summary>
    public void InitMapRotate()
    {
        double angle = _pos.GetAzimuth();
        while (false == (_map.rotation.eulerAngles.y > (360 - angle - 2) % 360 && _map.rotation.eulerAngles.y < (360 - angle + 2) % 360))
        {
            _map.transform.RotateAround(_arCameraTransform.position, Vector3.up, 10f * Time.deltaTime);
        }
    }
}
