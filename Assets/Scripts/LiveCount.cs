using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LiveCount : MonoBehaviour
{
    public Image[] lives;

    public int livesRemaining;

    public void LoseLife()
    {
        //Decrease the value of livesRemaining
        if (livesRemaining == 0)
            return;
     
            
        livesRemaining--;
        lives[livesRemaining].enabled = false;


        if(livesRemaining ==0)
        {
            Debug.Log("YOU LOST");
            FindObjectOfType<LevelManager>().Restart();
            Application.LoadLevel("TABBYS_FALL_CAVE");
        }
    }
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoseLife();

    }

}
