using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course
{
    public class CannonBall : MonoBehaviour
    {
        private static readonly int explodeParameter = Animator.StringToHash("Exploded");

        [Header("Components")]
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Animator anim;

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

            //Destroy(this.gameObject, lifeTime);
        }

        public void OnAnimationFinished()
        {
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            this.rb.angularVelocity = Vector3.zero;
            this.rb.velocity = Vector3.zero;
            this.rb.isKinematic = true;
            this.rb.detectCollisions = false;

            anim.SetTrigger(explodeParameter);
        }
    }
}
