using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject World;
    public GameObject UnderWorld;
    public GameObject Camera;
    public GameObject DeathMenu;
    public GameObject PauseMenu;

    private bool revert;
    private Camera Cam;
    private bool IsPaused;
    
    public static GameController Instance;

    void Start()
    {
        revert = false;
        Cam = Camera.GetComponent<Camera>();
        Instance = this;
        IsPaused = false;
    }

    void Update()
    {
        RevertWorld();
        if(Input.GetKeyDown(KeyCode.P)){
            IsPaused = !IsPaused;
            SwitchPause(IsPaused);
        }
    }
    
    void SwitchPause(bool pauseState){
        if(pauseState){
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }else{
            DeathMenu.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    void RevertWorld(){
        if(Input.GetButtonDown("Jump")){
            if(revert){
                World.SetActive(true);
                UnderWorld.SetActive(false);
                Cam.backgroundColor = new Color(0.2039216f, 0.1254902f, 0.1686275f, 1f);
            }else{
                World.SetActive(false);
                UnderWorld.SetActive(true);
                Cam.backgroundColor = new Color(0.1647059f, 0.1647059f, 0.1647059f, 1f);
            }
            revert = !revert;
        }
    }

    public void ShowMenuDeath(){
        DeathMenu.SetActive(true);
    }

    public void QuitGame(){
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
