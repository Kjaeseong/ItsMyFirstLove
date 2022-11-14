using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

#if UNITY_ANDROID
using UnityEngine.Android;
#endif

namespace GameFile
{
    public class Img : MonoBehaviour
    {
        public struct Size
        {
            public static Vector2 Draw  { get { return new Vector2(1000, 1000); }}
            public static Vector2 Half  { get { return new Vector2(1080, 1200); }}
            public static Vector2 Picture { get { return new Vector2(1080, 1600); }}
            public static Vector2 Full  { get { return new Vector2(1080, 2400); }}
            public static Vector2 Paper { get { return new Vector2(2400, 1080); }}
        }

        public struct Name
        {
            public static string Draw       { get { return "Draw_"; }}
            public static string SelfCam    { get { return "SelfCam_"; }}
            public static string FullCam    { get { return "FullCam_"; }}
            public static string Paper      { get { return "Paper_"; }}
        }

        public static string Platform 
        { 
            get 
            { 
            #if UNITY_EDITOR || UNITY_STANDALONE
                // 유니티에디터에서 실행시 || 윈도우, 맥, 리눅스에서 실행시
                return Application.dataPath; 
            #elif UNITY_ANDROID
                // 안드로이드에서 실행시
                return $"/storage/emulated/0/DCIM/{Application.productName}";
            #endif            
            } 
        }
        public static string Folder    { get { return "ScreenShots"; } }
        public static string Date      { get { return DateTime.Now.ToString("MMdd_HHmmss"); }}
        public static string Png       { get { return "png"; } }
        private static string _lastPath;

        /// <summary> 
        /// 스크린샷을 찍고 경로에 저장  <br/>
        /// cam : 대상 카메라 오브젝트 <br/>
        /// Size : 저장할 이미지 사이즈, Size클래스 참조 (ex> Img.Size.Full) <br/>
        /// ScreenShotName : 저장할 이미지 이름, Name클래스 참조 (ex> Img.Name.Draw)
        /// </summary>
        public static void Save(GameObject cam, Vector2 Size, string ScreenShotName)
        {
            Camera camera = cam.GetComponent<Camera>();

            RenderTexture rt = new RenderTexture(
                (int)Size.x, 
                (int)Size.y, 
                24, 
                RenderTextureFormat.ARGB32, 
                RenderTextureReadWrite.sRGB 
            );

            // 매개변수로 입력된 카메라에서 렌더링되는 스크린 기준
            RenderTexture oldRT = camera.targetTexture;
            camera.targetTexture = rt;
            camera.Render();
            camera.targetTexture = oldRT;

            RenderTexture.active = rt;
            Texture2D CamTex = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
            CamTex.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);

            RenderTexture.active = null;


            // 현재 카메라로부터 지정 영역의 픽셀들을 텍스쳐에 저장

            byte[] bytes = CamTex.EncodeToPNG();
            string FolderPath = $"{Platform}/{Folder}";
            string Path = $"{Platform}/{Folder}/{ScreenShotName}{Date}.{Png}";

            bool succeeded = true;
            try
            {
                // 폴더가 존재하지 않으면 새로 생성
                if (Directory.Exists(FolderPath) == false)
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // 스크린샷 저장
                System.IO.File.WriteAllBytes(Path, bytes);
            }
            catch (Exception e)
            {
                succeeded = false;
                Debug.LogWarning($"Screen Shot Save Failed : {Path}");
                Debug.LogWarning(e);
            }

            // 마무리 작업
            Destroy(CamTex);

            if (succeeded)
            {
                _lastPath = Path;
            }

            // 갤러리 갱신
            RefreshGallery(Path);
        }

        /// <summary> 
        /// 가장 최근에 저장된 이미지 텍스쳐로 반환 
        /// </summary>
        public static Texture TextureLoad()
        {
            string FolderPath = $"{Platform}/{Folder}";
            string Path = _lastPath;
            Texture2D tex;

            if (Directory.Exists(FolderPath) == false)
            {
                // 폴더가 존재하지 않을 때
                return null;
            }
            if (System.IO.File.Exists(Path) == false)
            {
                // 파일이 존재하지 않을 때
                return null;
            }

            // 저장된 스크린샷 파일 경로로부터 읽어오기
            byte[] byteTexture = System.IO.File.ReadAllBytes(Path);
            if(byteTexture.Length > 0)
            {
                tex = new Texture2D(0, 0);
                tex.LoadImage(byteTexture);
                return tex;
            }

            //파일 로드 실패시
            return null;
        }

        // 안드로이드 갤러리 갱신
        // 안드로이드 플랫폼에서 실행하지 않으면 컴파일 대상에서 제외
        [System.Diagnostics.Conditional("UNITY_ANDROID")]
        public static void RefreshGallery(string imageFilePath)
        {
            #if !UNITY_EDITOR
            AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2]
            { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + imageFilePath) });
            objActivity.Call("sendBroadcast", objIntent);
            #endif
        }
    }

    public class Audio : MonoBehaviour
    {
        // TODO : 추후 오디오 파일을 다루기 위한 클래스
        //        게임 시작시 일괄적으로 로드할것이므로 LoadAll 함수만 넣었음.

        public struct Type
        {
            public static string Bgm    { get { return "BGM"; }}
            public static string Se     { get { return "SE"; }}
            public static string Etc    { get { return "ETC"; }}
        }

        // TODO : 저장소 경로 알아내야 함.
        public static string Folder     { get { return "~~~~"; }}
        public static string Wma        { get { return "wma"; }}
        public static string Mp3        { get { return "mp3"; }}

        public static void LoadAll(List<AudioClip> list, string type)
        {
            string FolderPath = $"{Folder}/{type}";

            if (Directory.Exists(FolderPath) == false)
            {
                // 폴더가 존재하지 않을 때
            }


            // ...
        }
    }
}