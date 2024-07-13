public static class CharacterSelection
{
    public static string SelectedCharacter { get; private set; }

    public static void SelectCharacter(string characterName)
    {
        SelectedCharacter = characterName;
    }
}
