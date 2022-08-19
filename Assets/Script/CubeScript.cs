using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeScript : MonoBehaviour
{
    static int staticID = 0;
    [SerializeField] TextMeshPro[] text_MashPro;
    [HideInInspector] public Color CubeColor;
    [HideInInspector] public int CubeNumber;

    [HideInInspector] public int CubeID;
    [HideInInspector] public Rigidbody CubeRigidbdy;
    [HideInInspector] public bool IsMainCube;

    private MeshRenderer CubeMeshRender;


    void Awake()
    {
        CubeID = staticID++;
        CubeMeshRender = GetComponent<MeshRenderer>();
        CubeRigidbdy = GetComponent<Rigidbody>();

    }

    public void SetColor(Color color)
    {
        CubeColor = color;
        CubeMeshRender.material.color = color;
    }

    public void SetNumber(int num)
    {
        CubeNumber = num;
        for (int i = 0; i < 6; i++)
        {
            text_MashPro[i].text = num.ToString();
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
