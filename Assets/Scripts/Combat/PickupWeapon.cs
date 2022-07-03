using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Weapon is on the Ground, pick it up 
    and equip it.
*/

namespace RPG.Combat
{
    public class PickupWeapon : MonoBehaviour
    {
        [SerializeField] Weapon weapon;
        GameObject player;

        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.tag=="Player")
                other.GetComponent<PlayerCombat>().EquipWeapon(weapon);
            Destroy(gameObject);    
        }
    }

}