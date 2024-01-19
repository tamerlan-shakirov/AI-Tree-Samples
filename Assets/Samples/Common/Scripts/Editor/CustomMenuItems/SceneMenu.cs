/* ================================================================
   ----------------------------------------------------------------
   Project   :   AI Tree Samples
   Publisher :   Renowned Games
   Developer :   Tamerlan Shakirov
   ----------------------------------------------------------------
   Copyright 2024 Renowned Games All rights reserved.
   ================================================================ */

using UnityEditor;
using UnityEditor.SceneManagement;

namespace RenownedGames.AITreeEditor.Samples
{
    static class SceneMenu
    {
        [MenuItem("Tools/AI Tree/Samples/Bootstrap")]
        static void OpenIntroScene()
        {
            const string PATH = "Assets/Samples/Common/Scenes/IntroScene/IntroScene.unity";
            EditorSceneManager.OpenScene(PATH, OpenSceneMode.Single);
            EditorApplication.EnterPlaymode();
        }

        [MenuItem("Tools/AI Tree/Samples/Menu Scene")]
        static void OpenMenuScene()
        {
            const string PATH = "Assets/Samples/Common/Scenes/ShowcaseSelecter/ShowcaseSelector.unity";
            EditorSceneManager.OpenScene(PATH, OpenSceneMode.Single);
            EditorApplication.EnterPlaymode();
        }
    }
}
