using UnityEngine;
using HutongGames.PlayMaker;

public class ProgressManager : MonoBehaviour
{
    public GameProgressData gameProgressData;
    public Timer _timer;
    [SerializeField] private FsmString CurrentCheckpoint;
    [SerializeField] private FsmFloat checkpointTime;
    [SerializeField] private FsmFloat fastestTimeFSM;


    private void Awake()
    {
        //LoadGameProgress();
    }
    private void Start() 
    {
        CurrentCheckpoint = FsmVariables.GlobalVariables.GetFsmString("Current Checkpoint");
        checkpointTime = FsmVariables.GlobalVariables.GetFsmFloat("checkpointTime");
        fastestTimeFSM = FsmVariables.GlobalVariables.GetFsmFloat("FastestLevel");
    }
    public void SaveGameProgress()
    {
        checkpointTime.Value =  _timer.GetCheckpointTime();
        gameProgressData.CurrentCheckpoint = CurrentCheckpoint.Value;
        gameProgressData.fastestLevel = fastestTimeFSM.Value;
        gameProgressData.checkPointTime = checkpointTime.Value;
        PlayerPrefs.SetString("Current Checkpoint", gameProgressData.CurrentCheckpoint);
        PlayerPrefs.SetFloat("FastestLevel", gameProgressData.fastestLevel);
        PlayerPrefs.SetFloat("checkpointTime", gameProgressData.checkPointTime);
        PlayerPrefs.Save();
    }

    public void LoadGameProgress()
    {
        gameProgressData.CurrentCheckpoint = PlayerPrefs.GetString("Current Checkpoint", "Start");
        gameProgressData.fastestLevel = PlayerPrefs.GetFloat("FastestLevel", 0);
        gameProgressData.checkPointTime = PlayerPrefs.GetFloat("checkpointTime", 0);
        CurrentCheckpoint.Value = gameProgressData.CurrentCheckpoint;
        checkpointTime.Value = gameProgressData.checkPointTime;
        fastestTimeFSM.Value = gameProgressData.fastestLevel;
    }
}

