/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [DisallowMultipleComponent]
    public sealed class Banner : MonoBehaviour
    {
        [SerializeField]
        [NotNull]
        private Transform target;

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        private void Update()
        {
            //Vector3 direction = target.position - transform.position;
            //Quaternion lookRotation = Quaternion.LookRotation(direction);

            transform.forward = target.forward;
        }

        #region [Getter / Setter]
        public Transform GetTarget()
        {
            return target;
        }

        public void SetTarget(Transform value)
        {
            target = value;
        }
        #endregion
    }
}
