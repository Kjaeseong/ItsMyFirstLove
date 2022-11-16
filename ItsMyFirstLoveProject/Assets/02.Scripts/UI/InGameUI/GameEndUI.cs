using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndUI : MonoBehaviour
{
    private enum Result
    {
        FAIL,
        CLEAR
    }

    [SerializeField] private GameObject[] _endUI = new GameObject[2];
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private float _delayTime;

    private int _prevCoin;
    private int _getCoin;
    private int _totalCoin;
    private bool _isEndCoinAdd;
    private bool _isEffectEnd;


    private void OnEnable() 
    {
        // if(GameManager.Instance._isStageEnd)
        // {
        //     if(GameManager.Instance._isStageClear)
        //     {
        //         _prevCoin = GameManager.Instance.Coin;
        //         _getCoin = GameManager.Instance.GetCoinInStage;
        //         _totalCoin = _prevCoin + _getCoin;

        //         ActivateUI();

        //         CoinTextSet(_prevCoin);
        //         StartCoroutine(AddCoin());
        //     }
        //     else
        //     {
        //         ActivateUI();
        //         _isEffectEnd = true;
        //     }
        // }
    }

    private void ActivateUI()
    {
        // _endUI[(int)Result.FAIL].SetActive(!GameManager.Instance._isStageClear);
        // _endUI[(int)Result.CLEAR].SetActive(GameManager.Instance._isStageClear);
    }

    private void CoinTextSet(int coin)
    {
        _coinText.text = $"{coin}";
    }

    private IEnumerator AddCoin()
    {
        yield return new WaitForSeconds(_delayTime);

        while(!_isEndCoinAdd)
        {
            if(_prevCoin < _totalCoin)
            {
                _prevCoin++;
            }
            else if(_prevCoin == _totalCoin)
            {
                _isEndCoinAdd = true;
            }
            CoinTextSet(_prevCoin);
            yield return new WaitForSeconds(0.05f);
        }

        //GameManager.Instance.Coin = _totalCoin;
        _isEffectEnd = true;
    }

    public void ToTitle()
    {
        if(_isEffectEnd)
        {
            GameManager.Instance._scene.Change("MainTitle");
        }
    }
}
