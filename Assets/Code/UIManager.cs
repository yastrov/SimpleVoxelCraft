/*See https://vilbeyli.github.io/Unity3D-How-to-Make-a-Pause-Menu/ for details! 
We Also need own EventSystem in Scene!!*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameManager GM;
    public MusicManager MM;

    private Slider _musicSlider;

    // Use this for initialization
    void Start()
    {
        //--------------------------------------------------------------------------
        // Game Settings Related Code


        //--------------------------------------------------------------------------
        // Music Settings Related Code
         _musicSlider = GameObject.Find("Music_Slider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { TogglePauseMenu(); }
    }

    void ScanForKeyStroke()
    {
        if (Input.GetKeyDown("escape")) { TogglePauseMenu(); }
    }

    //-----------------------------------------------------------
    // Game Options Function Definitions
    public void OptionSliderUpdate(float val) {; }
    void SetCustomSettings(bool val) {; }
    //void WriteSettingsToInputText(GameSettings settings) { ... }

    //-----------------------------------------------------------
    // Music Settings Function Definitions
    public void MusicSliderUpdate(float val)
    {
        MM.SetVolume(val);
    }

    public void MusicToggle(bool val)
    {
        _musicSlider.interactable = val;
        MM.SetVolume(val ? _musicSlider.value : 0f);
    }
    // Wrap GameManager function
    public void StartNewGame() { GM.StartNewGame(); }

    public void TogglePauseMenu() {
        Debug.Log("UIManager.TogglePauseMen");
        Debug.LogError("UIManager.TogglePauseMen");
        GM.TogglePauseMenu(); }
}
