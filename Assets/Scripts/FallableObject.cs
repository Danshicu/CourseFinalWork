using System.Collections;
using UnityEngine;

namespace Pramchuk
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public abstract class FallableObject : MonoBehaviour
    {
        [SerializeField] protected float lifeTime = 8f;
        protected Rigidbody _rigidbody;
        public Rigidbody rigidbody() => GetComponent<Rigidbody>();
        protected void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        protected IEnumerator Disable()
        {
            yield return new WaitForSeconds(lifeTime);
            this.gameObject.SetActive(false);
            _rigidbody.velocity = Vector3.zero;
        }
        protected void OnEnable()
        {
            StartCoroutine(Disable());
        }
    }
}