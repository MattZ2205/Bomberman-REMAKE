using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ICharacterInput characterInput;
    private CharacterMotor characterMotor;
    
    [SerializeField] bool isAI;
    [SerializeField] LayerMask mask;

    [HideInInspector] public float speed;

    private void Awake()
    {
        characterInput = isAI ? new AIInput() : new PlayerInput();
        characterMotor = new CharacterMotor(characterInput, gameObject);
    }

    private void Update()
    {
        characterInput.ReadInput(isAI ? Physics.Raycast(transform.position, transform.right, 0.6f, mask) : false);
        characterMotor.Move(speed);
    }
}