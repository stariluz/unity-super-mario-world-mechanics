using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
  public Movement movement;
  // public Collider2D playerCollider;
  // public SpriteRenderer playerSprite;
  // public Animator playerAnim;
  public string playerState;

  GameObject oldState, newState;
  ContactPoint2D[] contacts;
  void OnTriggerEnter2D(Collider2D collider)
  {
    // print(collider.tag);
    if (collider.tag == "RedMushroom")
    {
      if (playerState == "Small")
      {
        changePlayerStates(1, 2, "Large");
      }
    }
    else if (collider.tag == "FireFlower")
    {
      switch (playerState)
      {
        case "Small":
          changePlayerStates(1, 3, "FirePower");
          break;
        case "Large":
          changePlayerStates(2, 3, "FirePower");
          break;
        case "FirePower":
          break;
      }
    }
    /*
      /// Idea getting the name of the child trigger, but didnt work fine
      contacts = new ContactPoint2D[10];
      int numberContacts = collider.GetContacts(contacts);
      print(("Number of contacts:", numberContacts));
      foreach (ContactPoint2D contact in contacts)
      {
        print(contact.otherCollider);
      }
      int id = contacts[1].collider.transform.GetSiblingIndex();
      print((id, contacts[1].collider));
    */
    collider.gameObject.SetActive(false);
  }

  private void changePlayerStates(int idOldState, int idNewState, string newStateName)
  {
    oldState = transform.GetChild(idOldState).gameObject;
    newState = transform.GetChild(idNewState).gameObject;
    oldState.gameObject.SetActive(false);
    newState.gameObject.SetActive(true);

    playerState = newStateName;
    updatePlayerComponents(newState);
  }

  private void updatePlayerComponents(GameObject newState)
  {
    movement.playerCollider = newState.GetComponent<Collider2D>();
    movement.playerSprite = newState.GetComponent<SpriteRenderer>();
    movement.playerAnim = newState.GetComponent<Animator>();
  }
}
