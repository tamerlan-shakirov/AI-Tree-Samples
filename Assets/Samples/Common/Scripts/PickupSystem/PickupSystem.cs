/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.Events;

namespace RenownedGames.AITree.Samples
{
    public sealed class PickupSystem : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent pickupEvent;

        /// <summary>
        /// Called in FixedUpdate tick, when a GameObject collides with another GameObject.
        /// </summary>
        /// <param name="other">A Collider involved in this collision.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PickupObject>(out PickupObject pickupObject))
            {
                pickupObject.Pickup();
                pickupEvent.Invoke();
            }
        }

        /// <summary>
        /// Add a non persistent listener to the UnityEvent.
        /// </summary>
        /// <param name="action">Callback function.</param>
        public void AddListener(UnityAction action)
        {
            pickupEvent.AddListener(action);
        }

        /// <summary>
        /// Remove a non persistent listener from the UnityEvent. If you have added the same 
        /// listener multiple times, this method will remove all occurrences of it.
        /// </summary>
        /// <param name="action">Callback function.</param>
        public void RemoveListener(UnityAction action)
        {
            pickupEvent.RemoveListener(action);
        }

        /// <summary>
        /// Remove all non-persistent (ie created from script) listeners from the event.
        /// </summary>
        public void RemoveAllListener()
        {
            pickupEvent.RemoveAllListeners();
        }
    }
}