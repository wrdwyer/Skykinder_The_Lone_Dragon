using UnityEngine;
using HutongGames.PlayMaker;


public class ProgressManager : MonoBehaviour
{
    public GameProgressData gameProgressData;
    [SerializeField] private FsmString CurrentCheckpoint;
    [SerializeField] private FsmFloat fastestTimeFSM;

    private void Awake()
    {
        //LoadGameProgress();
    }

    private void Start() 
    {
        CurrentCheckpoint = FsmVariables.GlobalVariables.GetFsmString("Current Checkpoint");
        fastestTimeFSM = FsmVariables.GlobalVariables.GetFsmFloat("FastestLevel");
    }

    public void SaveGameProgress()
    {
        gameProgressData.CurrentCheckpoint = CurrentCheckpoint.Value;
        gameProgressData.fastestLevel = fastestTimeFSM.Value;
        PlayerPrefs.SetString("Current Checkpoint", gameProgressData.CurrentCheckpoint);
        PlayerPrefs.SetInt("TotalScore", gameProgressData.totalScore);
        PlayerPrefs.SetFloat("FastestLevel", gameProgressData.fastestLevel);
        // Save any additional data as needed.
        PlayerPrefs.Save();
    }

    public void LoadGameProgress()
    {
        gameProgressData.CurrentCheckpoint = PlayerPrefs.GetString("Current Checkpoint", "Start");
        gameProgressData.totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        gameProgressData.fastestLevel = PlayerPrefs.GetFloat("FastestLevel", 0);
        CurrentCheckpoint.Value = gameProgressData.CurrentCheckpoint;
        fastestTimeFSM.Value = gameProgressData.fastestLevel;
        // Load any additional data as needed.
    }
}

