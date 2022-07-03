using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;

/*
    Arrow Physics, look at the target and move there
*/

namespace RPG.Combat
{

    public class Projectile : MonoBehaviour
    {
        Health target = null;
        [SerializeField] float speed = 1f;
        float damage = 0;
        
        // Every time a frame is rendered, the following code will run.
        private void Update() {
            if(target==null)    return;

            transform.LookAt(GetAimLocation());
            transform.Translate(Vector3.forward * speed* Time.deltaTime); 
        }

        public void SetTarget(Health target,float damage)
        {
            this.target = target;
            this.damage = damage;
        }

        //  Stop shooting at my feet, the body is up here!
        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetcaspsule = target.GetComponent<CapsuleCollider>();
            if(targetcaspsule==null)    return target.transform.position;
            return (target.transform.position + Vector3.up * targetcaspsule.height/2);
            //  Vector3.up * targetcaspsule.height/2 = The offset for the Guts!

        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<Health>() != target)    return;
            target.Damage(damage);
            Destroy(gameObject);
        }

    }

}