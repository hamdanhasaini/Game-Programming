using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonManager : MonoBehaviour {

    public void song1Btn(string newsong1) {
        SceneManager.LoadScene(newsong1);
    }
    public void song2Btn(string newSong2)
    {
        SceneManager.LoadScene(newSong2);
    }
    public void song3Btn(string newSong3)
    {
        SceneManager.LoadScene(newSong3);
    }

    public void menuBtn(string menu) {
        SceneManager.LoadScene(menu);
    }

    public void exitBtn() {
        Application.Quit();
    }



}
