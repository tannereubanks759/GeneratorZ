using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Ui : MonoBehaviour
{
    public GameObject pauseScreen;

    public GameManager gm;

    public bool isPaused = false;

    public AudioSource click;

    public bool inGame = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        
        if(SceneManager.GetActiveScene().name == "End" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            inGame = false;
        }
        else
        {
            inGame = true;
            pauseScreen.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gm.isDead!=true && inGame == true)
        {
            pause();
        }
    }
    public void LoadScene(string scene)
    {
        click.Play();
        SceneManager.LoadScene(scene);
    }
    public void quit()
    {
        click.Play();
        Application.Quit();
    }
    public void resume()
    {
        click.Play();
        isPaused = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
    public void pause()
    {
        if (SceneManager.GetActiveScene().name == "End" || SceneManager.GetActiveScene().name == "MainMenu")
        {
            inGame = false;
        }
        else
        {
            click.Play();
            isPaused = !isPaused;
            if (isPaused)
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        
    }
    
}
