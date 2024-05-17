using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "SO/Settings")]
public class AdvancedSett : ScriptableObject
{
    public int musicVolume = 100;
    public int sfxVolume = 100;

    public int startTimeInSeconds = 120;
    public int startTimeMinutes = 2;
    public int startTimeSeconds = 0;
}