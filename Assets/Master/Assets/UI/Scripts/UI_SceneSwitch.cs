using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 
/// LoadSceneAsync : https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadSceneAsync.html
/// </summary>
namespace ScottBarley.IGB100.V1
{
    public class UI_SceneSwitch : MonoBehaviour
    {

        // Normal Change Scene
        public void fn_ChangeToScene(string sceneToChange)
        {
            SceneManager.LoadScene(sceneToChange);
        }


        // Async Change Scene
        public void fn_LoadSceneAsync(string sceneToChange)
        {
            StartCoroutine(LoadYourAsyncScene(sceneToChange));
        }

        IEnumerator LoadYourAsyncScene(string sceneToChange)
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToChange);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        // Quit Game
        public void fn_QuitTheGame()
        {
            Application.Quit();

#if UNITY_EDITOR

            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
    }
}