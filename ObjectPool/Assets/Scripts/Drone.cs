using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
namespace Chapter.ObjectPool
{
    public class Drone : MonoBehaviour
    {
        public IObjectPool<Drone> Pool { get; set; }
        public float _currentHealth;
        public float maxHealth = 100f;
        private float timeToSelfDestruct = 3f;
        // Start is called before the first frame update
        void Start()
        {
            _currentHealth = maxHealth;
        }
        private void OnEnable()
        {
            AttackPlayer();
            StartCoroutine(SelfDestruct());
        }
        private void OnDisable()
        {
            ResetDrone();
        }
        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(timeToSelfDestruct);
            TakeDamage(maxHealth);
        }
        private void ReturnToPool()
        {
            Pool.Release(this);
        }
        private void ResetDrone()
        {
            _currentHealth = maxHealth;
        }
        public void AttackPlayer()
        {
            Debug.Log("Attack Player!");
        }
        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0f)
            {
                ReturnToPool();
            }
        }
    }
}
