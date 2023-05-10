using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScottBarley.IGB100.V1
{
    public class Plant_Projectile : MonoBehaviour
    {
        [SerializeField] float _damage;
        [SerializeField] float _projectileLifeTime;
        private float _lifeTimeLeft;

        private void Start()
        {
            _lifeTimeLeft = _projectileLifeTime;
        }
        private void Update()
        {
            _lifeTimeLeft -= Time.deltaTime;
            if (_lifeTimeLeft <= 0)
                DestroyThisProjectile();

        }

        private void OnCollisionEnter(Collision collision)
        {
            IDamageable damageable = collision.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.fn_IDamage(_damage);            
            }
            DestroyThisProjectile();
        }

        private void DestroyThisProjectile()
        {
            Destroy(this.gameObject);
        }

    }
}