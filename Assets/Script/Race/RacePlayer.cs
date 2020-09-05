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
        EasyAnimation _easyAnimation = null;

        Vector3 _defaultPosition;

        bool _isRunning;

        float _acceleration;
        float _fastest;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _easyAnimation.Initialize();
            _defaultPosition = transform.position;
        }

        public void Accelerator(float boost)
        {
            if (_rigidbody.velocity.magnitude > _fastest)
            {
                return;
            }
            
            _rigidbody.AddForce(new Vector3((_addForce + _acceleration) * boost, 0f, 0f));
            
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
                    _easyAnimation.SetSpeed(_rigidbody.velocity.magnitude * 3f);
                }
            }
        }

        public void SetupStart(int acceleration, int fastest)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _transform.position = _defaultPosition;
            Timer = 99.9f;
            _acceleration = (float)acceleration / 200;
            _fastest = fastest + 40;
        }
    }
}