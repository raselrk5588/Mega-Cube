using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZoon : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        CubeScript cube = GetComponent<CubeScript>();
        if (cube != null)
        {
            if (!cube.IsMainCube && cube.CubeRigidbdy.velocity.magnitude < 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
