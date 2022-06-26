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

    private bool revert;
    private Camera Cam;
    
    public static GameController Instance;

    void Start()
    {
        revert = false;
        Cam = Camera.GetComponent<Camera>();
        Instance = this;
    }

    void Update()
    {
        RevertWorld();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
