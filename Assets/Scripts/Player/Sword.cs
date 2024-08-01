using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    //[SerializeField] private Transform weaponCollider;
    [SerializeField] private WeaponInfo weaponInfo;
    //[SerializeField] private float swordAttackCD = .5f;



    /*private PlayerControls playerControls;*/
    private Animator myAnimator;
    //private PlayerController playerController;
    //private ActiveWeapon activeWeapon;

    //private bool attacButtonDown, isAttacking = false;

    private GameObject slashAnim;

    private Transform weaponCollider;
    private void Awake()
    {
    
        //playerController = GetComponentInParent<PlayerController>();
        //activeWeapon = GetComponentInParent<ActiveWeapon>();

        myAnimator = GetComponent<Animator>();
       /* playerControls = new PlayerControls ();*/

    }

    private void Start()
    {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();
        slashAnimSpawnPoint = GameObject.Find("SlashSpawnPoint").transform;
    }

    /*    private void OnEnable()
        {
            playerControls.Enable();
        }

        void Start()
        {
            playerControls.Combat.Attack.started += _ => StartAttacking();
            playerControls.Combat.Attack.canceled += _ => StopAttacking();
        }*/

    private void Update()
    {
        MouseFollowWithOffset();
       /* Attack();*/
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

/*    private void StartAttacking()
    {
        attacButtonDown = true;
    }

    private void StopAttacking() 
    { 
        attacButtonDown = false;
    }*/

/*    private void Attack()
    {
        if (attacButtonDown && !isAttacking) 
        {
        isAttacking = true;
            myAnimator.SetTrigger("Attack");
            weaponCollider.gameObject.SetActive(true);
            slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
            slashAnim.transform.parent = this.transform.parent;
            StartCoroutine(AttackCDRountine());
        }
    }*/
     public void Attack()
    {
        //isAttacking = true;
        myAnimator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
        //StartCoroutine(AttackCDRountine());
    }

  /*  private IEnumerator AttackCDRountine()
    {
        yield return new WaitForSeconds(swordAttackCD);
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }*/

    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (PlayerController.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (PlayerController.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }



    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
