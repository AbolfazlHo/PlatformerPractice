using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;

    [SerializeField]
    private LayerMask _mask;

    private Rigidbody2D _rigid;
    private SpriteRenderer _sprite;

    private Vector2 _currentPossition;
    private Vector2 _perviousPossition;

    private bool _facingRight;
    private float _gravityScale = -1f;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Slider powerUpSlider;

    //Bullet bl = new Bullet();
    bool shoot = false;
    bool jump = false;

    void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _facingRight = true;


    }

    void OnEnale()
    {
        _currentPossition = transform.position;
        _perviousPossition = transform.position;
    }


    void Update()
    {
        if (jump)
        {
            if (powerUpSlider.value != 0.0f)
            {
                powerUpSlider.value -= 0.2f * Time.deltaTime;
            }
            else
            {
                powerUpSlider.value = 1.0f;
                powerUpSlider.gameObject.SetActive(false);
                jump = false;
                GetComponent<Jump>().enabled = false;
            }
        }

        if (shoot)
        {
            if (powerUpSlider.value != 0.0f)
            {
                powerUpSlider.value -= 0.2f * Time.deltaTime;
            }
            else
            {
                powerUpSlider.value = 1.0f;
                powerUpSlider.gameObject.SetActive(false);
                shoot = false;
                GetComponent<Weapon>().enabled = false;
            }
        }


       Vector2 dir = Vector2.zero;

        dir = SetDir(dir);
        Move(dir);
        CheckHit();
    }

    private Vector2 SetDir(Vector2 dir)
    {
        if (_facingRight)
        {
            dir.x = 1;
            _sprite.flipX = false;
        }
        else
        {
            dir.x = -1;
            _sprite.flipX = true;
        }
        return dir;
    }
    void CheckHit()
    {
        _currentPossition = transform.position;
        Vector2 dir = _currentPossition - _perviousPossition;
        RaycastHit2D hit2d = Physics2D.Raycast(
            transform.position, dir, dir.magnitude, _mask);


        if (hit2d.transform != null)
        {

            Powerup power = hit2d.transform.GetComponent<Powerup>();
            if (power != null)
            {
                HandlePowerUp(power);
            }

            Enemy enemy = hit2d.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                HandleEnemy(enemy);
            }
        }

        _perviousPossition = transform.position;


    }

    void HandleEnemy(Enemy enemy)
    {

    }

    void HandlePowerUp(Powerup power)
    {
        if (power.active == false) return;
        PowerupType type = power.type;
        print(type);
        switch (type)
        {
            case PowerupType.Jump:
                //Jump();
                GetComponent<Jump>().enabled = true;
                powerUpSlider.gameObject.SetActive(true);
                jump = true;

                
                break;
            case PowerupType.Shoot:
                //bl.Shoot(this.transform);
                //this.GetComponent<Bullet>().enabled = true;

                GetComponent<Weapon>().enabled = true;
                powerUpSlider.gameObject.SetActive(true);
                shoot = true;

                break;
            default:
                break;
        }
        power.active = false;
    }

    void Move(Vector2 dir)
    {
        _rigid.velocity = dir.normalized * _speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        foreach (var c in col.contacts)
        {

            Debug.DrawLine(transform.position, c.point, Color.red, 2f);
        }
        //print("OnCollisionEnter2D" + col.gameObject.name);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Die();
            //print("OnTriggerEnter2D" + col.gameObject.name);
        }

    }



/*void Jump()
{
        Vector3 powerPos;
        powerPos = this.transform.position;
        Vector3 dest = new Vector3(powerPos.x + 3, powerPos.y, powerPos.z);
        transform.DOJump(dest, 3.0f, 1, 1, false);
        powerUpSlider.gameObject.SetActive(true);
        powerUpSlider.value -= 0.05f;
    }*/

}
