using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meter : MonoBehaviour {
    public float startingHealth;
    public Transform needle;
    public float minX = -1.27f, maxX = 2.06f;

    private float health;
    private float y;
    private gameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<gameManager>();
        health = startingHealth;
        y = needle.localPosition.y;
        needle.localPosition = setNeedlePos(health);
    }
	
	// Update is called once per frame
	void Update () {

    }

    Vector3 setNeedlePos(float value)
    {
        float length = maxX - minX;
        float percentage = value / 100 * length;
        float x = percentage + minX;
        Debug.Log(length + " " + percentage + " " + x);
        return new Vector3(x, y);
    }

    public void increaseHealth(float value)
    {
        health += value;
        if (health > 100)
        {
            health = 100;
        }
        needle.localPosition = setNeedlePos(health);
    }
    public void decreaseHealth(float value)
    {
        health -= value;
        if (health < 0)
        {
            health = 0;
            gm.Lose();
        }
        needle.localPosition = setNeedlePos(health);
    }
}
