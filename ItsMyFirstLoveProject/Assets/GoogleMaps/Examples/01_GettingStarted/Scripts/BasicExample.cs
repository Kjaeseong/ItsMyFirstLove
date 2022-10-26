using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;
using UnityEngine;

namespace Google.Maps.Examples {
    /// <summary>
    /// This example demonstrates a basic usage of the Maps SDK for Unity.
    /// </summary>
    /// <remarks>
    /// By default, this script loads the Statue of Liberty. If a new lat/lng is set in the Unity
    /// inspector before pressing start, that location will be loaded instead.
    /// </remarks>
    [RequireComponent(typeof(MapsService))]
    public class BasicExample : MonoBehaviour {
        [Tooltip("LatLng to load (must be set before hitting play).")]
        private LatLng _latLng = new LatLng(37.539970, 127.122938);

        private MapsService _mapsService;

        private BuildingManager _buildingManager;

        /// <summary>
        /// Use <see cref="MapsService"/> to load geometry.
        /// </summary>
        private void Start() {

            _buildingManager = GetComponent<BuildingManager>();
            // Get required MapsService component on this GameObject.
            _mapsService = GetComponent<MapsService>();

            // Set real-world location to load.
            _mapsService.InitFloatingOrigin(_latLng);

            // Register a listener to be notified when the map is loaded.
            _mapsService.Events.MapEvents.Loaded.AddListener(OnLoaded);

            // Load map with default options.
            // 유니티상 테스트를 위해 다시 작성, 추후 GPS 적용시 아래 함수 사용
            LoadMap(_latLng.Lat, _latLng.Lng);
            // _mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
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

        /// <summary>
        /// Example of OnLoaded event listener.
        /// </summary>
        /// <remarks>
        /// The communication between the game and the MapsSDK is done through APIs and event listeners.
        /// </remarks>
        public void OnLoaded(MapLoadedArgs args) {
            // The Map is loaded - you can start/resume gameplay from that point.
            // The new geometry is added under the GameObject that has MapsService as a component.
            _buildingManager.GetMesh();
            _buildingManager.FindBuilding();
            //_buildingManager.AddCharacter();
        }
    }
}
