using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VPS_Card : MonoBehaviour
{
    private Image _image;
    private RectTransform _rect;
    private float _timeCount;
    private VPS_CardEffect _vpsCardEffect;

    [SerializeField] private Sprite _backSprite;
    [SerializeField] private Sprite _frontSprite;

    [SerializeField] private float _fadeOutTime = 0.5f;
    [SerializeField] private float _moveDelay = 2.25f;
    [SerializeField] private int _thisCardNum;

    private bool _isMoveComplete;
    private bool _isStartEffect;
    private bool _isEndRotation;
    private bool _isEndEffect;
    private int _moveDirection;


    private void Start() 
    {
        _image = GetComponent<Image>();
        _rect = GetComponent<RectTransform>();
        _vpsCardEffect = GetComponentInParent<VPS_CardEffect>();
        _timeCount = _fadeOutTime;
    }

    /// <summary>
    /// 카드 선택시 스스로 선택되었는지 판단, <br/> 선택 됐다면 이후 효과, 선택되지 않았다면 페이드아웃
    /// </summary>
    public void ClickCard(int select)
    {
        if(!_isStartEffect)
        {
            _isStartEffect = true;

            if(_thisCardNum == select)
            {
                StartCoroutine(SelectCard());
            }
            else
            {
                StartCoroutine(FadeOut(0));
            }
        }
    }

    private IEnumerator FadeOut(float Delay)
    {
        yield return new WaitForSeconds(Delay);

        Color color = _image.color;
        while(color.a >= 0f)
        {
            color.a -= Time.deltaTime * _fadeOutTime;
            _image.color = color;

            if(color.a <= 0)
            {
                if(_isEndEffect)
                {
                    _vpsCardEffect.EndEffect();
                }
                gameObject.SetActive(false);
            }
            
            yield return new WaitForSeconds(0.01f);
        }
    }


    private IEnumerator SelectCard()
    {
        while(true)
        {
            if(_timeCount <= 0)
            {
                if(!_isMoveComplete)
                {
                    Move();
                    RotationCard();
                    RotateSpriteSet(_rect.rotation.eulerAngles.y);
                }
                else
                {
                    SelectSpriteSet();
                    ViewFront();
                    ScaleUp();
                }

                if(_isEndEffect)
                {
                    StartCoroutine(FadeOut(3));
                }
            }
            else
            {
                RotationCard();
                RotateSpriteSet(_rect.rotation.eulerAngles.y);
            }
            
            yield return new WaitForSeconds(0.01f);
        }
        
    }
    
    private void Move()
    {
        if(_rect.localPosition.x < 0)
        {
            _moveDirection = 1;
        }
        else if(_rect.localPosition.x > 0)
        {
            _moveDirection = -1;
        }

        if(_moveDelay >= 0)
        {
            _moveDelay -= Time.deltaTime;
            _rect.position = new Vector3(
                _rect.position.x + _moveDirection * (Mathf.Abs(_rect.localPosition.x) * Time.deltaTime),
                _rect.position.y,
                _rect.position.z
            );
        }
        else
        {
            _isMoveComplete = true;
        }
        
    }

    private void RotationCard()
    {
        float speed = (360 * Time.deltaTime) * 3;
        _rect.rotation = Quaternion.Euler(
            _rect.rotation.eulerAngles.x,
            _rect.rotation.eulerAngles.y + speed,
            _rect.rotation.eulerAngles.z
        );
        _timeCount -= Time.deltaTime;
    }

    private void ViewFront()
    {
        float speed = ((0 - _rect.rotation.eulerAngles.y)* Time.deltaTime) * 2;

        _rect.rotation = Quaternion.Euler(
            _rect.rotation.eulerAngles.x,
            _rect.rotation.eulerAngles.y + speed,
            _rect.rotation.eulerAngles.z
        );
    }

    private void ScaleUp()
    {
        if(_rect.localScale.x <= 1.3)
        {
            _rect.localScale = new Vector3(
                _rect.localScale.x + 0.05f,
                _rect.localScale.y + 0.05f,
                _rect.localScale.z
            );
        }
        else
        {
            _isEndEffect = true;
        }
    }

    private void RotateSpriteSet(float rotY)
    {
        if(0 <= rotY / 90 && rotY / 90 < 1)
        {
            _image.sprite = _backSprite;
        }
        else if(1 <= rotY / 90 && rotY / 90 < 3)
        {
            _image.sprite = _frontSprite;
        }
        else if(3 <= rotY / 90)
        {
            _image.sprite = _backSprite;
        }
    }

    private void SelectSpriteSet()
    {
        _image.sprite = _frontSprite;
    }




}
