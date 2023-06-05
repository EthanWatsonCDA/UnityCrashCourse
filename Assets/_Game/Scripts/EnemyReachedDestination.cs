using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReachedDestination : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject hudObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            PersistentManagerScript.instance.DecrementLives();
            PersistentManagerScript.instance.DecrementNumEnemies();

            //handle game over screen
            if (PersistentManagerScript.instance.lives <= 0)
            {
                gameOverScreen.SetActive(true);
                PauseMenu.PauseBase();
                PauseMenu.canPause = false;
                hudObject.SetActive(false);
            }
        }
    }
}
