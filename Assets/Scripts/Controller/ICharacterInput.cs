using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public interface ICharacterInput
{
    float axesX { get; }
    float axesY { get; }
    float rotation { get; }

    void ReadInput(bool isBlocked);
}

public class PlayerInput : ICharacterInput
{
    public float axesX { get; private set; }
    public float axesY { get; private set; }
    public float rotation { get; private set; }

    public void ReadInput(bool isBlocked)
    {
        axesX = Input.GetAxisRaw("Horizontal");
        axesY = Input.GetAxisRaw("Vertical");
    }
}

public class AIInput : ICharacterInput
{
    public float axesX { get; private set; }
    public float axesY { get; private set; }
    public float rotation { get; private set; }

    float timer = 0;
    public void ReadInput(bool isBlocked)
    {
        axesX = 1;
        axesY = 0;
        timer += Time.deltaTime;
        if (timer >= 6 || isBlocked)
        {
            rotation += 90;
            timer = 0;
        }
    }
}
