using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Space]
    [Header("UI Element")]
    [SerializeField] GameObject MainContener;
    [SerializeField] GameObject GameContener;

    [SerializeField] Button ExitButton;
    [SerializeField] Button StartManuButton;
    [SerializeField] Button StartGameButton;

    private void Awake()
    {
        ExitButton.onClick.AddListener(() =>
        {
            GemeWorldManager.instance.SetStates(GemeWorldManager.GameStates.ExitGame);
        });

        StartManuButton.onClick.AddListener(() =>
        {
            GemeWorldManager.instance.SetStates(GemeWorldManager.GameStates.Manu);
            SetScreenUI(StateUI.Menu);
        });

        StartGameButton.onClick.AddListener(() =>
        {
            GemeWorldManager.instance.SetStates(GemeWorldManager.GameStates.Game);
            SetScreenUI(StateUI.Game);
        });
    }

    public void SetScreenUI(StateUI stateUI) 
    {
        if (stateUI == StateUI.Game)
        {
            MainContener.SetActive(false);
            GameContener.SetActive(true);
        }
        else 
        {
            MainContener.SetActive(true);
            GameContener.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GemeWorldManager.instance.SetStates(GemeWorldManager.GameStates.Manu);
            SetScreenUI(StateUI.Menu);
        }
    }

    public enum StateUI 
    {
        Menu,
        Game
    }
}
