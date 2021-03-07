using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : PangElement
{
    bool moveLeft;
    bool moveRight;
    bool shoot;

    //listener for user input
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || moveLeft)
        {
            app.Notify(PangNotification.PlayerMoveLeft, this);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || moveRight)
        {
            app.Notify(PangNotification.PlayerMoveRight, this);
        }
        else
        {
            GetComponent<Animator>().SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) || shoot)
        {
            app.Notify(PangNotification.ShootPullet, this);
            shoot = false;
        }
    }

    //triggered when the user clicks the "move left" button.
    public void PalyerMovingLeft()
    {
        moveLeft = true;
    }

    //triggered when the user stop clicks the "move left" button.
    public void PlayerDoneMovingLeft()
    {
        moveLeft = false;
    }

    //triggered when the user clicks the "move right" button.
    public void PalyerMovingRight()
    {
        moveRight = true;
    }

    //triggered when the user stop clicks the "move right" button.
    public void PlayerDoneMovingRight()
    {
        moveRight = false;
    }

    //triggered when the user clicks the "shoot" button.
    public void ShotClicked()
    {
        shoot = true;
    }

    //triggered when the user reaches the limits of the screen.
    //user game over when the balloon collides with the player.
    //Play audio.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LeftBorder")
        {
            app.Notify(PangNotification.PlayerHitLeftBorder, this);
        }
        else if(collision.gameObject.tag == "RightBorder")
        {
            app.Notify(PangNotification.PlayerHitRightBorder, this);
        }
        else if(collision.gameObject.tag == "Balloon")
        {
            app.Notify(PangNotification.PlayerDie, this);
            AudioManager.instance.PlaySound(EAudioType.Lose);
            GameUIController.instance.GameOver();
            Destroy(gameObject);
        }
        
    }

    public void SetPosition(Vector2 vector)
    {
        transform.position = vector;
    }

    public void SetRotation(Vector3 vector)
    {
        transform.rotation = new Quaternion(vector.x,vector.y,vector.z,0f);
    }

    //Change animation state.
    public void SetRunAnimation(bool isRunning)
    {
        GetComponent<Animator>().SetBool("Run", isRunning);
    }


}
