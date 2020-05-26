using System;
using Framework;
using UnityEngine;

namespace SuperSport
{
    [RequireComponent(typeof(Rigidbody))]
    public class RacePlayer : RaceCharacter
    {
        Rigidbody _rigidbody;
        Transform _transform;

        [SerializeField]
        float _addForce = 100f;

        [SerializeField]
        EasyAnimation _easyAnimation;

        Vector3 _defaultPosition;

        bool _isRunning;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _easyAnimation.Initialize();
            _defaultPosition = transform.position;
        }

        public void Accelerator(float boost)
        {
            _rigidbody.AddForce(new Vector3(_addForce, 0f, 0f));
            
            if (!_isRunning)
            {
                _easyAnimation.CrossFade(1, 0, 1);
            }
            
            _isRunning = true;
        }

        void Update()
        {
            if (_isRunning)
            {
                if (_rigidbody.velocity.magnitude < 0.5)
                {
                    _easyAnimation.CrossFade(0, 0, 1);
                    _isRunning = false;
                    _easyAnimation.SetSpeed(1f);
                }
            }
            else
            {
                if (_rigidbody.velocity.magnitude < 0.5)
                {
                    _easyAnimation.SetSpeed(1);
                }
                else
                {
                    _easyAnimation.SetSpeed(_rigidbody.velocity.magnitude * 2f);
                }
            }
        }

        public void SetupStart()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _transform.position = _defaultPosition;
            Timer = 99.9f;
        }
    }
}