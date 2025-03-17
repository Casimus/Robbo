using UnityEngine;

public class Powerup : ScriptableObject
{
    public bool isActive;
    [SerializeField] protected PowerupStats duration;

    public float GetDuration() => duration.GetValue();
}
