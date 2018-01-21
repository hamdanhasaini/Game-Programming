using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    int multiplier=2;
    int combo=0;
    public meter m;
    public float healthModVal = 10;


    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("Meter", 25);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        if (col.gameObject.tag == "Note") {
            resetCombo();
            m.decreaseHealth(healthModVal);
        }
    }

    

    public void addCombo() {
        combo++;
        if (combo >= 8)
            multiplier = 4;
        else if (combo >= 16)
            multiplier = 3;
        else if (combo >= 24)
            multiplier = 2;

        else 
            multiplier = 1;
        UpdateGUI();
    }

    public void resetCombo() {
        
           // PlayerPrefs.SetInt("Meter", PlayerPrefs.GetInt("Meter") - 2);

        //if (PlayerPrefs.GetInt("Meter") < 0) 
            
            combo = 0;
        multiplier = 1;
        UpdateGUI();
    }
    public void Lose() {
        SceneManager.LoadScene("Gameover");
    }

    public void gameFinished() {
        SceneManager.LoadScene("Clear");
    }

    public void UpdateGUI() {
        PlayerPrefs.SetInt("Combo", combo);
        PlayerPrefs.SetInt("Mult", multiplier);
    }
    public int getScore()
    {
        return 100*multiplier;
      
       
    }
}
