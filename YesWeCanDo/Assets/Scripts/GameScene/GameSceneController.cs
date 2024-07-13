using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    void Start()
    {
        string selectedCharacter = CharacterSelection.SelectedCharacter;
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            Debug.Log("Selected Character: " + selectedCharacter);
            // F�ge hier die Logik hinzu, um den ausgew�hlten Charakter darzustellen und personalisierte Inhalte zu laden
            LoadCharacterContent(selectedCharacter);
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }

    void LoadCharacterContent(string characterName)
    {
        // Implementiere die Logik, um personalisierte Inhalte basierend auf dem ausgew�hlten Charakter zu laden
        switch (characterName)
        {
            case "Joe Biden":
                // Lade Inhalte f�r Joe Biden
                break;
            case "Bernie Sanders":
                // Lade Inhalte f�r Bernie Sanders
                break;
            case "Hillary Clinton":
                // Lade Inhalte f�r Hillary Clinton
                break;
            case "Barack Obama":
                // Lade Inhalte f�r Barack Obama
                break;
            default:
                Debug.LogError("Unknown character selected!");
                break;
        }
    }
}
