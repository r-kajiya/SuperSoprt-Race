using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperSport
{
    public class RacePlayerQWOP : MonoBehaviour
    {
        [SerializeField]
        Rigidbody _leftUpper;
        
        [SerializeField]
        Rigidbody _rightUpper;
        
        [SerializeField]
        Rigidbody _leftLower;
        
        [SerializeField]
        Rigidbody _rightLower;
    
        [SerializeField, Range(1, 100)]
        float _power;
        
        [SerializeField, Range(0.01f, 1f)]
        float _drag;
    
        [SerializeField]
        RacePlayerQWOPHead _head;

        struct Parameter
        {
            public Vector3 localPos;
            public Quaternion localRot;
            public Rigidbody rigidbody;
        }
        
        List<Parameter> _parameters = new List<Parameter>();
        
        [SerializeField]
        Transform _hipTransform;

        float _length;
        bool _isTouch;

        void Start()
        {
            foreach (var rigidbody in transform.GetComponentsInChildren<Rigidbody>())
            {
                var param = new Parameter();
                param.localPos = rigidbody.transform.localPosition;
                param.localRot = rigidbody.transform.localRotation;
                param.rigidbody = rigidbody;
                
                rigidbody.drag = _drag;
                rigidbody.isKinematic = true;
                
                _parameters.Add(param);
            }
        }
        
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                _leftUpper.AddForce(-_leftUpper.transform.forward * _power, ForceMode.VelocityChange);
            }
            
            if (Input.GetKeyUp(KeyCode.P))
            {
                _rightUpper.AddForce(_rightUpper.transform.up * _power, ForceMode.VelocityChange);
            }
            
            if (Input.GetKeyUp(KeyCode.W))
            {
                _leftLower.AddForce(-_leftLower.transform.forward * _power, ForceMode.VelocityChange);
            }
            
            if (Input.GetKeyUp(KeyCode.O))
            {
                _rightLower.AddForce(-_rightLower.transform.up * _power, ForceMode.VelocityChange);
            }

            if (_isTouch)
            {
                return;
            }

            _length = _hipTransform.position.x;
        }
    
        public void OnLeftUpper()
        {
            _leftUpper.AddForce(-_leftUpper.transform.forward * _power, ForceMode.VelocityChange);
        }
        
        public void OnRightUpper()
        {
            _rightUpper.AddForce(_rightUpper.transform.up * _power, ForceMode.VelocityChange);
        }
        
        public void OnLeftLower()
        {
            _leftLower.AddForce(-_leftLower.transform.forward * _power, ForceMode.VelocityChange);
        }
        
        public void OnRightLower()
        {
            _rightLower.AddForce(-_rightLower.transform.up * _power, ForceMode.VelocityChange);   
        }
    
        public void Setup(Action<bool> onTouchHead)
        {
            _isTouch = false;
            _head.Setup((isTouch)=>
            {
                _isTouch = true;
                onTouchHead?.Invoke(isTouch);
            });

            foreach (var param in _parameters)
            {
                param.rigidbody.isKinematic = true;
                param.rigidbody.transform.localPosition = param.localPos;
                param.rigidbody.transform.localRotation = param.localRot;
            }
        }
        
        public void Go()
        {
            foreach (var param in _parameters)
            {
                param.rigidbody.isKinematic = false;
            }
        }

        public float Length()
        {
            return _length;
        }
    }
}

