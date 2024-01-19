/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.AITree.EQS;
using System.Collections.Generic;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    public sealed class EQSVisualization : MonoBehaviour
    {
        [SerializeField]
        private EnvironmentQuery environmentQuery;

        [SerializeField]
        private Material material;

        [SerializeField]
        private float scale = 1f;

        // Stored required properties.
        private Mesh mesh;
        private List<EQItem> items;
        private MaterialPropertyBlock[] blocks;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            mesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        }

        /// <summary>
        /// Called when the object becomes enabled and active.
        /// </summary>
        private void OnEnable()
        {
            environmentQuery.onItemsUpdate += OnUpdateItems;
        }

        /// <summary>
        /// Called when the behaviour becomes disabled.
        /// </summary>
        private void OnDisable()
        {
            environmentQuery.onItemsUpdate -= OnUpdateItems;
        }

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            if (material == null || items == null) return;

            if (blocks == null || blocks.Length != items.Count)
            {
                blocks = new MaterialPropertyBlock[items.Count];
                for (int i = 0; i < blocks.Length; i++)
                {
                    blocks[i] = new MaterialPropertyBlock();
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                EQItem item = items[i];
                Matrix4x4 matrix = new Matrix4x4();
                matrix.SetTRS(item.GetPosition(), Quaternion.identity, Vector3.one * scale);

                MaterialPropertyBlock block = blocks[i];
                block.SetVector("_Color", Color.Lerp(Color.red, Color.green, item.GetScore()));
                block.SetVector("_Center", transform.position);
                block.SetFloat("_Score", item.GetScore());

                Graphics.DrawMesh(mesh, matrix, material, 0, null, 0, block, false);
            }
        }

        /// <summary>
        /// Called when environment query updated items.
        /// </summary>
        /// <param name="items">New update items list.</param>
        private void OnUpdateItems(List<EQItem> items)
        {
            this.items = items;
        }

        #region [Getter / Setter]
        public EnvironmentQuery GetEnvironmentQuery()
        {
            return environmentQuery;
        }

        public void SetEnvironmentQuery(EnvironmentQuery value)
        {
            environmentQuery = value;
        }

        public Material GetMaterial()
        {
            return material;
        }

        public void SetMaterial(Material value)
        {
            material = value;
        }

        public float GetScale()
        {
            return scale;
        }

        public void SetScale(float value)
        {
            scale = value;
        }
        #endregion
    }
}