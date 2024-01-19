/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Vladimir Deryabin
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using RenownedGames.Apex;
using UnityEngine.AI;
using System;
using Random = UnityEngine.Random;

#if UNITY_EDITOR
using RenownedGames.ExLibEditor;
#endif

namespace RenownedGames.AITree.Samples
{
    public sealed class CoinSpawner : MonoBehaviour
    {
        [SerializeField]
        private Coin coinPrefab;

        [SerializeField]
        private float radius = 10f;

        [SerializeField]
        [ReadOnly]
        private int collected;

        /// <summary>
        /// Called on the frame when a script is enabled,
        /// just before any of the Update methods are called the first time.
        /// </summary>
        private void Start()
        {
            CreateCoin();
        }

        private void CreateCoin()
        {
            Vector3 position = RandomPosition();
            Coin coin = Instantiate(coinPrefab, position, Quaternion.identity, transform);
            coin.Collect += OnCollect;
        }

        private Vector3 RandomPosition()
        {
            Vector2 unitCircle = Random.insideUnitCircle * radius;
            Vector3 position = transform.position + new Vector3(unitCircle.x, 0, unitCircle.y);

            if (NavMesh.SamplePosition(position, out NavMeshHit hitInfo, float.MaxValue, NavMesh.AllAreas))
            {
                return new Vector3(hitInfo.position.x, position.y, hitInfo.position.z);
            }

            return position;
        }

        private void OnCollect()
        {
            collected++;
            CreateCoin();
            Collect?.Invoke(collected);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            HandlesUtility.color = Color.black;
            HandlesUtility.DrawWireCircle(transform.position, radius, Vector3.up, 1f);

            HandlesUtility.color = new Color(1, 1, 0, .02f);
            HandlesUtility.DrawSolidCircle(transform.position, radius, Vector3.up);
        }
#endif

        #region [Events]
        /// <summary>
        /// Called after the coin is picked up.
        /// </summary>
        public event Action<int> Collect;
        #endregion

        #region [Getter / Setter]
        public Coin GetCoinPrefab()
        {
            return coinPrefab;
        }

        public void SetCoinPrefab(Coin value)
        {
            coinPrefab = value;
        }

        public float GetRadius()
        {
            return radius;
        }

        public void SetRadius(float value)
        {
            radius = value;
        }

        public int GetCollected()
        {
            return collected;
        }

        public void SetCollected(int value)
        {
            collected = value;
        }
        #endregion
    }
}
