using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpnawer : MonoBehaviour
{
    public static CubeSpnawer instance;
    Queue<CubeScript> CubeQueue = new Queue<CubeScript>();
    [SerializeField] private int CubeQueueCapaCity = 20;
    [SerializeField] bool AutoQueueGenerat = true;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Color[] cubeColor;

    [HideInInspector] public int maxCubeNumber;
    private int maxPower = 12;
    private Vector3 defaultCubePosition;

    void Awake()
    {
        instance = this;
        defaultCubePosition = transform.position;
        maxCubeNumber = (int)Mathf.Pow(2, maxPower);
        InitilazitionCube();
    }
    void InitilazitionCube()
    {
        for (int i = 0; i < CubeQueueCapaCity; i++)
        {
            AddCubeToQueue();
        }
    }
    void AddCubeToQueue()
    {
        CubeScript cube = Instantiate(cubePrefab, defaultCubePosition, Quaternion.identity, transform).GetComponent<CubeScript>();
        cube.gameObject.SetActive(false);
        cube.IsMainCube = false;
        CubeQueue.Enqueue(cube);
    }

    public CubeScript Spawn(int number, Vector3 postion)
    {
        if (CubeQueue.Count == 0)
        {
            if (AutoQueueGenerat)
            {
                CubeQueueCapaCity++;
                AddCubeToQueue();
            }
            else
            {
                Debug.LogError("All cube Finish");
                return null;
            }
        }
        CubeScript cube = CubeQueue.Dequeue();
        cube.transform.position = postion;
        cube.SetNumber(number);
        cube.SetColor(GetColor(number));
        cube.gameObject.SetActive(true);
        return cube;
    }

    public CubeScript SpawnRandom()
    {
        return Spawn(GeneratRandomNumber(), defaultCubePosition);
    }

    public void DestroyCube(CubeScript cube)
    {
        cube.CubeRigidbdy.velocity = Vector3.zero;
        cube.CubeRigidbdy.angularVelocity = Vector3.zero;
        cube.transform.rotation = Quaternion.identity;
        cube.IsMainCube = false;
        cube.gameObject.SetActive(false);
        CubeQueue.Enqueue(cube);

    }

    public int GeneratRandomNumber()
    {
        return (int)Mathf.Pow(2, Random.Range(1, 6));
    }
    private Color GetColor(int number)
    {
        return cubeColor[(int)(Mathf.Log(number) / Mathf.Log(2)) - 1];
    }

}
