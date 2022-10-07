using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemeWorldManager : MonoBehaviour //Singleton 
{
    [Space]
    [Header("Data Game")]
    [SerializeField] public GameConfig GameConfig;

    [Space]
    private GameStates _gameStates = GameStates.None;

    [Space]
    [Header("Game Managers")]
    [SerializeField] MoveMouse moveMouse;
    [SerializeField] SphereGenerator sphereGenerator;
    [SerializeField] UIManager uIManager;
    [SerializeField] public GameStates gameStates
    {
        get
        { 
            return _gameStates;
        }
        set
        {
            if(value != _gameStates) 
            {
                ChangeGameStates(value);
                _gameStates = value;
            }
        } 
    }


    public static GemeWorldManager instance;
    private void Start()
    {
        instance = this;
        SetStates(GameStates.Manu);
        uIManager.SetScreenUI(UIManager.StateUI.Menu);

        if (GameConfig == null)       
            GameConfig = Resources.Load<GameConfig>("Default_GameConfig");     
    }


    public void SetStates(GameStates __gameStates) 
    {
        gameStates = __gameStates;
    }

    private void ChangeGameStates(GameStates gameStates) 
    {
        switch(gameStates)
        {
            case GameStates.Game:
                StartGame();
                break;
            case GameStates.Manu:
                StartManu();
                break;
            case GameStates.ExitGame:
                Application.Quit();
                break;
        }
    }

    private void StartGame() 
    {
        moveMouse.isMove = true;
        sphereGenerator.GenerSphers();
    }

    private void StartManu()
    {
        moveMouse.isMove = false;
        sphereGenerator.ClinerSphersContener();
    }

    public enum GameStates 
    {
        None,
        Manu,
        Game,
        ExitGame,
    }
}
