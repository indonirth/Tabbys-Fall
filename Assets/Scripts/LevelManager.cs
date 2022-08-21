using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerController>().transform.position;

    }


    public void Restart()
    {
        FindObjectOfType<PlayerController>().transform.position = playerInitPosition;
    }

}
