using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    void Start()
    {
        string selectedCharacter = CharacterSelection.SelectedCharacter;
        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            Debug.Log("Selected Character: " + selectedCharacter);
            // Füge hier die Logik hinzu, um den ausgewählten Charakter darzustellen und personalisierte Inhalte zu laden
            LoadCharacterContent(selectedCharacter);
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }

    void LoadCharacterContent(string characterName)
    {
        // Implementiere die Logik, um personalisierte Inhalte basierend auf dem ausgewählten Charakter zu laden
        switch (characterName)
        {
            case "Joe Biden":
                // Lade Inhalte für Joe Biden
                break;
            case "Bernie Sanders":
                // Lade Inhalte für Bernie Sanders
                break;
            case "Hillary Clinton":
                // Lade Inhalte für Hillary Clinton
                break;
            case "Barack Obama":
                // Lade Inhalte für Barack Obama
                break;
            default:
                Debug.LogError("Unknown character selected!");
                break;
        }
    }
}
