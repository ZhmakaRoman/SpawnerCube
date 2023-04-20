using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var newCube = Instantiate(_cubePrefab);
            _cubePrefab.transform.position = new Vector3(Random.Range(-15, 15), 30, 10);
        }
    }
}
