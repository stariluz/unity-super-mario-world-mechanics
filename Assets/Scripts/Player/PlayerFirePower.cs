using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFirePower : MonoBehaviour
{
  public Object prefabFireBall;
  public Transform player;
  public float heightAbovePlayer;
  Vector3 fireBallPosition;

  void Update()
  {
    if(Input.GetKeyDown(KeyCode.V)){
      // print(("Se pulsó V"));
      createFireBall(player, heightAbovePlayer);
    }
  }

  //// Intanciar FireBall y direccionar según el personaje
  void createFireBall(Transform parent, float heightAboveParent){
    
    int direction = 1;
    if (parent.gameObject.GetComponent<Movement>().playerSprite.flipX == true)
      direction = -1;

    fireBallPosition = new Vector2(
      parent.position.x + 0.15f*direction,
      parent.position.y + heightAboveParent
    );
    // print(("Posición:", fireBallPosition));
    GameObject fireBall = Instantiate(
      prefabFireBall, fireBallPosition,
      Quaternion.identity, parent)
    as GameObject;
    fireBall.GetComponent<FirePower>().speedBall *= direction;
  }
}
