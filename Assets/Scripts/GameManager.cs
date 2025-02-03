using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float worldSpeed = 0.2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than one GameManager in the scene");
            Destroy(gameObject);
        }
    }

    public float GetWorldSpeed() => worldSpeed;
    
}
