using UnityEngine;
using HutongGames.PlayMaker;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerData;// this needs to referance the scriptable object
    [SerializeField]private float timer;
    [SerializeField]private bool isTimerRunning;
    [SerializeField]private float savedTime;
    [SerializeField]private float fastestTime;
    [SerializeField]private FsmFloat timerFSM;
    [SerializeField]private FsmFloat fastestTimeFSM;

    private void Start()
    {
        timer = 0f;
        isTimerRunning = true;
        fastestTime = float.MaxValue;
        timerFSM = FsmVariables.GlobalVariables.GetFsmFloat("LevelTimer");
        fastestTimeFSM = FsmVariables.GlobalVariables.GetFsmFloat("FastestLevel");
        fastestTime = fastestTimeFSM.Value;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            timerData = Mathf.Round(timer * 100) /100f;
            timerFSM.Value = Mathf.Round(timer * 100) /100f;
            fastestTime = fastestTimeFSM.Value;
        }
    }

    public void StopTimer()
    {
        if (isTimerRunning)
        {
            savedTime = timer;
            isTimerRunning = false;

            if (savedTime < fastestTime)
            {
                fastestTime = Mathf.Round(savedTime * 100) /100f;
                fastestTimeFSM.Value = fastestTime;
            }
        }
    }

    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            timer = 0f;
            isTimerRunning = true;
        }
    }

    public float GetFastestTime()
    {
        return fastestTime;
    }
}
