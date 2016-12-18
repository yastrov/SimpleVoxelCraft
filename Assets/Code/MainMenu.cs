/*
It's very simple menu!
See "game" scene and that's menu with Canvas, EventSystem, Panels and UIManager.cs.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GUIStyle welcomeLabel;
    public GUISkin customSkin;
    public Rect playGameRect;
    public Rect optionsRect;
    public Rect quitRect;

    private enum MenuMode { Main, Options };
    private MenuMode _optionsMode;

    public float _Impulse = 300;
    public float _Delay = 1;

    // Use this for initialization
    void Start()
    {
        Debug.Log("MENU Start!");
        _optionsMode = MenuMode.Main;
    }

    void OnGUI()
    {
        Debug.Log("MENU!");
        switch (_optionsMode)
        {
            case MenuMode.Main:
                {
                    GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Welcome", welcomeLabel);
                    GUI.skin = customSkin;
                    if (GUI.Button(playGameRect, "Play Game"))
                    {
                        SceneManager.LoadScene("game");

                    }
                    if (GUI.Button(optionsRect, "Options"))
                    {
                        _optionsMode = MenuMode.Options;
                    }
                    if (GUI.Button(quitRect, "Quit"))
                    {
                        
                        Application.Quit();
                    }
                }
                break;
            case MenuMode.Options:
                {
                    GUI.Label(new Rect(Screen.width / 2, 0, 50, 20), "Options", welcomeLabel);

                    GUI.skin = customSkin;

                    GUI.Label(new Rect(270, 75, 50, 20), "Impulse");
                    _Impulse = GUI.HorizontalSlider(new Rect(50, 100, 500, 20), _Impulse, 10, 700);
                    GUI.Label(new Rect(560, 95, 50, 20), _Impulse.ToString());

                    GUI.Label(new Rect(270, 125, 50, 20), "Delay");
                    _Delay = GUI.HorizontalSlider(new Rect(50, 150, 500, 20), _Delay, 1, 3);
                    GUI.Label(new Rect(560, 145, 50, 20), _Delay.ToString());

                    if (GUI.Button(new Rect(20, 190, 100, 30), "<< Back"))
                    {
                        _optionsMode = MenuMode.Main;
                    }
                }
                break;
        }

    }
}
