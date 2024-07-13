using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionController : MonoBehaviour
{
    public Button joeBidenButton;
    public Button bernieSandersButton;
    public Button hillaryClintonButton;
    public Button barackObamaButton;
    public Button confirmButton;

    public Sprite joeBidenBordered;
    public Sprite joeBidenUnbordered;
    public Sprite bernieSandersBordered;
    public Sprite bernieSandersUnbordered;
    public Sprite hillaryClintonBordered;
    public Sprite hillaryClintonUnbordered;
    public Sprite barackObamaBordered;
    public Sprite barackObamaUnbordered;

    public AudioClip joeBidenClip;
    public AudioClip bernieSandersClip;
    public AudioClip hillaryClintonClip;
    public AudioClip barackObamaClip;

    private AudioSource audioSource;
    private Button activeButton;
    private string selectedCharacterName;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.LogError("AudioSource component was missing and has been added to the CharacterSelectionController.");
        }
    }

    void Start()
    {
        joeBidenButton.onClick.AddListener(() => SelectCharacter(joeBidenButton, joeBidenBordered, joeBidenUnbordered, joeBidenClip, "Joe Biden"));
        bernieSandersButton.onClick.AddListener(() => SelectCharacter(bernieSandersButton, bernieSandersBordered, bernieSandersUnbordered, bernieSandersClip, "Bernie Sanders"));
        hillaryClintonButton.onClick.AddListener(() => SelectCharacter(hillaryClintonButton, hillaryClintonBordered, hillaryClintonUnbordered, hillaryClintonClip, "Hillary Clinton"));
        barackObamaButton.onClick.AddListener(() => SelectCharacter(barackObamaButton, barackObamaBordered, barackObamaUnbordered, barackObamaClip, "Barack Obama"));

        confirmButton.onClick.AddListener(ConfirmSelection);
    }

    void SelectCharacter(Button selectedButton, Sprite borderedSprite, Sprite unborderedSprite, AudioClip characterClip, string characterName)
    {
        if (activeButton != null)
        {
            ResetButtonSprite(activeButton);
        }

        activeButton = selectedButton;
        selectedButton.image.sprite = borderedSprite;
        selectedCharacterName = characterName;

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(characterClip);
        }
    }

    void ResetButtonSprite(Button button)
    {
        if (button == joeBidenButton)
        {
            button.image.sprite = joeBidenUnbordered;
        }
        else if (button == bernieSandersButton)
        {
            button.image.sprite = bernieSandersUnbordered;
        }
        else if (button == hillaryClintonButton)
        {
            button.image.sprite = hillaryClintonUnbordered;
        }
        else if (button == barackObamaButton)
        {
            button.image.sprite = barackObamaUnbordered;
        }
    }

    void ConfirmSelection()
    {
        if (!string.IsNullOrEmpty(selectedCharacterName))
        {
            CharacterSelection.SelectCharacter(selectedCharacterName);
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }
}
