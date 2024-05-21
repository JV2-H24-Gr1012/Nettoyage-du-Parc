using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "SO/Settings")]
public class Settings : ScriptableObject
{
    public int musicVolume;
    public int sfxVolume;

    public int startTimeInSeconds;
}