using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAndDeathTollManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DeathTollIncrementer();
    }

    public void DeathTollIncrementer()
    {
        if (FindObjectOfType<PlayerHealth>().IsDead == true)
        {
            FindObjectOfType<Player>().DeathToll += 1;
        }
    }
}
