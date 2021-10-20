using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{

    [Header("������� ��������� �� ������. �������� �� 0,1 �� 0,9 ����� �������.")] 
    [SerializeField] float targetPosition = 0.5f;
    [Header("�������� �������� �������� ������")]
    [SerializeField] float forwardSpeed = 1.5f;

    [Header("�������� �������� �������� �����-������")]
    [SerializeField] float leftrightSpeed = 7f;
    [SerializeField] private Animator _animator;
    [SerializeField] private AggressionHero aggressionHero;
    [SerializeField] private TransformationHero _transformationHero;
    [SerializeField] private ObjectsCollider ob;
    float rotationSpeed = 4.5f;
    private float aggresionSpeed = 0;
    private float standartSpeed = 0;
    float updownSpeed = 0;
    float _diff = 0f;

    [SerializeField] GameObject heroModel = null;
    [SerializeField] private CapsuleCollider _capsuleCollider;
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _transformHero;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] private float angle;
    private bool isAgresion;
    private bool isAgresionJamping;

    public float TargetPosition
    {
        get => targetPosition;
        set => targetPosition = value;
    }

    public bool IsAgresionJamping
    {
        get => isAgresionJamping;
        set => isAgresionJamping = value;
    }

    public bool IsAgresion
    {
        get => isAgresion;
        set => isAgresion = value;
    }
    public float Angle
    {
        get => angle;
        set => angle = value;
    }

    private float s = 0;
    public bool inAir = false;
    private float timer = 1;
    private int tempAgresion = 0;
    private bool tempStart = false;
    public float speed;
    public float AggresionSpeed
    {
        get => aggresionSpeed;
        set => aggresionSpeed = value;
    }

    public float StandartSpeed
    {
        get => standartSpeed;
        set => standartSpeed = value;
    }
    public bool TempStart
    {
        get => tempStart;
        set => tempStart = value;
    }

    private void Start()
    {
        //this.enabled = false;
    }

    public void InputMovement(Vector3 delta)
    {
        float nextPosition = TargetPosition + (delta.x) * 0.002f;
        if(nextPosition > 0.1f && nextPosition < 0.9f) TargetPosition = nextPosition;
    }

    async void Update()
    {
        if (aggressionHero.Aggresion >= 1)
        {
            IsAgresion = true;
        }
        rotationSpeed = forwardSpeed * 3;

        if (TempStart)
        {
            Angle += WallsOrientationSystem.GetDeviationAngleOf(transform) * Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.AngleAxis(Angle, Vector3.up);


            Vector3 forwardMovement = transform.forward * forwardSpeed;
            Vector3 leftrightMovement =
                (WallsOrientationSystem.GetToCentreMovementFrom(transform) +
                 transform.right * (TargetPosition - 0.5f)) * leftrightSpeed;
            Vector3 updownMovement = Vector3.zero;

            if (!inAir)
            {
                updownSpeed = 0;
                _diff = 0;
            }

            updownMovement = Vector3.up * updownSpeed;
            updownSpeed -= _diff * Time.deltaTime;

            Vector3 movement = forwardMovement + leftrightMovement + updownMovement;
            movement.x += movement.x + Time.deltaTime;

            float rotationAngle = GetModelRotationAngle(movement);
            float modelRotation = (Angle + rotationAngle) ;
            float step = GetModelRotationStep(rotationAngle);

            heroModel.transform.rotation = Quaternion.RotateTowards(heroModel.transform.rotation,
                Quaternion.AngleAxis(modelRotation, Vector3.up), step * Time.deltaTime);


            transform.position += movement * Time.deltaTime;
            forwardSpeed = AggresionSpeed;
            if (aggressionHero.Aggresion >= 10 && ob.notAgresion)
            {
                ob.notAgresion = false;
                
                await Task.Delay(500);
                isAgresionJamping = true;
                _animator.SetBool("іsAggresion", true);
                forwardSpeed = AggresionSpeed;
                _animator.SetLayerWeight(3, 1);
                _animator.SetLayerWeight(0, 0);
                AgresionTime();
            }
        }
    }

    private async void AgresionTime()
    {
        for (int i = 0; i < 10; i++)
        {
            aggressionHero.Aggresion -= 1;
            await Task.Delay(500);
        }
        isAgresionJamping = false;
        _animator.SetBool("іsAggresion", false);
        _animator.SetLayerWeight(3, 0);
        _animator.SetLayerWeight(0, 1);
        ob.notAgresion = true;
    }
        
    float GetModelRotationAngle(Vector3 movement)
    {
        float rotationAngle = Vector3.Angle(transform.forward, new Vector3(movement.normalized.x, 0, movement.normalized.z));

        if(Vector3.Angle(transform.right, movement) > 90) rotationAngle = -rotationAngle;

        return rotationAngle;
    }

    public float GetModelRotationStep(float rotationAngle)
    {
        float step;
        if (Mathf.Abs(rotationAngle)>5)
        {
            step = (float)Mathf.Pow(rotationAngle, 2)*0.3f;
        }
        else
        {
            step = 100;
        }
        
        return step;
    }

    public void SetSpeed(float speed, float intensity)
    {
        StopCoroutine("SetSpeedCor");
        StartCoroutine(SetSpeedCor(speed, intensity));
    }

    public void FlyUp(float intensity, float diff)
    {
        StopCoroutine("SetSpeedCor");
        StartCoroutine(SetSpeedCor(2f, 0.5f));
        inAir = true;

        updownSpeed = (intensity);
        _diff = diff;
    }
    
    public void Jump()
    {
        _diff = 0;
        inAir = true;
        StopCoroutine("SetSpeedCor");
        StopCoroutine("JumpPrepare");
        StartCoroutine(SetSpeedCor(1f, 0.5f));
        StartCoroutine(JumpPrepare());
    }

    IEnumerator SetSpeedCor(float speed, float intensity)
    {
        while (Mathf.Abs(speed - forwardSpeed) >= 0.01f)
        {
            forwardSpeed += intensity * (speed-forwardSpeed);
            
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator JumpPrepare()
    {
        
        while (Mathf.Abs(-0.4f - updownSpeed) >= 0.03f)
        {
            /*Debug.Log(updownSpeed);
            Debug.Log(Mathf.Abs(-0.5f - updownSpeed));*/
            updownSpeed += 0.5f * (-0.4f - updownSpeed);

            yield return new WaitForSeconds(0.01f);
        }

        FlyUp(3.67f, 3.4f);
    }

    async void OnTriggerEnter(Collider other)
    {
        /*float speeds = 0.02f;
        if (isAgresionJamping)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                int count = 0;
                for (int i = 0; i < 100; i++)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speeds,
                        transform.position.z);
                    count++;
                    await Task.Delay(1);
                    if (other.gameObject.CompareTag("Potolok"))
                    {
                        break;
                    }
                }
                
                for (int i = 0; i < count / 2; i++)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + (speeds * 2),
                        transform.position.z);
                    await Task.Delay(1);
                    if (other.gameObject.CompareTag("Floor"))
                    {
                        break;
                    }
                }
            }
        }*/
    }
}
