using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLevel0()
   {

       SceneManager.LoadScene(0);

   }
   public void LoadLevel1()
   {

       SceneManager.LoadScene(1);

   }
   public void LoadLevel2()
   {

       SceneManager.LoadScene(2);

   }
}
