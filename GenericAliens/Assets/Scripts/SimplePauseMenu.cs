using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePauseMenu : MonoBehaviour
{
    
    
    
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject QuitToTitleWarningBox;
    [SerializeField] GameObject QuitGameWarningBox;
    [SerializeField] bool IsPaused;
    
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        IsPaused = true;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
        QuitToTitleWarningBox.SetActive(false);
        QuitGameWarningBox.SetActive(false);
        IsPaused = false;

    }

    public void ActivateOptionsMenu()
    {
        OptionsMenu.SetActive(true);
    }

    public void QuitToTitleWarning()
    {
        QuitToTitleWarningBox.SetActive(true);
    }

    public void QuitGameWarning()
    {
        QuitGameWarningBox.SetActive(true);
    }

    public void QuitToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        //Checks if the Pause Menu is active when Esc is pressed. If not, make it active. If so, make it no longer active.
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused)
        {
            Resume();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && IsPaused == false)
        {
            Pause();
        }

    }

    void Start()
    {
        IsPaused = false;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

}
