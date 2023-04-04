using UnityEngine;

[CreateAssetMenu(fileName = "GameProgressData", menuName = "ScriptableObjects/GameProgressData", order = 1)]
public class GameProgressData : ScriptableObject
{
    public string CurrentCheckpoint;
    public int totalScore;
    public int timesSpotted;
    public float timeLevelCompleted;
    public float fastestLevel;
    public int dragonsFreed;
    public int secretsFound;
    public int dragonScalesCollected;
    // Add more fields as needed, depending on what game progress data you want to store.
}

