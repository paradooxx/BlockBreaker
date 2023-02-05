using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
   {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
   }

   public void LoadStartingScene()
   {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().DestroyGameObject();
   }

   public void QuitGame()
   {
     #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
   }
}
