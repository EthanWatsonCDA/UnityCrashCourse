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

    GameObject[] allEnemies;
    public int numEnemies;
    public TMP_Text numEnemiesDisplay;

    public GameObject winScreen;
    public GameObject hudObject;

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
        //count number of enemies
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        numEnemies = allEnemies.Length;
        numEnemiesDisplay.text = numEnemies.ToString();
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

    public void DecrementNumEnemies()
    {
        numEnemies--;
        numEnemiesDisplay.text = numEnemies.ToString();
        if (numEnemies <= 0)
        {
            winScreen.SetActive(true);
            PauseMenu.PauseBase();
            hudObject.SetActive(false);
        }
    }
}
