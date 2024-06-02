using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course
{
    public class CannonBall : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Rigidbody rb;

        [Header("Physics Values")]
        [SerializeField] private float minAngularVelocity;
        [SerializeField] private float maxAngularVelocity;

        private void Start()
        {
            float randomAngularVelocity = Random.Range(minAngularVelocity, maxAngularVelocity);
            float rotationSpeed = Random.Range(50f, 75f);
            rb.angularVelocity = new Vector3(randomAngularVelocity, randomAngularVelocity, randomAngularVelocity) * rotationSpeed;
        }
    }
}
