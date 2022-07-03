using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] float WeaponRange = 1f;

        [SerializeField] float WeaponDamage = 8f;

        [SerializeField] GameObject WeaponPrefab = null;
        // The following SerializeField is responsible for overriding the
        // default animator for changing attack animations (unarmed to weapon).
        [SerializeField] AnimatorOverrideController AnimationOverride = null;
        [SerializeField] bool isRightHanded = true;
        [SerializeField] Projectile projectile = null;

        public bool hasProjectile()
        {
            return projectile!=null;

        }

        public void LaunchProjectile(Transform LHand, Transform RHand, Health target) 
        {
            Projectile proj_instance = Instantiate(projectile, GetTransform(LHand, RHand).position, Quaternion.identity);
            proj_instance.SetTarget(target, WeaponDamage);
        }

        public void Spawn(Transform Lefthand, Transform Righthand, Animator animator)
        {
            Transform handtransform = GetTransform(Lefthand, Righthand);
            Instantiate(WeaponPrefab, handtransform);
            animator.runtimeAnimatorController = AnimationOverride;
        }

        private Transform GetTransform(Transform Lefthand, Transform Righthand)
        {
            Transform handtransform;
            if (isRightHanded) handtransform = Righthand;
            else handtransform = Lefthand;
            return handtransform;
        }

        public float GetRange()
        {
            return WeaponRange;
        }

        public float GetDamage()
        {
            return WeaponDamage;
        }
    }
}