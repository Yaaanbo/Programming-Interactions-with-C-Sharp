using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course
{
    public class CannonBall : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody rb;

        [Header("Angular velocity")]
        [SerializeField] private float minAngularVelocity;
        [SerializeField] private float maxAngularVelocity;

        [Header("Forces")]
        [SerializeField] private float fireForce;
        [SerializeField] private ForceMode forceMode;

        [Header("Others")]
        [SerializeField] private float lifeTime;

        public void SetUp(Vector3 _fireDir)
        {
            this.rb.AddForce(_fireDir * fireForce, forceMode);

            float randomAngularVelocity = Random.Range(minAngularVelocity, maxAngularVelocity);
            float rotationSpeed = Random.Range(50f, 75f);
            this.rb.angularVelocity = new Vector3(randomAngularVelocity, randomAngularVelocity, randomAngularVelocity) * rotationSpeed;

            Destroy(this.gameObject, lifeTime);
        }
    }
}
