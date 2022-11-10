using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Google.Maps.Examples
{
    /// <summary>
    /// This example demonstrates a basic usage of the Maps SDK for Unity.
    /// </summary>
    /// <remarks>
    /// By default, this script loads the Statue of Liberty. If a new lat/lng is set in the Unity
    /// inspector before pressing start, that location will be loaded instead.
    /// </remarks>
    [RequireComponent(typeof(MapsService))]
    public class BasicExample : MonoBehaviour
    {
        [Tooltip("LatLng to load (must be set before hitting play).")]
        private LatLng _latLng = new LatLng(37.539970, 127.122938);

        private MapsService _mapsService;

        private BuildingManager _buildingManager;

        private BuildingFinder _buildingFinder;

        [SerializeField] private GameObject _map;
        [SerializeField] private GameObject _nav;
        [SerializeField] private GameObject _ground;

        [SerializeField] private InputField _useInputLat;
        [SerializeField] private InputField _useInputLong;

        /// <summary>
        /// Use <see cref="MapsService"/> to load geometry.
        /// </summary>
        private void Start()
        {
            _buildingFinder = GetComponent<BuildingFinder>();
            _buildingManager = GetComponent<BuildingManager>();
            _mapsService = GetComponent<MapsService>();

            _mapsService.InitFloatingOrigin(_latLng);

            _mapsService.Events.MapEvents.Loaded.AddListener(OnLoaded);

            // 유니티상 테스트를 위해 다시 작성, 추후 GPS 적용시 아래 함수 사용
            LoadMap(_latLng.Lat, _latLng.Lng);
            // LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
        }

        /// <summary>
        /// 맵 로드
        /// </summary>
        /// <param name="Lat">위도</param>
        /// <param name="Long">경도</param>
        public void LoadMap(double Lat, double Long)
        {
            _latLng = new LatLng(Lat, Long);
            _mapsService.MoveFloatingOrigin(_latLng);
            _mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
        }

        public void TestLoadMapUseGPS()
        {
            _latLng = new LatLng(GameManager.Instance.Lat, GameManager.Instance.Long);
            _mapsService.MoveFloatingOrigin(_latLng);
            _mapsService.MakeMapLoadRegion().UnloadOutside();
            _mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
            InitMapLocationToPlayerPosition();
        }
        public void TestLoadMapUseInput()
        {
            Debug.Log("인풋 맵 호출됨");
            _latLng = new LatLng(double.Parse(_useInputLat.text), double.Parse(_useInputLong.text));
            _mapsService.MoveFloatingOrigin(_latLng);
            _mapsService.MakeMapLoadRegion().UnloadOutside();
            _mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
            InitMapLocationToPlayerPosition();
        }

        public void InitMapLocationToPlayerPosition()
        {
            Vector3 vec = new Vector3(Camera.main.transform.position.x, 0f, Camera.main.transform.position.z);
            _map.transform.position = vec;
            _nav.transform.position = vec;
            _ground.transform.position = vec;
        }

        /// <summary>
        /// 맵 로드 후 실행되어야 하는 요소들 여기에 작성
        /// </summary>
        public void OnLoaded(MapLoadedArgs args)
        {
            // The Map is loaded - you can start/resume gameplay from that point.
            // The new geometry is added under the GameObject that has MapsService as a component.
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y - 1.3f,
                transform.position.z);
        }
    }
}
