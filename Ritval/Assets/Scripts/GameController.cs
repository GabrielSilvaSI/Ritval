using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject World;
    public GameObject UnderWorld;

    private bool revert;
    void Start()
    {
        revert = false;
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
            }else{
                World.SetActive(false);
                UnderWorld.SetActive(true);
            }
            revert = !revert;
        }
    }

    
}
