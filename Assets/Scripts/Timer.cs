using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 30f; 
    public TMP_Text timerText; 
    private bool timerActive = false; 
   

    void Start()
    {
        UpdateTimerText();
        Debug.Log("start is called");

    }

    void Update()
    {
        
        if (timerActive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {

                Debug.Log("Time's up!");
                timer = 30f; 
                timerActive = false; 
                UpdateTimerText(); 
                
               
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collidedObject = other.gameObject;


        if (collidedObject.CompareTag("Player"))
        {
            timerActive = true; 
            Debug.Log("Player entered enemy zone, timer started.");
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
}