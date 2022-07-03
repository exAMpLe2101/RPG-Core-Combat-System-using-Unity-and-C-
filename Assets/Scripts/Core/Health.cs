using RPG.Saving;
using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour, ISaveable
    {
        [SerializeField] float HP = 100f;
        bool isDead = false;

        public bool IsDead()
        {
            return isDead;
        }
        public void Damage(float dmg)
        {
            HP = Mathf.Max(HP - dmg, 0);
            if (HP == 0)
            {
                Death();
            }
        }

        private void Death()
        {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("Die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        public object CaptureState()
        {
            return HP;
        }

        public void RestoreState(object state)
        {
            HP = (float)state;
            if (HP == 0)
            {
                Death();
            }
        }
    }
}