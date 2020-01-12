using System;
using UnityEngine;

namespace SuperSport
{
    [RequireComponent(typeof(Rigidbody))]
    public class RacePlayer : MonoBehaviour
    {
        Rigidbody _rigidbody;
        Transform _transform;

        [SerializeField]
        float _addForce = 100f;

        [SerializeField]
        Vector3 _startPos = Vector3.zero;
        
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
        }

        public void Accelerator(float boost)
        {
            _rigidbody.AddForce(new Vector3(_addForce, 0f, 0f));
        }

        public void SetupStart()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _transform.localPosition = _startPos;
        }
    }
}