using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class StanceHUD : MonoBehaviour
{
    [Tooltip("Image component for the stance sprites")]
    public Image stanceImage;
    [Tooltip("Sprite to display when standing")]
    public Sprite standingSprite;
    [Tooltip("Sprite to display when crouching")]
    public Sprite crouchingSprite;

    private void Start()
    {
        PlayerCharacterController character = FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, StanceHUD>(character, this);
        character.OnStanceChanged += OnStanceChanged;

        OnStanceChanged(character.IsCrouching);
    }

    void OnStanceChanged(bool crouched)
    {
        stanceImage.sprite = crouched ? crouchingSprite : standingSprite;
    }
}
