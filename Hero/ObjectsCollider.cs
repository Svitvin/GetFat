using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsCollider : MonoBehaviour
{
    [SerializeField] GameObject ragdoll;
    [SerializeField] GameObject notRagdoll;
    [SerializeField] private GameObject Panel;
    //[SerializeField] FatnessController fc;
    [SerializeField] HeroMovement hm;
    [SerializeField] private Rigidbody _rigidbody;
    float jumpIntensity = 2.2f;
    float diff = 4f;
    [SerializeField]
    private AggressionHero _aggressionHero;

    public bool final;
    public bool stop;
    public bool notAgresion = true;

    [SerializeField] private TransformationHero _transformationHero;
    [SerializeField] private Rigidbody _rigidbodyRig;


    [SerializeField] private Animator _animator;
    private static readonly int IsJump = Animator.StringToHash("isJump");



    private void Awake()
    {
        //fc = GetComponent<FatnessController>();
        hm = GetComponent<HeroMovement>();
    }

    async void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {

            if (hm.inAir)
            {
                transform.position = new Vector3(transform.position.x, 0.064f, transform.position.z);
                hm.inAir = false;
            }
            _animator.SetBool("іsJump", false);
            if (stop)
            {
                Debug.Log("0");
                hm.AggresionSpeed = 0;
            }
            else
            {
                if (final)
                {
                    Debug.Log("1");
                    for (float i = 2; i > 0.5f; i-=0.1f)
                    {
                        hm.AggresionSpeed = i;
                        await Task.Delay(25);
                    }
                }
                else
                {
                    hm.AggresionSpeed = 2;
                }
            }
            Debug.Log(hm.AggresionSpeed);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            // fc.ChangeFatness(5);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (notAgresion)
            {
                _aggressionHero.Aggresion += 1;
            }

            other.gameObject.GetComponentInChildren<RagdollController>().Punch();
                
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            if (notAgresion)
            {
                _aggressionHero.Aggresion += 1;
                if (_transformationHero.Toxin >= 0)
                {
                    _transformationHero.Toxin -= 3;
                }
            }
        }
        else if (other.gameObject.CompareTag("Propast"))
        {
            Panel.active = false;
            ragdoll.active = true;
            notRagdoll.active = false;
            hm.speed = 0;
            hm.AggresionSpeed = 0;
            //_rigidbodyRig.AddForce(0,0,0.2f, ForceMode.VelocityChange);
        }
        else if (other.gameObject.CompareTag("Zabor"))
        {
            if (notAgresion)
            {
                _aggressionHero.Aggresion += 1;
                if (_transformationHero.Toxin >= 0)
                {
                    _transformationHero.Toxin -= 2;
                }
            }
        }
        else if (other.gameObject.CompareTag("GlassWall"))
        {
            if (notAgresion)
            {
                _aggressionHero.Aggresion += 1;
                if (_transformationHero.Toxin >= 0)
                {
                    _transformationHero.Toxin -= 1;
                }
            }
        }
        else if (other.gameObject.CompareTag("AttackWall"))
        {
            if (notAgresion)
            {
                _animator.SetLayerWeight(1, 1);
                _animator.SetBool("isAttack", true);
                await Task.Delay(500);
                _animator.SetBool("isAttack", false);
                _animator.SetLayerWeight(1, 0);
            }
        }
        else if (other.gameObject.CompareTag("AttackShoulder"))
        {
            if (notAgresion)
            {
                _animator.SetLayerWeight(2, 1);
                _animator.SetBool("isAttack", true);
                await Task.Delay(600);
                _animator.SetBool("isAttack", false);
                _animator.SetLayerWeight(2, 0);
            }
        }
        else if (other.gameObject.CompareTag("Toxic"))
        { 
            _transformationHero.Toxin += 1;
        }
        else if(other.gameObject.CompareTag("JumpPoint"))
        {
            hm.Jump();
        }
        else if (other.gameObject.CompareTag("Jump"))
        {
            _animator.SetBool("isJump", true);
            _rigidbody.useGravity = false;
            hm.AggresionSpeed = 1.5f;

        }
        else if (other.gameObject.CompareTag("NotJump"))
        {
            _animator.SetBool("isJump", false);
            _rigidbody.useGravity = true;
            if (_animator.GetBool("іsAggresion"))
            {
                hm.AggresionSpeed = 3.5f;
            }
        }
        else if (other.gameObject.CompareTag("Hooked"))
        {
            _animator.SetBool("isJump", false);
            await Task.Delay(200);
            hm.AggresionSpeed = 0.2f;
            await Task.Delay(300);  
            hm.AggresionSpeed = 2f;
        }
        else if (other.gameObject.CompareTag("AntiToxin"))
        {
            _transformationHero.Toxin -= 3;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Treadmill"))
        {
            hm.SetSpeed(0f, 0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Treadmill"))
        {
            //fc.ChangeFatness(-1f);
        }
    }
}