using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    private float jumpPower;
    private float dashPower;
    private bool is_jump;
    private bool dashcool;
    private float Speed;
    private bool right, left;
    private Transform platform;
    private Player playerscript;

    private void Start()
    {
        Speed = 5;
        jumpPower = 9.0f;
        dashPower = 5.0f;
        is_jump = false;
        playerscript = this.GetComponent<Player>();
    }
    private void Update()
    {
        if (playerscript.Is_Dead)
        {
            return;
        }
        
        if (right)
        {
            Move_right();   
        }
        if (left)
        {
            Move_left();
        }
    }

    public void down_right()
    {
        right = true;
    }
    public void up_right()
    {
        right = false;
    }


    public void down_left()
    {
        left = true;
    }
    public void up_left()
    {
        left = false;
    }


    public void Move_right()
    {
        this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);

        this.transform.position += Vector3.right * Speed * Time.deltaTime;
    }
    public void Move_left()
    {
        this.GetComponent<Transform>().rotation = Quaternion.Euler(0,180,0);
        this.transform.position += Vector3.left * Speed * Time.deltaTime;
    }

    public void jump()
    {
        // 점프 애니메이션
        Debug.Log("jump");
        if (is_jump)
        {
            return;
        }
        this.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
        is_jump = true;
    }
    public void bottomjump()
    {
        // 아래 점프 애니메이션
        if(platform.tag != "LastPlatform")
        {
            Transform playerTransform = this.GetComponent<Transform>();
            playerTransform.position = new Vector2(playerTransform.position.x, platform.position.y-1);
        }      
        
    }

    public void buttonAttack()
    {
        // 어택 애니메이션
        this.GetComponentInChildren<Attack>().playerAttackMotion();
    }
    public void buttonSkill_1()
    {
        // 장비에따라 바뀐 1번 스킬 사용
    }
    public void buttonDash()
    {
        // 장비에 따라 바뀐 2번 스킬 사용
        if (playerscript.Is_Dash || dashcool)
        {
            return;
        }
        playerscript.Is_Dash = true;
        dashcool = true;
        if(this.GetComponent<Transform>().rotation.eulerAngles==new Vector3(0, 0, 0))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dashPower, ForceMode2D.Impulse);

        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * dashPower, ForceMode2D.Impulse);

        }
        Invoke("dash", 0.5f);
        Invoke("dashcooltime", 3);
    }
 
    public void buttonPotion1()
    {
        if( playerscript.potion1.potion_Type == 0)
        {
            playerscript.recovery(playerscript.potion1);
            return;
        }

        playerscript.enhance(playerscript.potion1);

    }
    public void buttonPotion2()
    {
        if (playerscript.potion1.potion_Type == 0)
        {
            playerscript.recovery(playerscript.potion2);
            return;
        }
        playerscript.enhance(playerscript.potion2);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_jump = false;
        platform = collision.gameObject.GetComponent<Transform>();
    }
    void dash()
    {
        Debug.Log("호 영 조 아");
        playerscript.Is_Dash = false;
    }
    void dashcooltime()
    {
        dashcool = false;
    }
}
