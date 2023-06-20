using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactarMovement : MonoBehaviour
{
    
    public Vector2 speed = new Vector2(50f,50f);
    
    public Animator animator;
    
    
    void Update()
    {
      float inputX = Input.GetAxis("Horizontal");
      float inputY = Input.GetAxis("Vertical");

      animator.SetFloat("speed",Mathf.Abs(inputX));
        Vector3 movement = new Vector3(speed.x*inputX,speed.y*inputY,0);

        movement *=Time.deltaTime;

        transform.Translate (movement);
      bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

        if(shoot){
            WeaponScript weapon =GetComponent<WeaponScript>();
            if(weapon != null){
                weapon.Attack(false);


                // 6 - Make sure we are not outside the camera bounds
         var dist = (transform.position - Camera.main.transform.position).z;

         var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
           ).x;

         var rightBorder = Camera.main.ViewportToWorldPoint(
         new Vector3(1, 0, dist)
         ).x;

         var topBorder = Camera.main.ViewportToWorldPoint(
         new Vector3(0, 0, dist)
         ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
        new Vector3(0, 1, dist)
        ).y;

         transform.position = new Vector3(
         Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
         Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
         transform.position.z
         );
            }
        }
    
    }
    
}
