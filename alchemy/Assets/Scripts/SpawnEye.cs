using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEye : MonoBehaviour
{
    public GameObject[] eye;
    public List<Transform> spawnPoints;

    private Shake shake;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    public void ButtonPressed()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        SpawnNew();
    }

    void SpawnNew()
    {
        int i = 0;
        var spawn = Random.Range(0, spawnPoints.Count);
        Instantiate(eye[i], spawnPoints[spawn].transform.position, Quaternion.identity);

        AudioManager.instance.Play("Spawn");
        shake.CamShake();
    }
}
