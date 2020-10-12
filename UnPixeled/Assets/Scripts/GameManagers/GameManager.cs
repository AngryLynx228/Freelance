using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables //__________________________________________________________________________________________________________________________________________________________________________
    [SerializeField] public GameObject floatingText;

    
    [SerializeField] public Color[] damageColor;//Floating text colors

    
    public playerController player; // player reference in scene
    public GUIManager GUI; // GUI reference in scene



    #region Singleton

    public static GameManager instance;

void Awake ()
  {
      if (instance == null) 
      {
          instance = this;
      } else if (instance != this) 
      {
          Destroy(gameObject);
          return;
      }
  
        findObjects();
        DontDestroyOnLoad(gameObject);

            



    }

    #endregion

    void findObjects()//____________________________________________________________________________________________________________________________________________________________________________
    {
        player = FindObjectOfType<playerController>();
        GUI = FindObjectOfType<GUIManager>();
    }
}
