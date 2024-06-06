using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course
{
    public class SplitCannon : CannonBall
    {
        private static readonly int specialAvailableHash = Animator.StringToHash("SpecialAvailable");
        private static readonly int specialUsedHash = Animator.StringToHash("SpecialUsed");

        [Header("Override Values")]
        [SerializeField] private CannonBall cannonBallPrefab;
        [SerializeField] private float splitTime = .7f;
        [SerializeField] private float splitAngle = 20f;

        private void Start()
        {
            StartCoroutine(SplitBallCoroutine());
        }

        public override void SetUp(Vector3 _fireDir)
        {
            base.SetUp(_fireDir);

            anim.SetTrigger(specialAvailableHash);
        }

        protected override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);

            this.enabled = false;
        }

        private void SplitCannonBall()
        {
            var position = this.transform.position;
            var forward = rb.velocity;

            int splitAmount = 2;
            for (int i = 0; i < splitAmount; i++)
            {
                var ballForward = i % 2 == 0 ? Quaternion.AngleAxis(-splitAngle, Vector3.up) * forward : Quaternion.AngleAxis(splitAngle, Vector3.up) * forward;
                var splitBall = Instantiate(cannonBallPrefab, position, Quaternion.identity);
                splitBall.SetUp(ballForward);
            }

            anim.SetTrigger(specialUsedHash);
        }

        private IEnumerator SplitBallCoroutine()
        {
            yield return new WaitForSeconds(splitTime);
            SplitCannonBall();  
        }
    }
}

