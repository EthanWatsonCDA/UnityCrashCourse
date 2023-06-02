using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PersistentManagerScript : MonoBehaviour
{
    public static PersistentManagerScript instance { get; private set; }

    public int score = 0;
    public int lives = 10;

    public TMP_Text scoreObject;
    public TMP_Text livesObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        instance.score++;
        scoreObject.text = instance.score.ToString();
    }

    public void DecrementLives() 
    {
        instance.lives--;
        livesObject.text = instance.lives.ToString();
    }
}
