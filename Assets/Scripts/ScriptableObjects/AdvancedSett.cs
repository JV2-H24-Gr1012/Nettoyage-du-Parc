using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "SO/Settings")]
public class AdvancedSett : ScriptableObject
{
    public int musicVolume;
    public int sfxVolume;

    public int startTimeInSeconds;
    public int startTimeMinutes;
    public int startTimeSeconds;
}