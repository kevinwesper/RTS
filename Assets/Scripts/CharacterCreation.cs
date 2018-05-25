using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used to customize the player character.
/// </summary>
public class CharacterCreation : MonoBehaviour
{
    Image image;

    // The different sprites available for character customization.
    [SerializeField]
    Sprite[] sprites;

    bool change = true;

    int spriteNumber = 0;

    CharacterManager manager;

    void Awake ()
    {
        image = GetComponent<Image>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CharacterManager>();
	}
	
    // Saves the change of the sprite and animation to the manager.
	void Update ()
    {
        // Checks if a change has been made (it's a bit overkill to do that every frame).
        if (change)
        {
            // This could be done in a cleaner way, but it works for now.
            if (name == "Hair")
            {
                manager.hairAnimation = spriteNumber;
            }
            if (name == "Face")
            {
                manager.faceAnimation = spriteNumber;
            }
            if (name == "Clothing")
            {
                manager.clothingAnimation = spriteNumber;
            }
            if (name == "Backpack")
            {
                manager.backpackAnimation = spriteNumber;
            }
            if (name == "Gloves")
            {
                manager.glovesAnimation = spriteNumber;
            }
            if (name == "Pants")
            {
                manager.pantsAnimation = spriteNumber;
            }

            manager.ChangeVersion();

            change = false;
        }
	}

    // Goes to the next sprite of the array.
    public void NextLook()
    {
        if (spriteNumber == sprites.Length-1)
        {
            spriteNumber = 0;
        }
        else
        {
            spriteNumber++;
        }

        change = true;
        image.sprite = sprites[spriteNumber];
    }

    // Goes to the previous sprite of the array.
    public void PreviousLook()
    {
        if (spriteNumber == 0)
        {
            spriteNumber = sprites.Length-1;
        }
        else
        {
            spriteNumber--;
        }

        change = true;
        image.sprite = sprites[spriteNumber];
    }
}
