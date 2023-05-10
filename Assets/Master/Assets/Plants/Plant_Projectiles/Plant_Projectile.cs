using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScottBarley.IGB100.V1
{
    public class Plant_Projectile : MonoBehaviour
    {
        [SerializeField] float _damage;
        [SerializeField] float _projectileLifeTime;

        private void Start()
        {
            Destroy(this, _projectileLifeTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.fn_IDamage(_damage);
                Destroy(this);
            }

        }

    }
}