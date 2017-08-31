using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    internal static int score = 0;

    private float stopwatch;
    private float framesCount = 0;
    private Stopwatch globalStopwatch;

    // Use this for initialization
    void Start () {
        globalStopwatch = new Stopwatch();
    }
	
	// Update is called once per frame
	void Update () {

        //FrameCounter();

    }

    private void FrameCounter()
    {
        if (!globalStopwatch.IsRunning)
        {
            globalStopwatch.Start();
        }

        framesCount++;

        if (globalStopwatch.ElapsedMilliseconds > 990)
        {
            print("Fps:" + framesCount);
            globalStopwatch.Reset();
            framesCount = 0;
        }

        stopwatch += Time.deltaTime;
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }

    public static void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public static void addScore()
    {
        score += 10;
    }
}
