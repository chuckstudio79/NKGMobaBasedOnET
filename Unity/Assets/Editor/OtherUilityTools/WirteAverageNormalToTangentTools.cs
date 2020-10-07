//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年10月7日 19:30:41
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ETEditor
{
    public class WirteAverageNormalToTangentTools
    {
        [MenuItem("NKGTools/其他实用工具/模型平均法线写入切线数据")]
        public static void WirteAverageNormalToTangentToos()
        {
            MeshFilter[] meshFilters = Selection.activeGameObject.GetComponentsInChildren<MeshFilter>();
            foreach (var meshFilter in meshFilters)
            {
                Mesh mesh = meshFilter.sharedMesh;
                WirteAverageNormalToTangent(mesh);
            }

            SkinnedMeshRenderer[] skinMeshRenders = Selection.activeGameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (var skinMeshRender in skinMeshRenders)
            {
                Mesh mesh = skinMeshRender.sharedMesh;
                WirteAverageNormalToTangent(mesh);
            }
        }

        private static void WirteAverageNormalToTangent(Mesh mesh)
        {
            var averageNormalHash = new Dictionary<Vector3, Vector3>();
            for (var j = 0; j < mesh.vertexCount; j++)
            {
                if (!averageNormalHash.ContainsKey(mesh.vertices[j]))
                {
                    averageNormalHash.Add(mesh.vertices[j], mesh.normals[j]);
                }
                else
                {
                    averageNormalHash[mesh.vertices[j]] =
                            (averageNormalHash[mesh.vertices[j]] + mesh.normals[j]).normalized;
                }
            }

            var averageNormals = new Vector3[mesh.vertexCount];
            for (var j = 0; j < mesh.vertexCount; j++)
            {
                averageNormals[j] = averageNormalHash[mesh.vertices[j]];
            }

            var tangents = new Vector4[mesh.vertexCount];
            for (var j = 0; j < mesh.vertexCount; j++)
            {
                tangents[j] = new Vector4(averageNormals[j].x, averageNormals[j].y, averageNormals[j].z, 0);
            }

            mesh.tangents = tangents;
        }
    }
}