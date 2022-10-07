using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemeWorldManager : MonoBehaviour //Singleton 
{
    [Space]
    [Header("Data Game")]
    [SerializeField] GameConfig GameConfig;

    [Space]
    private GameStates _gameStates;
    [SerializeField] public GameStates gameStates
    {
        get { return _gameStates; }
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
        }
    }

    private void StartGame() 
    {

    }

    private void StartManu()
    {

    }

    public enum GameStates 
    {
        Manu,
        Game,
    }
}
