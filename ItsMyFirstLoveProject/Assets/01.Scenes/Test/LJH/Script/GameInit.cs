using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{

    [SerializeField] private Transform _map;
    [SerializeField] private Transform _arCameraTransform;
    [SerializeField] private PositionSensor _pos;

    private float tryInitTime = 0.1f;


    IEnumerator InitGame()
    {
        while(true)
        {
            if(_pos.GetIsGpsStart())
            {
                InitMapRotate();
            }
            yield return new WaitForSeconds(tryInitTime);
        }
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
