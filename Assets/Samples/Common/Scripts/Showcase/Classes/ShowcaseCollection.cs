/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using System.Collections.Generic;
using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [CreateAssetMenu(fileName = "ShowcaseCollection", menuName = "Renowned Games/Asset Showcase/Showcase Collection")]
    public sealed class ShowcaseCollection : ScriptableObject
    {
        [SerializeField]
        [Array]
        private List<Showcase> showcases;

        /// <summary>
        /// Add new showcase.
        /// </summary>
        /// <param name="showcase"></param>
        public void AddShowcase(Showcase showcase)
        {
            showcases.Add(showcase);
        }

        /// <summary>
        /// Remove showcase by index.
        /// </summary>
        /// <param name="index">Index of showcase.</param>
        public void RemoveShowcase(int index)
        {
            showcases.RemoveAt(index);
        }

        /// <summary>
        /// Called when scriptable object being created
        /// or click Reset button in inspector window.
        /// </summary>
        private void Reset()
        {
            showcases = new List<Showcase>();
        }

        /// <summary>
        /// Loop through all showcases in collection.
        /// </summary>
        public IEnumerable<Showcase> Showcases
        {
            get
            {
                return showcases;
            }
        }

        #region [Getter / Setter]
        public Showcase GetShowcase(int index)
        {
            return showcases[index];
        }

        public void SetShowcase(int index, Showcase showcase)
        {
            showcases[index] = showcase;
        }

        public int GetShowcaseCount()
        {
            return showcases.Count;
        }
        #endregion
    }
}