using System.Collections.Generic;
using UnityEngine;

public class CsvManager : MonoBehaviour
{
    // CSV 로드방법
    // 1. 파일 위치 : Resources/CSV  
    // 2. 유니티 에디터 내 인스펙터 창에서 _fileNameList에 파일명 추가.(확장자 미 기입)
    
    private Dictionary<string, List<Dictionary<string, object>>> _csvList = new Dictionary<string, List<Dictionary<string, object>>>();
    [SerializeField] private List<string> _fileNameList = new List<string>();

    private void Start() 
    {
        FileLoad();
    }

    private void FileLoad()
    {
        for(int i = 0; i < _fileNameList.Count; i++)
        {
            string path = "CSV/" + _fileNameList[i];
            _csvList.Add(_fileNameList[i], CSVReader.Read(path));
        }
    }

    /// <summary>
    /// Filename : 파일 명 입력 <br/>
    /// index : 줄 수 입력 <br/>
    /// Category : 항목 이름 입력
    /// </summary>
    public string GetCSV(string Filename, int index, string Category)
    {
        return _csvList[Filename][index][Category].ToString();
    }
}
