using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Audio Variables
    
    private AudioSource BgMusicAudio;
    private bool SfxConfirm;
    private Image MusicBar;
    private int SfxSave;
    private float MusicLevel;

    #endregion

    #region Public GameObject
    
    public GameObject Music;
    public GameObject BgMusic;
    public GameObject SettingsMenu;
    public GameObject SfxActive;
    public GameObject SfxInactive;
    public GameObject RestartMessage;

    #endregion

    private void Awake()
    {
        BgMusicAudio = BgMusic.GetComponent<AudioSource>();
        MusicBar = Music.GetComponent<Image>();

        // "BmControl" controls whether the background music has been assigned a value
        if (PlayerPrefs.GetInt("BmControl") != 1)
        {
            PlayerPrefs.SetFloat("BackgroundMusic", 0.5f);
        }

        // "BackgroundMusic" keeps the value of the background music
        MusicBar.fillAmount = PlayerPrefs.GetFloat("BackgroundMusic");
        BgMusicAudio.volume = PlayerPrefs.GetFloat("BackgroundMusic");

        Debug.Log(PlayerPrefs.GetFloat("BackgroundMusic"));


    }
    #region Settings
    private void Start()
    {
        if (PlayerPrefs.GetInt("SfxActive") == 1)
        {

            SfxActive.SetActive(true);
            SfxInactive.SetActive(false);

        }
        else
        {

            SfxInactive.SetActive(true);
            SfxActive.SetActive(false);

        }

    }

    #region SFX Control
    public void SfxCon()
    {
        SfxConfirm = !SfxConfirm;
        Debug.Log(SfxConfirm);

        if (SfxConfirm == true)
        {
            SfxActive.SetActive(true);
            SfxInactive.SetActive(false);
            SfxSave = 1;

            //Keeps the value whether sfx is active or not
            PlayerPrefs.SetInt("SfxActive", SfxSave);
        }
        else 
        {
            SfxInactive.SetActive(true);
            SfxActive.SetActive(false);
            SfxSave = 0;

            //Keeps the value whether sfx is active or not
            PlayerPrefs.SetInt("SfxActive",SfxSave);
        }
    }
    #endregion

    #region Background Music
    public void BgMusicMinus() 
    {
        MusicLevel =MusicBar.fillAmount-0.05f;
        
        PlayerPrefs.SetFloat("BackgroundMusic",MusicLevel);

        MusicBar.fillAmount = PlayerPrefs.GetFloat("BackgroundMusic");
        BgMusicAudio.volume = PlayerPrefs.GetFloat("BackgroundMusic");

        PlayerPrefs.SetInt("BmControl", 1);

        Debug.Log(PlayerPrefs.GetFloat("BackgroundMusic"));
    }
    public void BgMusicPlus()
    {
        MusicLevel = MusicBar.fillAmount+0.05f;
        
        PlayerPrefs.SetFloat("BackgroundMusic",MusicLevel);

        MusicBar.fillAmount = PlayerPrefs.GetFloat("BackgroundMusic");
        BgMusicAudio.volume = PlayerPrefs.GetFloat("BackgroundMusic");

        PlayerPrefs.SetInt("BmControl", 1);

        Debug.Log(PlayerPrefs.GetFloat("BackgroundMusic"));
    }
    #endregion
    public void SettingsExit() 
    {
        SettingsMenu.SetActive(false);
    }
    public void SettingsOpen() 
    {
        SettingsMenu.SetActive(true);
    }
    #endregion
    public void GoPLayScene() 
    {
        // "Prepare" holds the variable that checks if you pass into the company name setting scene
        if (PlayerPrefs.GetInt("Prepare") == 1)
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
        else 
        {
            SceneManager.LoadScene("PrepareScene", LoadSceneMode.Single);
        }
        
    }
    #region Restart
    public void DeleteAllData() 
    {
        RestartMessage.SetActive(true);
    }
    public void Yes() 
    {
        PlayerPrefs.DeleteAll();
        RestartMessage.SetActive(false);
    }
    public void No() 
    {
        RestartMessage.SetActive(false);
    }
    #endregion
}