using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void StartGame(string nameScene){
        SceneManager.LoadScene(nameScene);
    }

    public void QuitGame(){
        Application.Quit();
    }

}
