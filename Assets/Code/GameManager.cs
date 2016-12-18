/*See https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/ for details! */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //----------------------------------------
    // handles
    // For concrete Game:
    public WorldGenerator worldGenerator;
    public UnityEngine.Canvas menuCanvas;
    public enum GameState { Playing, Paused};
    public GameState gameState;

    // Use this for initialization
    void Start () {
        menuCanvas.enabled = false;
        //menuCanvas.gameObject.SetActive(false);
        gameState = GameState.Playing;
        GenerateMap();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    //void GenerateMap(GameSettings settings) { ... }
    void GenerateMap() { worldGenerator.StartGenerateWorld(); }
    public void StartNewGame() { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void TogglePauseMenu()
    {
        switch(gameState)
        {
            case GameState.Playing: {
                    // First Person Controller react for Escape automatic with its Script
                    menuCanvas.enabled = true;
                    //menuCanvas.gameObject.SetActive(true);
                    Time.timeScale = 0f;
                    gameState = GameState.Paused;
                } break;
            case GameState.Paused:
                {
                    menuCanvas.enabled = false;
                    //menuCanvas.gameObject.SetActive(false);
                    Time.timeScale = 1.0f;
                    gameState = GameState.Playing;
                } break;
        }
        Debug.Log("GameManager.TogglePauseMen");
        Debug.LogError("GameManager.TogglePauseMen");
        //Resources.FindObjectsOfTypeAll - you can search by script (better)
        
        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }
}
