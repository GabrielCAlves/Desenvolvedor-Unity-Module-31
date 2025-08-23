using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;

    public bool destroyOnKill = false;
    public float delayToKill = 2f;

    //public Player playerScript;
    public string death = "DeathTrigger";
    private Animator animator;
    public Rigidbody rigidbody;

    //public AudioSource audioSource;

    //public EndGame endGame;

    public float _currentLife;
    private bool _isDead = false;

    //[SerializeField] private FlashColor flashColor;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;

        animator = gameObject.GetComponentInChildren<Animator>();

        if(animator != null)
        {
            Debug.Log("Animator encontrado!!!");
            Debug.Log("Nome do gameObject: "+gameObject.name);
        }
        else
        {
            Debug.Log("Infelizmente o animator não foi encontrado");
            Debug.Log("Nome do gameObject: " + gameObject.name);
        }
        //flashColor = gameObject.GetComponentInChildren<FlashColor>();

        //if (flashColor == null)
        //{
        //    flashColor = GetComponent<FlashColor>();
        //}
    }

    private void Update()
    {
        if(animator == null)
        {
            animator = gameObject.GetComponentInChildren<Animator>();

            if (animator != null)
            {
                Debug.Log("2 - Animator encontrado!!!");
                Debug.Log("2 - Nome do gameObject: " + gameObject.name);
            }
            else
            {
                Debug.Log("2 - Infelizmente o animator não foi encontrado");
                Debug.Log("2 - Nome do gameObject: " + gameObject.name);
            }
        }
    }

    public void Damage(float damage)
    {
        if (_isDead)
        {
            return;
        }

        _currentLife -= damage;

        //if(flashColor != null)
        //{
        //    flashColor.Flash();
        //}

        Debug.Log("Passando na função Damage!");

        if (_currentLife <= 0)
        {
            StartCoroutine(Kill());
        }
    }

    private IEnumerator Kill()
    {
        _isDead = true;

        if (destroyOnKill)
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            //audioSource.Play();
            
            //rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            //animator.SetBool(death, true);
            
            //animator.SetTrigger(death);
            //stateMachine.SwitchState(PlayerStates.DEATH, soPlayerSetup, _currentPlayer, death);

            //Debug.Log("playerScript.soPlayerSetup.death = "+ playerScript.soPlayerSetup.death);
            //playerScript.soPlayerSetup.player.SetTrigger(playerScript.soPlayerSetup.death);
            yield return new WaitForSeconds(2f);

            //if (endGame != null && gameObject.CompareTag(endGame.tagToCompare))
            //{
            //    endGame.CallEndGame();
            //}

            Destroy(gameObject);
        }
    }
}
