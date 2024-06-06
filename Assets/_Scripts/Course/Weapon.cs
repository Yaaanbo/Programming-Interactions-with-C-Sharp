using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("Firing")]
        [SerializeField] protected float fireForce;
        [SerializeField] protected ForceMode firingForceMode;

        // Update is called once per frame
        void Update()
        {
            AimCannon();
            FireCannon();
        }

        protected abstract void FireCannon();
        protected abstract void AimCannon();
    }
}
