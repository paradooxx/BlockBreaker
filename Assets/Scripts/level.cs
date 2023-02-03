using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level : MonoBehaviour
{
   [SerializeField] int breakableBlocks; 
   SceneLoader sceneloader;

   private void Start() 
   {
      sceneloader = FindObjectOfType<SceneLoader>();   
   }

   public void CountBreakableBlocks()
   {
      breakableBlocks++;
   }

   public void BlockDestroyed()
   {
      breakableBlocks--;
      if(breakableBlocks <= 0)
      {
         
         sceneloader.LoadNextScene();
      }
   }
}
