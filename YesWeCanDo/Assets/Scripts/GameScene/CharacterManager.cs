using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject joeBidenPrefab;
    public GameObject bernieSandersPrefab;
    public GameObject hillaryClintonPrefab;
    public GameObject barackObamaPrefab;

    private GameObject candidatesParent;

    private void Start()
    {
        // Find the Candidates GameObject in the scene
        candidatesParent = GameObject.Find("Candidates");

        if (candidatesParent == null)
        {
            Debug.LogError("Candidates GameObject not found in the scene.");
            return;
        }

        string selectedCharacter = CharacterSelection.SelectedCharacter;

        if (!string.IsNullOrEmpty(selectedCharacter))
        {
            GameObject characterPrefab = GetCharacterPrefab(selectedCharacter);
            if (characterPrefab != null)
            {
                // Instantiate the selected character prefab as a child of the Candidates GameObject
                GameObject characterInstance = Instantiate(characterPrefab, candidatesParent.transform);
                characterInstance.transform.localPosition = Vector3.zero; // Adjust position if necessary
            }
            else
            {
                Debug.LogError("Character prefab not found for: " + selectedCharacter);
            }
        }
        else
        {
            Debug.LogError("No character selected!");
        }
    }

    private GameObject GetCharacterPrefab(string characterName)
    {
        switch (characterName)
        {
            case "Joe Biden":
                return joeBidenPrefab;
            case "Bernie Sanders":
                return bernieSandersPrefab;
            case "Hillary Clinton":
                return hillaryClintonPrefab;
            case "Barack Obama":
                return barackObamaPrefab;
            default:
                return null;
        }
    }
}
