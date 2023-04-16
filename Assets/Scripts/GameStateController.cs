using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public int level { get; private set; }
    public int experience { get; private set; }
    public Stopwatch survivalTimer;
    private GameObject ownShip;
    private double health;
    [SerializeField] private GameOverScreen gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        survivalTimer = new Stopwatch();
        survivalTimer.Start();
        level = 1;
        experience = 0;
        ownShip = GameObject.Find("OwnShip");
    }

    // Update is called once per frame
    void Update()
    {
        health = ownShip.GetComponent<PlayerShipBehaviour>().health;
        if (health <= 0 || survivalTimer.Elapsed.Minutes >= 20)
        {
            gameOverScreen.SetUp();
        }
    }

    public void AddExp()
    {
        experience++;
        if (experience >= level + level * 5)
        {
            level++;
            experience = 0;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        print($"Level up. New level = {level}");
    }
}
