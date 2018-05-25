using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the sprites & animation for the player character.
/// </summary>
public class CharacterManager : MonoBehaviour
{
    public int hairAnimation, faceAnimation, clothingAnimation, backpackAnimation, glovesAnimation, pantsAnimation;

    // all animators for the character.
    Animator hairAnimator, faceAnimator, clothingAnimator, backpackAnimator, glovesAnimator, pantsAnimator;

    void Awake()
    {
        ResetRenderers();
        ChangeVersion();
    }

    // Finds the player and resets the animators.
    public void ResetRenderers()
    {
        hairAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>();
        faceAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).GetComponent<Animator>();
        clothingAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).GetComponent<Animator>();
        backpackAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).GetComponent<Animator>();
        glovesAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(4).GetComponent<Animator>();
        pantsAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).GetComponent<Animator>();
    }

    // Changes the animations to the right colour version.
    public void ChangeVersion()
    {
        hairAnimator.SetInteger("Colour", hairAnimation);
        faceAnimator.SetInteger("Colour", faceAnimation);
        clothingAnimator.SetInteger("Colour", clothingAnimation);
        backpackAnimator.SetInteger("Colour", backpackAnimation);
        glovesAnimator.SetInteger("Colour", glovesAnimation);
        pantsAnimator.SetInteger("Colour", pantsAnimation);
    }

    // Tells the OnLevelFinishedLoading function to watch out for scene changes.
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    
    // If the level is loaded, reset the renderers and change the sprites accordingly.
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        ResetRenderers();
        ChangeVersion();
    }

}
