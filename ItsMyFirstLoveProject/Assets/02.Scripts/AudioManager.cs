using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Dictionary<string, AudioClip> AudioList = new Dictionary<string, AudioClip>();

    [SerializeField] private AudioSource _bgm;
    [SerializeField] private AudioSource _se;
    [SerializeField] private AudioSource _touch;
    [SerializeField] private AudioSource _event;

    private float _bgmVolume = 0.5f;
    private float _seVolume = 0.5f;

    private void Start() 
    {
        LoadFile();
    }

    public void foo()
    {
        Debug.Log("--");
    }

    private void LoadFile()
    {
        object[] audiolist = Resources.LoadAll("Audio");

        for(int i = 0; i <audiolist.Length; i++)
        {
            string filename = "";

            for(int j = 0; j >= 0; j++)
            {
                string str = audiolist[i].ToString();
                if(str[j] == ' ')
                {
                    break;
                }
                else
                {
                    filename += str[j];
                }
            }
            Debug.Log(filename);
            
            AudioList.Add(filename, audiolist[i] as AudioClip);
        }
    }

    /// <summary>
    /// 변수로 파일 명 입력
    /// </summary>
    public void Play(string FileName)
    {
        switch(FileName[0])
        {
            case 'B':
                ClipSet(_bgm, AudioList[FileName]);
                break;
            case 'S':
                ClipSet(_se, AudioList[FileName]);
                break;
            case 'T':
                ClipSet(_touch, AudioList[FileName]);
                break;
            case 'E':
                ClipSet(_event, AudioList[FileName]);
                break;
        }
    }

    /// <summary>
    /// type = "BGM", "SE", "TOUCH", "EVENT"
    /// </summary>
    public void Stop(string type)
    {
        switch(type)
        {
            case "BGM":
                _bgm.Stop();
                break;
            case "SE":
                _se.Stop();
                break;
            case "TOUCH":
                _touch.Stop();
                break;
            case "EVENT":
                _event.Stop();
                break;
        }
    }


    /// <summary>
    /// 배경음, 효과음 수치 조정 <br/>
    /// bgm : 배경음 음량, 0 ~ 1 <br/>
    /// se : 효과음 음량, 0 ~ 1
    /// </summary>
    public void SetVolume(float bgm, float se)
    {
        _bgmVolume = bgm;
        _seVolume = se;
    }


    /// <summary>
    /// 배경음, 효과음 음량 순으로 Vector2 형식으로 반환
    /// </summary>
    public Vector2 GetVolume()
    {
        return new Vector2(_bgmVolume, _seVolume);
    }

    private void ClipSet(AudioSource type, AudioClip file)
    {
        type.clip = file;
        type.Play();
    }

    /// <summary>
    /// type = "BGM", "SE", "TOUCH", "EVENT"<br/>
    /// Select = true / false
    /// </summary>
    public void LoopSet(string type, bool Select)
    {
        switch(type)
        {
            case "BGM":
                _bgm.loop = Select;
                break;
            case "SE":
                _se.loop = Select;
                break;
            case "TOUCH":
                _touch.loop = Select;
                break;
            case "EVENT":
                _event.loop = Select;
                break;
        }
    }
}
