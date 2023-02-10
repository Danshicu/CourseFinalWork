using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class WindowsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject openedWindow;
    [SerializeField] private GameObject closedWindow;
    [SerializeField] private int windowCountPerLevel = 5;
    [SerializeField] private int maxOpenedPerLevelCount = 3;
    //private List<GameObject> thisLevel;
    private List<float> positions = new List<float>();
    [SerializeField] private float spawnDelay;
    private Vector3 currentPosition = new Vector3();


    private void AddRandomWindow(Vector3 currentPos)
    {
        int randomIndex = Random.Range(0, 10);
        if (randomIndex < 8)
        {
            Instantiate(closedWindow, currentPos, Quaternion.identity);
        }
        else
        {
             Instantiate(openedWindow, currentPos, Quaternion.identity);
        }
    }

    private IEnumerator SpawnWindows()
    {
        while (this.gameObject.activeInHierarchy)
        {
            foreach (var position in positions)
            {
                currentPosition.x = position;
                AddRandomWindow(currentPosition);
            }

            currentPosition.y += closedWindow.transform.localScale.y;
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    void Start()
    {
        currentPosition.x = this.transform.position.x;
        currentPosition.y = this.transform.position.y;
        currentPosition.z = this.transform.position.z;
        float posX = this.transform.position.x - (windowCountPerLevel / 2 * closedWindow.transform.localScale.x);
        for (int i = 0; i < windowCountPerLevel; i++)
        {
            positions.Add(posX);
            posX += closedWindow.transform.localScale.x;
        }

        StartCoroutine(SpawnWindows());
    }

    
}
