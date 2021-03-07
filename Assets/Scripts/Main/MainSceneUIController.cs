using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUIController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField]
    private Button closeSettingsPanelButton;
    [SerializeField]
    private Button soundButton;
    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private GameObject settingsPanel;

    [SerializeField]
    private Sprite onMusicSprite;
    [SerializeField]
    private Sprite offMusicSprite;
    [SerializeField]
    private Sprite onSoundSprite;
    [SerializeField]
    private Sprite offSoundSprite;

    //Add listener for all keys
    //Play background music
    //Check the state of audio to display the right sprite when the game first launched.
    void Start()
    {
        playButton.onClick.AddListener(UserClickedPlayButton);
        settingsButton.onClick.AddListener(UserClickedSettingsButton);
        closeSettingsPanelButton.onClick.AddListener(UserClickedCloseSettingsButton);
        soundButton.onClick.AddListener(UserClickedSoundButton);
        musicButton.onClick.AddListener(UserClickedMusicButton);
        ChangeSpriteforAudioButton(soundButton, onSoundSprite, offSoundSprite, AudioManager.instance.IsAudioOn(AudioManager.keySoundFxPlayerPrefs));
        ChangeSpriteforAudioButton(musicButton, onMusicSprite, offMusicSprite, AudioManager.instance.IsAudioOn(AudioManager.keyMusicPlayerPrefs));
    }

    //Get called when user click music button to stop/play background music.
    //It changes the button sprite to the corresponding sprite.
    //if the key is on it change it to off, if an off change to on.
    //play background clip.
    private void UserClickedMusicButton()
    {
        AudioManager.instance.ChangeStateForAudioByKey(AudioManager.keyMusicPlayerPrefs);
        ChangeSpriteforAudioButton(musicButton, onMusicSprite, offMusicSprite, AudioManager.instance.IsAudioOn(AudioManager.keyMusicPlayerPrefs));
        AudioManager.instance.PlaySound(EAudioType.Background);
    }

    //Get called when user click the sound button to stop or play soundFx.
    //it changes the button sprite to the corresponding sprite.
    //if the key is on it change it to off, if an off change to on
    //and play click clip.
    private void UserClickedSoundButton()
    {
        AudioManager.instance.ChangeStateForAudioByKey(AudioManager.keySoundFxPlayerPrefs);
        ChangeSpriteforAudioButton(soundButton, onSoundSprite, offSoundSprite, AudioManager.instance.IsAudioOn(AudioManager.keySoundFxPlayerPrefs));
        AudioManager.instance.PlaySound(EAudioType.Click);
    }

    //Check if audio is playing and display corspoinding sprite.
    //parameters:
    //      audioButton: the button to check.
    //      onSprite: the active sprite.
    //      offSprite: the iactive sprite
    private void ChangeSpriteforAudioButton(Button audioButton,Sprite onSprite,Sprite offSprite,bool isActive)
    {
        audioButton.gameObject.GetComponent<Image>().sprite = isActive ? onSprite : offSprite;
    }

    //Get called when user click close settings panel, it start coroutine to wait for animation to finish.
    private void UserClickedCloseSettingsButton()
    {
        AudioManager.instance.PlaySound(EAudioType.Transition);
        settingsPanel.GetComponent<Animator>().SetBool("CloseSettingsPanel", true);
        StartCoroutine("WaitToAniamtionDone");   
    }

    private void UserClickedSettingsButton()
    {
        AudioManager.instance.PlaySound(EAudioType.Click);
        settingsPanel.SetActive(true);
    }

    private void UserClickedPlayButton()
    {
        AudioManager.instance.PlaySound(EAudioType.Click);
        SceneManager.LoadScene("Level_1");
    }

    //Wait for 0.2 seconds, and after set the seetingsPanel to unactive.
    public IEnumerator WaitToAniamtionDone()
    {
        yield return new WaitForSeconds(0.2f);
        settingsPanel.SetActive(false);
    }
 
}
