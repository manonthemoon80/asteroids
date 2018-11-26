using System;
using UnityEngine;
using asteroids;


public class UIManager : MonoBehaviour
{
    public void Reload()
    {

        Application.LoadLevel(Application.loadedLevel);

    }
    

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    
     // Has the game been paused?
     private bool isPaused;
     // Has the game gone through it's pause transition?
     private bool hasPaused = false;
     
     public void Start()
     {
         // Default to not paused.
         this.isPaused = false;
     }
     
     public void OnGUI()
     {    
         // If you're paused
         if(this.isPaused) {
             // And nothing has initialized
             if(!this.hasPaused) {
                 // Pause the game
                 this.pauseGame();
                 this.hasPaused = true;
             }
             // GUI changes.
         } else {
             if(this.hasPaused) {
                 this.resumeGame();
                 this.hasPaused = false;
             }
         }
         
         // If you click the button,
         //if(GUI.Button(new Rect(100,100,100,100), "PAUSE")) {
         //    // Toggle the games pause state.
         //    this.changePauseState();
         //}
         
     }
     
     public void pauseGame()
     {
         // Pause the game
         Time.timeScale = 0;
         // Any other logic
     }
     
     public void resumeGame()
     {
         // Resume the game
         Time.timeScale = 1;
         // Any other logic
     }
     
     public void changePauseState()
     {
         // Alternate bool value per button click
         this.isPaused = !this.isPaused;
     }
}

