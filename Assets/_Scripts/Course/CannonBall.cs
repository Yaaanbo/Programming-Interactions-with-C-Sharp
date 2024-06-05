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

        [Header("Firing")]
        [SerializeField] private float fireForce;
        [SerializeField] private ForceMode firingForceMode;

        [Header("Explosion")]
        [SerializeField] private float explosionRadius;
        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionUpwardModifier;
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private ForceMode explosionForceMode;

        [Header("Others")]
        [SerializeField] private float lifeTime;

        public void SetUp(Vector3 _fireDir)
        {
            this.rb.AddForce(_fireDir * fireForce, firingForceMode);

            float randomAngularVelocity = Random.Range(minAngularVelocity, maxAngularVelocity);
            float rotationSpeed = Random.Range(50f, 75f);
            this.rb.angularVelocity = new Vector3(randomAngularVelocity, randomAngularVelocity, randomAngularVelocity) * rotationSpeed;

            //Destroy(this.gameObject, lifeTime);
        }

        public void OnAnimationFinished()
        {
            Destroy(this.gameObject);
        }

        private void AddExplosionForce()
        {
            Vector3 explosionPos = this.transform.position;
            Collider[] colls = Physics.OverlapSphere(explosionPos, explosionForce, targetLayer);

            foreach(Collider coll in colls)
            {
                if(coll.TryGetComponent(out Rigidbody _rb))
                {
                    _rb.AddExplosionForce(explosionForce, explosionPos, explosionRadius, explosionUpwardModifier, explosionForceMode);
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            this.rb.angularVelocity = Vector3.zero;
            this.rb.velocity = Vector3.zero;
            this.rb.isKinematic = true;
            this.rb.detectCollisions = false;

            this.anim.SetTrigger(explodeParameter);

            AddExplosionForce();
        }

        private void OnTriggerEnter(Collider other)
        {
            Destroy(this.gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(this.transform.position, explosionRadius);
        }
    }
}
