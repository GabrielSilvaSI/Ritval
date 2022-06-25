using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject World;
    public GameObject UnderWorld;
    public GameObject Camera;

    private bool revert;
    private Camera Cam;

    void Start()
    {
        revert = false;
        Cam = Camera.GetComponent<Camera>();
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

    
}
