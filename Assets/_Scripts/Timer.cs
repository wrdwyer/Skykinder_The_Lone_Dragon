using UnityEngine;
using UnityEngine.UI;
using HutongGames.PlayMaker;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerData;// this needs to referance the scriptable object
    public float timer;
    [SerializeField]private bool isTimerRunning;
    [SerializeField]private float savedTime;
    [SerializeField]private float fastestTime;
    public FsmFloat timerFSM;
    [SerializeField]private FsmFloat fastestTimeFSM;
    public FsmFloat checkpointTime;
    [SerializeField]private float minutes;
    [SerializeField]private float seconds;
    [SerializeField]private float fastestMinutes;
    [SerializeField]private float fastestSeconds;
    public float timeToDisplay;
    public string timeText;


    private void Start()
    {
        isTimerRunning = true;
        fastestTime = float.MaxValue;
        timerFSM = FsmVariables.GlobalVariables.GetFsmFloat("LevelTimer");
        fastestTimeFSM = FsmVariables.GlobalVariables.GetFsmFloat("FastestLevel");
        checkpointTime = FsmVariables.GlobalVariables.GetFsmFloat("checkpointTime");
        fastestTime = fastestTimeFSM.Value;
    }

    private void Update()
    {
        if (isTimerRunning)
        {
             FsmFloat _timer = checkpointTime = FsmVariables.GlobalVariables.GetFsmFloat("checkpointTime");
              if (_timer.Value > 0)
                {
                    timer = _timer.Value;
                }
                else
                {
                    timer= 0f;
                    Debug.DebugBreak();
                    Debug.Log("Timer Set to "+_timer);
                }
        }
            isTimerRunning = false;
            timer += Time.deltaTime;
            timerData = Mathf.Round(timer * 100) /100f;
            timerFSM.Value = Mathf.Round(timer * 100) /100f;
            fastestTime = fastestTimeFSM.Value;
            minutes = Mathf.FloorToInt(timer /60);
            seconds = Mathf.FloorToInt(timer % 60);
        
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
                fastestMinutes = Mathf.FloorToInt(timer /60);
                fastestSeconds = Mathf.FloorToInt(timer % 60);
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
    public float GetCheckpointTime()
    {
        return checkpointTime.Value;
    }

    public float SetCheckpointTime()
    {
        checkpointTime.Value = timerFSM.Value;
        return checkpointTime.Value;
    }

    public void SetLevelTimer()
    {
        FsmFloat timer = FsmVariables.GlobalVariables.GetFsmFloat("checkpointTime");
        timerFSM.Value = timer.Value;
    }

    public void DisplayTime (float timeToDisplay)
    {
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
