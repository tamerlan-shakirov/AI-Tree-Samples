/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Zinnur Davleev
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    public class MouseMover : MonoBehaviour
    {
        [SerializeField]
        private Vector2 limitX = new Vector2(-15, 15);

        [SerializeField]
        private Vector2 limitZ = new Vector2(-15, 15);

        [SerializeField]
        private float yOffset;

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        protected virtual void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Plane plane = new Plane(Vector3.up, 0);
            if (Input.GetMouseButton(0) && plane.Raycast(ray, out float enter))
            {
                Vector3 position = ray.GetPoint(enter);

                position.x = Mathf.Clamp(position.x, limitX.x, limitX.y);
                position.z = Mathf.Clamp(position.z, limitZ.x, limitZ.y);

                position.y = yOffset;

                transform.position = position;
            }
        }

        #region [Getter / Setter]
        public Vector2 GetLimitX()
        {
            return limitX;
        }

        public void SetLimitX(Vector2 value)
        {
            limitX = value;
        }

        public Vector2 GetLimitZ()
        {
            return limitZ;
        }

        public void SetLimitZ(Vector2 value)
        {
            limitZ = value;
        }

        public float GetYOffset()
        {
            return yOffset;
        }

        public void SetYOffset(float value)
        {
            yOffset = value;
        }
        #endregion
    }
}
