using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Course
{
    public class CannonController : Weapon
    {
        [Header("Transforms")]
        [SerializeField] private Transform baseBody;

        [Header("Rotations")]
        [SerializeField] private float minXRotation;
        [SerializeField] private float maxXRotation;
        [SerializeField] private float minYRotation;
        [SerializeField] private float maxYRotation;
        private float yDegree, xDegree;

        [Header("Properties")]
        [SerializeField] private float rotSpeed;

        [Header("Firing Cannon")]
        [SerializeField] private Transform shootingPoint;
        [SerializeField] private CannonBall cannonBallPrefab;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        protected override void AimCannon()
        {
            float yRot = Input.GetAxis("Mouse X");
            float xRot = Input.GetAxis("Mouse Y");

            xDegree += xRot * -rotSpeed * Time.deltaTime;
            yDegree += yRot * rotSpeed * Time.deltaTime;

            xDegree = Mathf.Clamp(xDegree, minXRotation, maxXRotation);
            yDegree = Mathf.Clamp(yDegree, minYRotation, maxYRotation);

            baseBody.localEulerAngles = new Vector3(xDegree, yDegree);
        }

        protected override void FireCannon()
        {
            if (Input.GetMouseButtonDown(0))
            {
                CannonBall newCannonBall = Instantiate(cannonBallPrefab, shootingPoint.position, Quaternion.identity);
                newCannonBall.SetUp(this.transform.forward * fireForce);
            }
        }
    }
}
