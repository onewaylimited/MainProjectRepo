using UnityEngine;
using System.Collections;

public class AimAssist : MonoBehaviour
{
    public string xaxis = "P1X";
    public string yaxis = "P1Y";
    public bool facingRight;
  
    void Start()
    {
    
    }


    void Update()
    {

        float inX = Input.GetAxis(xaxis);
        float inY = Input.GetAxis(yaxis);

        // Flip the character to face direction of movement
        if (inX < 0 && facingRight)
        {
            Flip();
        }
        else if (inX > 0 && !facingRight)
        {
            Flip();
        }

        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;
        if (!facingRight)
        {
            
            mouse_pos.y *= -1;
        }
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    void Flip()
    {
        // Change direction facing
        facingRight = !facingRight;

        // Flip the scale of the Character
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        charScale.y *= -1;
        transform.localScale = charScale;
    }
}