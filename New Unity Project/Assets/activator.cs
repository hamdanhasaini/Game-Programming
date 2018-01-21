using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activator : MonoBehaviour {

    SpriteRenderer sr;
    public KeyCode Key;
    bool active = false;
    GameObject note,gm;
    Color old;
    public bool createMode;
    public GameObject n;
    public meter m;
    public float healthModVal = 10;
   

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        
        gm = GameObject.Find("GameManager");
        old = sr.color;
    }

    // Update is called once per frame
    void Update() {

      

        if (createMode)
        {

            if (Input.GetKeyDown(Key))
                Instantiate(n, transform.position, Quaternion.identity);

        }
        else
        {
            if (Input.GetKeyDown(Key))
                StartCoroutine(Pressed());

            if (Input.GetKeyDown(Key) && active)
            {

                Destroy(note);
                gm.GetComponent<gameManager>().addCombo();
                addScore();
                m.increaseHealth(healthModVal);
                active = false;
            }
            else if (Input.GetKeyDown(Key) && !active) {
                gm.GetComponent<gameManager>().resetCombo();
              m.decreaseHealth(healthModVal);
            }

        }


    }  

     void OnTriggerEnter2D(Collider2D coll)
    {

        
        if (coll.gameObject.tag == "winNote")
            gm.GetComponent<gameManager>().gameFinished();
        if (coll.gameObject.tag == "Note")
        {

            note = coll.gameObject;
               
            active = true;
        }



        
    }

  
   private void OnTriggerExit2D(Collider2D col)
    {
      
       
        active = false;
        
            

        // gm.GetComponent<gameManager>().resetCombo();

    }

    void addScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+gm.GetComponent<gameManager>().getScore());
       
    }


    IEnumerator Pressed()

    { Color old =  sr.color;
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;

    }

    
}
