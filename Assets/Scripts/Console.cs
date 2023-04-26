
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Console : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text gameOver;

    private void Start()
    {
        gameOver.enabled = false;
    }
    void Update()
    {
        if (playerHealth.CurrentHealth <= 0)
        {
           gameOver.enabled = true;
           Time.timeScale = 0;
        }
    
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene("CyberChop");
        }
    }

   
}