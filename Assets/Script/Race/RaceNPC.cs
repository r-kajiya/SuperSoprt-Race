using System;
using System.Collections.Generic;
using Framework;
using UnityEngine;

namespace SuperSport
{
    [RequireComponent(typeof(Rigidbody))]
    public class RaceNPC : RaceCharacter
    {
        Collider _collider;
        Rigidbody _rigidbody;
        Transform _transform;
        Renderer _renderer;
        Vector3 _defaultPosition;
        
        [Serializable]
        public class Boost
        {
            [SerializeField]
            public float value;
            [SerializeField]
            public int timing;
        }

        [SerializeField]
        float _addForce = 10f;

        [SerializeField]
        List<Boost> _boosts = new List<Boost>();
        
        [SerializeField]
        EasyAnimation _easyAnimation;

        bool _isUpdate;
        int _updateFrame;
        float _time;
        float _randomAccelerator;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = GetComponent<Transform>();
            _renderer = GetComponent<Renderer>();
            _collider = GetComponent<Collider>();
            _isUpdate = false;
            _time = 0;
            _randomAccelerator = UnityEngine.Random.Range(0, 1);
            _defaultPosition = _transform.position;
            _easyAnimation.Initialize();
        }

        void Update()
        {
            if (_isUpdate)
            {
                Boost boost = _boosts.Find(x => x.timing == _updateFrame);
                if (boost != null)
                {
                    Accelerator(boost.value);
                }
                else
                {
                    Accelerator(1f);
                }

                _updateFrame++;
                _time += Time.deltaTime;
                
                _easyAnimation.SetSpeed(_rigidbody.velocity.magnitude);
            }
        }

        void Accelerator(float boost)
        {
            _rigidbody.AddForce(new Vector3((_addForce + _randomAccelerator) * boost, 0f, 0f));
        }

        public void SetupStart()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _transform.position = _defaultPosition;
            _isUpdate = false;
            _updateFrame = 0;
            Timer = 99.9f;
        }

        public void StartRun()
        {
            _isUpdate = true;
            _updateFrame = 0;
            _easyAnimation.CrossFade(1, 0, 0.5f);
        }

        public void StopRun()
        {
            _isUpdate = false;
            DebugLog.Normal($"{gameObject.name}の更新回数:{_updateFrame}, 記録:{_time}");
            _easyAnimation.CrossFade(0, 0, 2);
            _easyAnimation.SetSpeed(1);
        }

        public void Disable()
        {
            _renderer.enabled = false;
            _collider.enabled = false;
        }
        
        public void Enable()
        {
            _renderer.enabled = true;
            _collider.enabled = true;
        }
    }
}