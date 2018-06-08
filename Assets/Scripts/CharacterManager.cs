using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

/// <summary>
/// Manages the sprites & animation for the player character.
/// </summary>
public class CharacterManager : MonoBehaviour
{
    public int hairAnimation, faceAnimation, clothingAnimation, backpackAnimation, glovesAnimation, pantsAnimation;

    // all animators for the character.
    Animator hairAnimator, faceAnimator, clothingAnimator, backpackAnimator, glovesAnimator, pantsAnimator;

    AnalyticsResult result;
    private Dictionary<string, object> parameters = new Dictionary<string, object>();
    bool dataSent = false;
    public bool sendData = false;

    void Awake()
    {
        ResetRenderers();
        ChangeVersion();
    }

    // Sends Data numbers;
    private void Update()
    {
        if (!dataSent && sendData)
        {
            Dispatch();
        }
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

    public bool Dispatch()
    {
        parameters["hair"] = hairAnimation;
        parameters["face"] = faceAnimation;
        parameters["hoodie"] = clothingAnimation;
        parameters["backpack"] = backpackAnimation;
        parameters["gloves"] = glovesAnimation;
        parameters["pants"] = pantsAnimation;

        result = AnalyticsEvent.Custom("Clothing style", parameters);

        if (result == AnalyticsResult.Ok)
        {
            dataSent = true;
            return true;
        }
        else
        {
            Debug.Log("Clothing Analytics Error");
            return false;
        }
    }
}
