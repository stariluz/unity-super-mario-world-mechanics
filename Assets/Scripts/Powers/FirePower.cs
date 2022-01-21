using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePower : MonoBehaviour
{
  public Rigidbody2D fireBallRB;
  public int jumpsLives = 3;
  public float speedBall;
  public float jumpForce, lastJumpForce;

  // Start is called before the first frame update
  // void Start()
  // {
    
  // }

  // Update is called once per frame
  void Update()
  {
    fireBallRB.velocity = new Vector2(speedBall, fireBallRB.velocity.y);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    // print("Collision");
    // print(LayerMask.LayerToName(other.gameObject.layer));
    string layerCollision = LayerMask.LayerToName(other.gameObject.layer);
    if (layerCollision == "GroundCollider")
    {
      jumpsLives--;
      if (jumpsLives == 0) {
        // Caso Final de la FireBall: Desactiva y destruye el objeto
        gameObject.SetActive(false);
        Destroy(gameObject, 0.1f);

      } else if (jumpsLives == 1) {
        // Caso Ultimo salto: Salta más alto
        fireBallRB.velocity = new Vector2(fireBallRB.velocity.x, jumpForce+lastJumpForce);

      } else {
        // Caso General: Le da la fuerza del salto
        fireBallRB.velocity = new Vector2(fireBallRB.velocity.x, jumpForce);

      }
    }
  }
}
