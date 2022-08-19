using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float pushForce;
    [SerializeField] private float MaxPosX;
    [Space]
    [SerializeField] private SliderHandelar sliderHandelar;
    private CubeScript mainCube;
    private bool isPointerDown;
    private Vector3 cubePosition;


    void Start()
    {
        SpawanCube();
        sliderHandelar.OnPointerDownEvent += OnPointerDown;
        sliderHandelar.OnPointerDragEvent += OnPointerDrag;
        sliderHandelar.OnPointerUpEvent += OnPointerUp;
    }
    void Update()
    {
        if (isPointerDown)
        {
            mainCube.transform.position = Vector3.Lerp
            (
                 mainCube.transform.position,
                 cubePosition,
                 MoveSpeed * Time.deltaTime
            );
        }
    }

    void OnPointerDown()
    {
        isPointerDown = true;
    }
    void OnPointerDrag(float xMovement)
    {
        if (isPointerDown)
        {
            cubePosition = mainCube.transform.position;
            cubePosition.x = xMovement * MaxPosX;
        }
    }
    void OnPointerUp()
    {
        if (isPointerDown)
        {
            isPointerDown = false;
            mainCube.CubeRigidbdy.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
            Invoke("SapwanNewCube", 0.3f);
        }


    }
    void SapwanNewCube()
    {
        mainCube.IsMainCube = false;
        SpawanCube();
    }

    public void SpawanCube()
    {
        mainCube = CubeSpnawer.instance.SpawnRandom();
        mainCube.IsMainCube = true;
        cubePosition = mainCube.transform.position;
    }
    void OnDestroy()
    {
        sliderHandelar.OnPointerDownEvent -= OnPointerDown;
        sliderHandelar.OnPointerDragEvent -= OnPointerDrag;
        sliderHandelar.OnPointerUpEvent -= OnPointerUp;
    }
}
