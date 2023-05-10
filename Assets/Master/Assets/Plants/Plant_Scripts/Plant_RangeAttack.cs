using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScottBarley.IGB100.V1
{
    public class Plant_RangeAttack : MonoBehaviour
    {
        [SerializeField] string _targetType_tag;
        [SerializeField] GameObject _projectilePrefab;
        [SerializeField] float _targetIsInRange_Distance = 20f;
        [SerializeField] bool _isLineOfSightRequiredToFire = false;
        [SerializeField] float _fireRate_waitBetweenShots = 1f;
        [SerializeField] Transform _point_ShootFromPoint_transform;

        [SerializeField] float _projectileSpread = 0.5f;
        [SerializeField] float _projectileLaunchForce = 20f;

        //private Transform transformOfPlayer;     
        private float timeToWaitTill;

        private void Start()
        {
            timeToWaitTill = 0;
        }


        // uses events, ask mark if this is cheaper or more expsnsive then using ??
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(_targetType_tag))
            {
                Transform trgtTrans = other.transform;

                if (Check_playerIsInRanger(trgtTrans))
                {
                    // if 'dosent require line of site', or 'line of sight not blocked by other object'
                    if (!_isLineOfSightRequiredToFire || Check_TargetIsInLineOfSight(trgtTrans))
                    {
                        if (timeToWaitTill <= Time.time)
                        {
                            FireWeapon(trgtTrans);
                            wait_betweenShot();
                        }
                    }
                }
            }
        }

        // --- Private Functions ---
        #region Private Functions
        private bool Check_playerIsInRanger(Transform targetTransform)
        {
            return (Vector3.Distance(this.transform.position, targetTransform.position) < _targetIsInRange_Distance) ? true : false;
        }

        private bool Check_TargetIsInLineOfSight(Transform targetTransform)
        {
            Vector3 direction = targetTransform.position - _point_ShootFromPoint_transform.position;
            float distance = direction.magnitude;
            Ray ray = new Ray(_point_ShootFromPoint_transform.position, direction);

            Debug.DrawRay(ray.origin, ray.direction * distance);

            RaycastHit[] objectsAlongRay = Physics.RaycastAll(ray.origin, ray.direction, distance);


            bool isSelf = false;
            bool isTarget = false;

            if (objectsAlongRay.Length > 0)
            {
                if (objectsAlongRay.Length > 2)
                    return false;

                
                foreach (var raycastHit in objectsAlongRay)
                {
                    // check if the ray is just picking up the _targetType_tag
                    if (raycastHit.transform.CompareTag(_targetType_tag) == true)
                        isTarget = true;

                    // check if the ray is just picking up the self
                    if (raycastHit.collider.gameObject == this.gameObject)
                        isSelf = true;
                }

                if (objectsAlongRay.Length < 2)
                {
                    if (isSelf == true || isTarget == true)
                        return true;
                }

                if (objectsAlongRay.Length == 2)
                {
                    if (isSelf == true && isTarget == true)
                        return true;
                }

                return false;
            }
            else
            {
                return true;
            }

        }

        private void FireWeapon(Transform targetTransform)
        {
            Vector3 direction = targetTransform.position - _point_ShootFromPoint_transform.position;
            //Calculate spread
            float x = Random.Range(-_projectileSpread, _projectileSpread);
            float y = Random.Range(-_projectileSpread, _projectileSpread);
            Vector3 directionWithSpread = direction + new Vector3(x, y, 0);

            GameObject projectile = Instantiate(_projectilePrefab, _point_ShootFromPoint_transform.position, Quaternion.identity);
            projectile.transform.forward = directionWithSpread.normalized;
            projectile.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * _projectileLaunchForce, ForceMode.Impulse);
        }

        private void wait_betweenShot()
        {
            timeToWaitTill = Time.time + _fireRate_waitBetweenShots;
        }

        #endregion
    }
}
