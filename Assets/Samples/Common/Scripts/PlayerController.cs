/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;

namespace RenownedGames.AITree.Samples
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed = 6f;

        // Stored required components.
        private CharacterController characterController;

        /// <summary>
        /// Called when an enabled script instance is being loaded.
        /// </summary>
        protected virtual void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        /// <summary>
        /// Called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        protected virtual void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            characterController.Move(new Vector3(x, 0, y).normalized * Time.deltaTime * speed);
        }

        #region [Getter / Setter]
        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float value)
        {
            speed = value;
        }

        public CharacterController GetCharacterController()
        {
            return characterController;
        }
        #endregion
    }
}