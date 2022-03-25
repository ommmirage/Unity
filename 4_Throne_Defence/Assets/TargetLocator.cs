using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform weapon;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
        weapon = transform.Find("BallistaTopMesh");
    }

    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
