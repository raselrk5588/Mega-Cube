using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    CubeScript cube;
    // Start is called before the first frame update

    private void Awake()
    {
        cube = GetComponent<CubeScript>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        CubeScript otherCube = collisionInfo.gameObject.GetComponent<CubeScript>();

        if (otherCube != null && cube.CubeID > otherCube.CubeID)
        {
            if (cube.CubeNumber == otherCube.CubeNumber)
            {
                Vector3 contractPoint = collisionInfo.contacts[0].point;
                if (otherCube.CubeNumber < CubeSpnawer.instance.maxCubeNumber)
                {
                    CubeScript newCube = CubeSpnawer.instance.Spawn(cube.CubeNumber * 2, contractPoint + Vector3.up * 1.6f);

                    float pushForch = 2.5f;
                    newCube.CubeRigidbdy.AddForce(new Vector3(0, 0.3f, 1f) * pushForch, ForceMode.Impulse);

                    float randomValue = Random.Range(-20f, 20f);
                    Vector3 randomDriction = Vector3.one * randomValue;
                    newCube.CubeRigidbdy.AddTorque(randomDriction);
                }

                Collider[] surrounderCube = Physics.OverlapSphere(contractPoint, 2f);
                float explosionForce = 400f;
                float explosionRadious = 1.5f;
                foreach (Collider coll in surrounderCube)
                {
                    if (coll.attachedRigidbody != null)
                    {
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contractPoint, explosionRadious);
                    }

                }
                FX.instance.PlayExplosionFX(contractPoint, cube.CubeColor);
                CubeSpnawer.instance.DestroyCube(cube);
                CubeSpnawer.instance.DestroyCube(otherCube);
            }
        }
    }
}
