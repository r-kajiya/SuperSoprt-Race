using System;
using System.Collections.Generic;
using Framework;
using UnityEngine;

namespace SuperSport
{
    [RequireComponent(typeof(Rigidbody))]
    public class RaceNPC : MonoBehaviour
    {
        Collider _collider;
        Rigidbody _rigidbody;
        Transform _transform;
        Renderer _renderer;
        
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
        Vector3 _startPos = Vector3.zero;

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
            DebugLog.Normal("Awake");
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
            _transform.localPosition = _startPos;
            _isUpdate = false;
            _updateFrame = 0;
        }

        public void StartRun()
        {
            _isUpdate = true;
            _updateFrame = 0;
        }

        public void StopRun()
        {
            _isUpdate = false;
            DebugLog.Normal($"{gameObject.name}の更新回数:{_updateFrame}, 記録:{_time}");
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