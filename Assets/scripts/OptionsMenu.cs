using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private float originalMasterVolume;
    private float originalMusicVolume;
    private float originalSFXVolume;
    private int originalResolutionIndex;
    private bool originalFullscreen;

    private void Start()
    {
        // Load saved settings and store original values
        LoadSettings();
        StoreOriginalSettings();
    }

    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        // Assuming you have a separate audio source for music
        // musicAudioSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        // Assuming you have a separate audio source for SFX
        // sfxAudioSource.volume = volume;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = Screen.resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void LoadSettings()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", 0);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
    }

    private void StoreOriginalSettings()
    {
        originalMasterVolume = masterVolumeSlider.value;
        originalMusicVolume = musicVolumeSlider.value;
        originalSFXVolume = sfxVolumeSlider.value;
        originalResolutionIndex = resolutionDropdown.value;
        originalFullscreen = fullscreenToggle.isOn;
    }

    private void RestoreOriginalSettings()
    {
        masterVolumeSlider.value = originalMasterVolume;
        musicVolumeSlider.value = originalMusicVolume;
        sfxVolumeSlider.value = originalSFXVolume;
        resolutionDropdown.value = originalResolutionIndex;
        fullscreenToggle.isOn = originalFullscreen;

        // Apply settings immediately if needed
        SetMasterVolume(originalMasterVolume);
        SetMusicVolume(originalMusicVolume);
        SetSFXVolume(originalSFXVolume);
        SetResolution(originalResolutionIndex);
        SetFullscreen(originalFullscreen);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.SetInt("Resolution", resolutionDropdown.value);
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Return to main menu
        SceneManager.LoadScene("MainMenu");
    }

    public void Cancel()
    {
        RestoreOriginalSettings();
        SceneManager.LoadScene("MainMenu");
    }
}
