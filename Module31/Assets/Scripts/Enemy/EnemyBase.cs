using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enemy
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;

        public float startLife = 10f;

        public int damage = 5;

        public HealthBase healthBase;

        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startWithBornAnimation = true;


        [SerializeField] private float _currentLife;

        [Header("Animation Setups")]
        [SerializeField] private AnimationBase _animationBase;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            ResetLife();

            if (startWithBornAnimation)
            {
                BornAnimation();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Damage(damage);
            }
        }

        protected void ResetLife()
        {
            _currentLife = startLife;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                var health = collision.gameObject.GetComponent<HealthBase>();

                if (health != null)
                {
                    health.Damage(damage);
                }
            }
        }

        public void Damage(float damage)
        {
            OnDamage(damage);
        }

        public void OnDamage(float amount)
        {
            if (flashColor != null)
            {
                flashColor.Flash();
            }

            _currentLife -= amount;

            if (_currentLife <= 0)
            {
                if(particleSystem != null)
                {
                    particleSystem.Emit(15);
                }
                
                Kill();
            }

            healthBase.Damage(amount);
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            if(collider != null)
            {
                collider.enabled = false;
            }

            PlayAnimationByTrigger(AnimationType.DEATH);
            Destroy(gameObject, 2f);
        }

        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            _animationBase.PlayAnimationByTrigger(animationType);
        }

        #endregion


    }
}