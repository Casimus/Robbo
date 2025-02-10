using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMoveController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectToMove;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = objectToMove[0].transform.position;
    }

    void Update()
    {
        foreach (var item in objectToMove)
        {
            //item.transform.position += Vector3.left * GameManager.Instance.GetWorldSpeed() * Time.deltaTime;

            item.transform.Translate(Vector3.left * GameManager.Instance.GetWorldSpeed() * Time.deltaTime);

            if (item.transform.position.x <= startPosition.x - 16)
            {
                item.transform.position = startPosition 
                    + new Vector2((objectToMove.Length - 1) * 16, 0);
            }

        }
    }
}
