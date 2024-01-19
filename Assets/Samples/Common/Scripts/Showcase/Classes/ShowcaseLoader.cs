/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Company   :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RenownedGames.AITree.Samples
{
    [AddComponentMenu("Renowned Games/AI Tree Samples/Showcase Loader")]
    [DisallowMultipleComponent]
    public sealed class ShowcaseLoader : MonoBehaviour
    {
        [SerializeField]
        private ShowcaseCollection showcaseCollection;

        [SerializeField]
        private RectTransform contents;

        [SerializeField]
        private GameObject template;

        [SerializeField]
        private Text description;

        [SerializeField]
        private Button loadButton;

        [SerializeField]
        private ScreenFadeEffect fadeEffect;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            foreach (Showcase showcase in showcaseCollection.Showcases)
            {
                GameObject clone = Instantiate(template, contents);
                clone.name = showcase.GetName();

                Text name = clone.transform.GetChild(1).GetComponent<Text>();
                name.text = showcase.GetName();

                Transform preview = clone.transform.GetChild(0);
                Transform mask = preview.GetChild(0);

                Image image = mask.GetChild(0).GetComponent<Image>();
                image.sprite = showcase.GetPreview();

                Button button = clone.GetComponentInChildren<Button>();
                button.onClick.AddListener(()=> 
                {
                    if(description != null)
                    {
                        description.text = showcase.GetDescription();
                    }

                    loadButton.interactable = true;
                    loadButton.onClick.RemoveAllListeners();
                    loadButton.onClick.AddListener(()=> 
                    {
                        if(fadeEffect != null)
                        {
                            fadeEffect.OnFadeComplete += (mode) => SceneManager.LoadScene(showcase.GetSceneName(), LoadSceneMode.Single);
                            fadeEffect.FadeIn();
                        }
                        else
                        {
                            SceneManager.LoadScene(showcase.GetSceneName(), LoadSceneMode.Single);
                        }
                    });
                });
            }
            loadButton.interactable = false;
            template.SetActive(false);
        }

        public void ViewMore()
        {
            const string URL = "https://assetstore.unity.com/packages/slug/229578";
            Application.OpenURL(URL);
        }
    }
}