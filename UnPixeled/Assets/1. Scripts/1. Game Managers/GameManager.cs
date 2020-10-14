using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variables //__________________________________________________________________________________________________________________________________________________________________________
    [SerializeField] public GameObject floatingText;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject gameCamera;


    
    [SerializeField] public Color[] damageColor;//Floating text colors

    
    [HideInInspector] public playerController playerController; // player reference in scene
    [HideInInspector] public GUIManager GUIManager; // GUI reference in scene



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

        Instantiate(player);
        Instantiate(gameCamera);

        findObjects();
        DontDestroyOnLoad(gameObject);

            



    }

    #endregion


    void findObjects()//____________________________________________________________________________________________________________________________________________________________________________
    {
        playerController = FindObjectOfType<playerController>();
        GUIManager = FindObjectOfType<GUIManager>();
    }
}
