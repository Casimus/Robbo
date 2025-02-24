using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMoveController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectToMove;

    private GameObject currentStage;
    private GameObject nextStage;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = Vector3.zero;
        currentStage = Instantiate(objectToMove[0], startPosition, Quaternion.identity, transform);
        SetNextStage();

    }

    void Update()
    {

        currentStage.transform.Translate(Vector3.left * GameManager.Instance.GetWorldSpeed() * Time.deltaTime);
        nextStage.transform.Translate(Vector3.left * GameManager.Instance.GetWorldSpeed() * Time.deltaTime);

        if (currentStage.transform.position.x <= startPosition.x - 16)
        {
            var temp = currentStage;
            currentStage = nextStage;
            SetNextStage();
            Destroy(temp);
        }
    }
    private void SetNextStage()
    {
        int nextStageIndex = Random.Range(0, objectToMove.Length);
        nextStage =
            Instantiate(objectToMove[nextStageIndex], new Vector2(startPosition.x + 16, startPosition.y),
        Quaternion.identity, transform);
    }
}
