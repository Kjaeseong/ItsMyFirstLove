using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class NavMeshSourceTag : MonoBehaviour
{
    public static List<MeshFilter> Meshes = new List<MeshFilter>();
    public static List<Terrain> Terrains = new List<Terrain>();

    private void OnEnable()
    {
        var meshfilter = GetComponent<MeshFilter>();
        if (meshfilter != null)
        {
            Meshes.Add(meshfilter);
        }

        var terrain = GetComponent<Terrain>();
        if (terrain != null)
        {
            Terrains.Add(terrain);
        }
    }

    private void OnDisable()
    {
        var meshfilter = GetComponent<MeshFilter>();
        if (meshfilter != null)
        {
            Meshes.Remove(meshfilter);
        }

        var terrain = GetComponent<Terrain>();
        if (terrain != null)
        {
            Terrains.Remove(terrain);
        }
    }

    // 메쉬가 선택이 가능하다면 해준다. 
    public static void Collect(ref List<NavMeshBuildSource> sources)
    {
        sources.Clear();

        for (var i = 0; i < Meshes.Count; ++i)
        {
            var meshfilter = Meshes[i];
            if (meshfilter == null)
            {
                continue;
            }

            var mesh = meshfilter.sharedMesh;
            if (mesh == null)
            {
                continue;
            }

            var shapes = new NavMeshBuildSource();
            shapes.shape = NavMeshBuildSourceShape.Mesh;
            shapes.sourceObject = mesh;
            shapes.transform = meshfilter.transform.localToWorldMatrix;
            shapes.area = 0;
            sources.Add(shapes);
        }

        for (var i = 0; i < Terrains.Count; ++i)
        {
            var terrains = Terrains[i];
            if (terrains == null) continue;

            var shapes = new NavMeshBuildSource();
            shapes.shape = NavMeshBuildSourceShape.Terrain;
            shapes.sourceObject = terrains.terrainData;
            shapes.transform = Matrix4x4.TRS(terrains.transform.position, Quaternion.identity, Vector3.one);
            shapes.area = 0;

            sources.Add(shapes);
        }
    }
}
