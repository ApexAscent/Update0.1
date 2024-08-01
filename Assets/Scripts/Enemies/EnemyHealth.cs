using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefeb;
    [SerializeField] private float knockBackThrust = 15f;


    private int currentHealth;
    private Knockback knockBack;
    private Flash flash;
    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<Knockback>();
    }
    private void Start()
    {
        currentHealth  = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform, knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRountine() );
    }

    private IEnumerator CheckDetectDeathRountine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }

    public void DetectDeath() {
        if (currentHealth <= 0)
        {
            GetComponent<PickUpSpawner>().DropItems();
            Instantiate(deathVFXPrefeb, transform.position, Quaternion.identity);   
            Destroy(gameObject);
                
        }
    }

}
