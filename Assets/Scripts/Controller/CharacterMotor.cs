using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    private ICharacterInput characterInput;
    private GameObject gameobjectToMove;

    Vector3 direction;
    CharacterController cc;

    public CharacterMotor(ICharacterInput _CharacterInput, GameObject _GameobjectToMove)
    {
        characterInput = _CharacterInput;
        gameobjectToMove = _GameobjectToMove;
        cc = gameobjectToMove.GetComponent<CharacterController>();
    }

    public void Move(float speed)
    {
        direction = Vector3.zero;
        direction += gameobjectToMove.transform.right * characterInput.axesX;
        direction += gameobjectToMove.transform.up * characterInput.axesY;
        cc.Move(direction * speed * Time.deltaTime);
        gameobjectToMove.transform.rotation = Quaternion.Euler(new(0, 0, characterInput.rotation));
    }
}