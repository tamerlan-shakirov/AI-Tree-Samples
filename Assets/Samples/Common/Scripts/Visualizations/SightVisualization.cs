/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.AITree.PerceptionSystem;
using RenownedGames.Apex;
using System.Collections.Generic;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class SightVisualization : MonoBehaviour
    {
        private struct ViewCastInfo
        {
            public bool hit;
            public Vector3 point;
            public float distance;
            public float angle;
            public int mask;

            public ViewCastInfo(bool hit, Vector3 point, float distance, float angle, int mask)
            {
                this.hit = hit;
                this.point = point;
                this.distance = distance;
                this.angle = angle;
                this.mask = mask;
            }
        }

        private struct EdgeInfo
        {
            public ViewCastInfo viewCastA;
            public ViewCastInfo viewCastB;

            public EdgeInfo(ViewCastInfo viewCastA, ViewCastInfo viewCastB)
            {
                this.viewCastA = viewCastA;
                this.viewCastB = viewCastB;
            }
        }

        [SerializeField]
        private AIPerception aIPerception;

        [SerializeField]
        [Foldout("Mesh Settings", Style = "Group")]
        [Slider(0.01f, 1f)]
        private float meshResolution = 0.15f;

        [SerializeField]
        [Foldout("Mesh Settings", Style = "Group")]
        private int edgeResolveIterations = 4;

        [SerializeField]
        [Foldout("Mesh Settings", Style = "Group")]
        private float edgeDistanceThreshold = 0.5f;

        [SerializeField]
        [Foldout("Material", Style = "Group")]
        [MinValue(0f)]
        private float innerOffset;

        [SerializeField]
        [Foldout("Material", Style = "Group")]
        [MinValue(0f)]
        private float outerOutlineOffset;

        [SerializeField]
        [Foldout("Material", Style = "Group")]
        private LayerMask enemyLayer;

        // Stored required components.
        private MeshFilter meshFilter;
        private MeshRenderer meshRenderer;
        private AIPerceptionSightConfig sightConfig;
        private Material material;

        // Stored required properties.
        private Mesh fovMesh;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();
            material = meshRenderer.sharedMaterial;

            if (aIPerception != null)
            {
                sightConfig = aIPerception.GetConfigs()[0] as AIPerceptionSightConfig;
            }

            fovMesh = new Mesh();
            meshFilter.mesh = fovMesh;
        }

        /// <summary>
        /// Called every frame, if the Behaviour is enabled.
        /// </summary>
        private void LateUpdate()
        {
            if (sightConfig == null)
            {
                return;
            }

            DrawFOVMesh();
            UpdateMaterialProperty();
        }

        private void DrawFOVMesh()
        {
            int stepCount = Mathf.Max(1, Mathf.RoundToInt(sightConfig.GetFov() * meshResolution));
            float stepAngleSize = sightConfig.GetFov() / stepCount;
            List<ViewCastInfo> viewCasts = new List<ViewCastInfo>();
            ViewCastInfo oldViewCast = new ViewCastInfo();
            for (int i = 0; i <= stepCount; i++)
            {
                float angle = transform.eulerAngles.y - sightConfig.GetFov() / 2 + stepAngleSize * i;
                ViewCastInfo newViewCast = ViewCast(angle);

                if (i > 0)
                {
                    bool edgeDstThresholdExceeded = Mathf.Abs(oldViewCast.distance - newViewCast.distance) > edgeDistanceThreshold;
                    if (oldViewCast.hit != newViewCast.hit || (oldViewCast.hit && newViewCast.hit && edgeDstThresholdExceeded))
                    {
                        EdgeInfo edge = FindEdge(oldViewCast, newViewCast);
                        if (edge.viewCastA.point != Vector3.zero)
                        {
                            viewCasts.Add(edge.viewCastA);
                        }
                        if (edge.viewCastB.point != Vector3.zero)
                        {
                            viewCasts.Add(edge.viewCastB);
                        }
                    }
                }

                viewCasts.Add(newViewCast);
                oldViewCast = newViewCast;
            }

            float radius = sightConfig.GetMaxDistnce();

            Vector3 origin = Vector3.up * sightConfig.GetHeightOffset();

            int vertexCount = (viewCasts.Count - 1) * 2 + 1;
            Vector3[] vertices = new Vector3[vertexCount];
            int[] triangles = new int[(viewCasts.Count - 1) * 3];
            Vector2[] uv = new Vector2[vertexCount];
            Vector2[] uv2 = new Vector2[vertexCount];
            Vector2[] uv3 = new Vector2[vertexCount];

            vertices[0] = transform.InverseTransformPoint(viewCasts[0].point);
            uv[0] = new Vector2(vertices[0].magnitude / sightConfig.GetMaxDistnce(), (viewCasts[0].angle + 180) / 360f);
            uv2[0] = new Vector2((vertices[0].x + radius) * .5f / radius, (vertices[0].z + radius) * .5f / radius);

            if (viewCasts[0].hit)
            {
                if (enemyLayer == (enemyLayer | (1 << viewCasts[0].mask)))
                {
                    uv3[0] = new Vector2(0, 1);
                }
                else
                {
                    uv3[0] = new Vector2(1, 0);
                }
            }
            else
            {
                uv3[0] = Vector3.zero;
            }

            for (int i = 1; i < viewCasts.Count; i++)
            {
                vertices[i * 2] = transform.InverseTransformPoint(viewCasts[i].point);
                vertices[i * 2 - 1] = origin;

                float v = (viewCasts[i].angle + 180) / 360f;
                uv[i * 2] = new Vector2(vertices[i * 2].magnitude / sightConfig.GetMaxDistnce(), v);
                uv[i * 2 - 1] = new Vector2(0, v);

                uv2[i * 2] = new Vector2((vertices[i * 2].x + radius) * .5f / radius, (vertices[i * 2].z + radius) * .5f / radius);
                uv2[i * 2 - 1] = Vector3.one * .5f;

                if (viewCasts[i].hit)
                {
                    if (enemyLayer == (enemyLayer | (1 << viewCasts[i].mask)))
                    {
                        uv3[i * 2 - 1] = new Vector2(0, 1);
                        uv3[i * 2] = new Vector2(0, 1);
                    }
                    else
                    {
                        uv3[i * 2 - 1] = new Vector2(1, 0);
                        uv3[i * 2] = new Vector2(1, 0);
                    }

                }
                else
                {
                    uv3[i * 2] = Vector3.zero;
                    uv3[i * 2 - 1] = Vector3.zero;
                }
                

                triangles[(i - 1) * 3] = i * 2 - 1;
                triangles[(i - 1) * 3 + 1] = i * 2 - 2;
                triangles[(i - 1) * 3 + 2] = i * 2;
            }

            fovMesh.Clear();

            fovMesh.vertices = vertices;
            fovMesh.triangles = triangles;
            fovMesh.uv = uv;
            fovMesh.uv2 = uv2;
            fovMesh.uv3 = uv3;
            fovMesh.RecalculateNormals();
        }

        private EdgeInfo FindEdge(ViewCastInfo minViewCast, ViewCastInfo maxViewCast)
        {
            float minAngle = minViewCast.angle;
            float maxAngle = maxViewCast.angle;
            Vector3 minPoint = Vector3.zero;
            Vector3 maxPoint = Vector3.zero;

            for (int i = 0; i < edgeResolveIterations; i++)
            {
                float angle = (minAngle + maxAngle) / 2;
                ViewCastInfo newViewCast = ViewCast(angle);

                bool edgeDstThresholdExceeded = Mathf.Abs(minViewCast.distance - newViewCast.distance) > edgeDistanceThreshold;
                if (newViewCast.hit == minViewCast.hit && !edgeDstThresholdExceeded)
                {
                    minAngle = angle;
                    minViewCast = newViewCast;

                }
                else
                {
                    maxAngle = angle;
                    maxViewCast = newViewCast;
                }
            }

            return new EdgeInfo(minViewCast, maxViewCast);
        }

        private ViewCastInfo ViewCast(float globalAngle)
        {
            Vector3 origin = GetOrigin();
            Vector3 dir = DirFromAngle(globalAngle, true);

            if (Physics.Raycast(origin, dir, out RaycastHit hit, sightConfig.GetMaxDistnce(), sightConfig.GetCullingLayer() | sightConfig.GetObstacleLayer(), QueryTriggerInteraction.Ignore))
            {
                return new ViewCastInfo(true, hit.point, hit.distance, globalAngle, hit.transform.gameObject.layer);
            }
            else
            {
                return new ViewCastInfo(false, origin + dir * sightConfig.GetMaxDistnce(), sightConfig.GetMaxDistnce(), globalAngle, 0);
            }
        }

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                angleInDegrees += transform.eulerAngles.y;
            }
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

        private Vector3 GetOrigin()
        {
            return transform.position + transform.up * sightConfig.GetHeightOffset();
        }

        private void UpdateMaterialProperty()
        {
            float _innerOffset = innerOffset / sightConfig.GetMaxDistnce();
            material.SetFloat("_InnerOffet", _innerOffset);

            float _outerOutlineOffset = outerOutlineOffset / sightConfig.GetMaxDistnce();
            material.SetFloat("_OuterOutlineOffset", _outerOutlineOffset);

            float _outlineAngleOffset = (360f - sightConfig.GetFov()) / 360f + _outerOutlineOffset;
            material.SetFloat("_OutlineAngleOffset", _outlineAngleOffset);
        }

        #region [Getter / Setter]
        public AIPerception GetAIPerception()
        {
            return aIPerception;
        }

        public void SetAIPerception(AIPerception value)
        {
            aIPerception = value;
        }

        public float GetMeshResolution()
        {
            return meshResolution;
        }

        public void SetMeshResolution(float value)
        {
            meshResolution = value;
        }

        public int GetEdgeResolveIterations()
        {
            return edgeResolveIterations;
        }

        public void SetEdgeResolveIterations(int value)
        {
            edgeResolveIterations = value;
        }

        public float GetEdgeDistanceThreshold()
        {
            return edgeDistanceThreshold;
        }

        public void SetEdgeDistanceThreshold(float value)
        {
            edgeDistanceThreshold = value;
        }

        public float GetInnerOffset()
        {
            return innerOffset;
        }

        public void SetInnerOffset(float value)
        {
            innerOffset = value;
        }

        public float GetOuterOutlineOffset()
        {
            return outerOutlineOffset;
        }

        public void SetOuterOutlineOffset(float value)
        {
            outerOutlineOffset = value;
        }

        public LayerMask GetEnemyLayer()
        {
            return enemyLayer;
        }

        public void SetEnemyLayer(LayerMask value)
        {
            enemyLayer = value;
        }
        #endregion
    }
}