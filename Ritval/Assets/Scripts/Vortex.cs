using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vortex : MonoBehaviour
{
    public string LevelName;
    private int rot;

    void Start(){
        rot = 0;
    }
    void Update()
    {
        transform.Rotate(new Vector3(rot, rot, Time.deltaTime * 50));
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "Player"){
            rot = 200;
            collider.gameObject.SetActive(false);
            GetComponent<AudioSource>().Play();
            Invoke("LoadLevel", 2f);
        }
    }

    void LoadLevel(){
        SceneManager.LoadScene(LevelName);
    }
}
