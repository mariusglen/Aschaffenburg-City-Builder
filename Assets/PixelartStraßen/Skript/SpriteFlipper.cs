using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;


    void Update()
    {
        if (GridBuildingSystem.current.IsPlacing && Input.GetKeyDown(KeyCode.R))
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
                Debug.Log("flip1");
                return;
            }
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
                Debug.Log("flip2");
                return;
            }
        }
    }
}
