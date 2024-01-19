/* ================================================================
   ----------------------------------------------------------------
   Project   :   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using RenownedGames.Apex;
using RenownedGames.ExLib.Coroutines;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RenownedGames.AITree.Samples
{
    [HideMonoScript]
    [AddComponentMenu("Renowned Games/AI Tree Samples/Screen Fade Effect")]
    [DisallowMultipleComponent]
    public sealed class ScreenFadeEffect : MonoBehaviour
    {
        public enum FadeMode
        {
            FadeIn,
            FadeOut
        }

        [SerializeField]
        private bool playOnAwake = true;

        [SerializeField]
        [ShowIf("playOnAwake")]
        [MinValue(0.0f)]
        [Indent]
        private float delay = 1.0f;

        [SerializeField]
        private Color color = Color.black;

        [SerializeField]
        [Foldout("Fade In Settings", Style = "Group")]
        [Suffix(" sec")]
        [MinValue(0.01f)]
        private float inDuration = 0.35f;

        [SerializeField]
        [Foldout("Fade In Settings", Style = "Group")]
        private AnimationCurve inCurve = AnimationCurve.Linear(0, 0, 1, 1);

        [SerializeField]
        [Foldout("Fade Out Settings", Style = "Group")]
        [Suffix(" sec")]
        [MinValue(0.01f)]
        private float outDuration = 0.35f;

        [SerializeField]
        [Foldout("Fade Out Settings", Style = "Group")]
        private AnimationCurve outCurve = AnimationCurve.Linear(0, 0, 1, 1);

        // Stored required components.
        private GraphicRaycaster graphicRaycaster;
        private CanvasRenderer canvasRenderer;

        // Stored required properties.
        private CoroutineObject<FadeMode> fadeEffect;

        /// <summary>
        /// Called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            fadeEffect = new CoroutineObject<FadeMode>(this);

            Canvas canvas = CreateCanvas();
            graphicRaycaster = canvas.GetComponent<GraphicRaycaster>();

            Image image = CreateFullScreenImage(canvas);
            image.color = color;

            canvasRenderer = image.GetComponent<CanvasRenderer>();
            if (playOnAwake)
            {
                Invoke(nameof(FadeOut), delay);
            }
            else
            {
                canvasRenderer.SetAlpha(0);
            }
        }

        /// <summary>
        /// Fade effect coroutine.
        /// </summary>
        /// <param name="mode">Fade mode.</param>
        public IEnumerator Fade(FadeMode mode)
        {
            float duration = mode == FadeMode.FadeIn ? inDuration : outDuration;
            AnimationCurve curve = mode == FadeMode.FadeIn ? inCurve : outCurve;

            float time = 0;
            float speed = 1 / duration;

            float startAlpha = mode == FadeMode.FadeIn ? 0.0f : 1.0f;
            float targetAlpha = mode == FadeMode.FadeIn ? 1.0f : 0.0f;

            float startVolume = mode == FadeMode.FadeIn ? 1.0f : 0.0f;
            float targetVolume = mode == FadeMode.FadeIn ? 0.0f : 1.0f;

            graphicRaycaster.enabled = true;
            OnFadeStarted?.Invoke(mode);
            while (time < 1.0f)
            {
                time += speed * Time.unscaledDeltaTime;
                float step = curve.Evaluate(time);
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, step);
                float volume = Mathf.Lerp(startVolume, targetVolume, step);
                canvasRenderer.SetAlpha(alpha);
                AudioListener.volume = volume;
                OnFading?.Invoke(mode, step);
                yield return null;
            }
            OnFadeComplete?.Invoke(mode);
            graphicRaycaster.enabled = false;
        }

        #region [IFadeEffect Implementation]
        /// <summary>
        /// Play fade in effect.
        /// </summary>
        public void FadeIn()
        {
            fadeEffect.Start(Fade, FadeMode.FadeIn, true);
        }

        /// <summary>
        /// Play fade out effect.
        /// </summary>
        public void FadeOut()
        {
            fadeEffect.Start(Fade, FadeMode.FadeOut, true);
        }
        #endregion

        #region [Static Method]
        private static Canvas CreateCanvas()
        {
            GameObject canvasGO = new GameObject("Screen Fade Effect");
            // canvasGO.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector | HideFlags.NotEditable;

            Canvas canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 32767;

            CanvasScaler canvasScaler = canvasGO.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.referenceResolution = new Vector2(800, 600);
            canvasScaler.matchWidthOrHeight = 0.5f;
            canvasScaler.referencePixelsPerUnit = 100;

            GraphicRaycaster graphicRaycaster = canvasGO.AddComponent<GraphicRaycaster>();

            return canvas;
        }

        private static Image CreateFullScreenImage(Canvas canvas)
        {
            GameObject imageGO = new GameObject("Full Screen Image");
            imageGO.transform.SetParent(canvas.transform);

            Image image = imageGO.AddComponent<Image>();
            image.raycastTarget = true;
            image.maskable = false;

            RectTransform rectTransform = image.transform as RectTransform;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.pivot = Vector2.one / 2;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            return image;
        }
        #endregion

        #region [Event Callback Functions]
        /// <summary>
        /// Called when screen fading is complete.
        /// </summary>
        public Action<FadeMode> OnFadeStarted;

        /// <summary>
        /// Called every time while screen is fading.
        /// <br><b>arg1:</b> <i>Fade mode.</i></br>
        /// <br><b>arg2:</b> <i>Normalized fade transition state.</i></br>
        /// </summary>
        public Action<FadeMode, float> OnFading;

        /// <summary>
        /// Called when screen fading is complete.
        /// </summary>
        public Action<FadeMode> OnFadeComplete;
        #endregion

        #region [Getter / Setter]
        public bool PlayOnAwake()
        {
            return playOnAwake;
        }

        public void PlayOnAwake(bool value)
        {
            playOnAwake = value;
        }

        public float GetDuration()
        {
            return inDuration;
        }

        public void SetDuration(float value)
        {
            inDuration = value;
        }

        public AnimationCurve GetCurve()
        {
            return inCurve;
        }

        public void SetCurve(AnimationCurve value)
        {
            inCurve = value;
        }

        public Color GetColor()
        {
            return color;
        }

        public void SetColor(Color value)
        {
            color = value;
        }

        public CanvasRenderer GetCanvasRenderer()
        {
            return canvasRenderer;
        }

        public GraphicRaycaster GetGraphicRaycaster()
        {
            return graphicRaycaster;
        }
        #endregion
    }
}