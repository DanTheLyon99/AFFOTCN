using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
   
   public void QuitTheGame()
   {
      
      UnityEditor.EditorApplication.isPlaying = false;
      Application.Quit();
   }
}
