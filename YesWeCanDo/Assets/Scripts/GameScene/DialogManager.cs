using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogClip
    {
        public AudioClip clip;
        public float delayAfterClip;
    }

    public DialogClip[] generalDialogClips;
    public DialogClip[] bidenDialogClips;
    public DialogClip[] sandersDialogClips;
    public DialogClip[] clintonDialogClips;
    public DialogClip[] obamaDialogClips;

    public Button skipButton;

    private AudioSource audioSource;
    private bool isSkipping = false;
    private float skipTime = 5f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        skipButton.onClick.AddListener(SkipDialog);
        StartCoroutine(PlayDialog());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isSkipping)
            {
                StartCoroutine(CheckForSkip());
            }
        }
        else
        {
            StopCoroutine(CheckForSkip());
            isSkipping = false;
        }
    }

    private IEnumerator CheckForSkip()
    {
        isSkipping = true;
        yield return new WaitForSeconds(skipTime);

        if (isSkipping)
        {
            SkipDialog();
        }
        isSkipping = false;
    }

    private IEnumerator PlayDialog()
    {
        DialogClip[] selectedDialogClips = GetSelectedDialogClips();

        foreach (DialogClip clip in generalDialogClips)
        {
            yield return PlayClip(clip);
        }

        foreach (DialogClip clip in selectedDialogClips)
        {
            yield return PlayClip(clip);
        }
    }

    private IEnumerator PlayClip(DialogClip dialogClip)
    {
        audioSource.clip = dialogClip.clip;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);
        yield return new WaitForSeconds(dialogClip.delayAfterClip);
    }

    private DialogClip[] GetSelectedDialogClips()
    {
        switch (CharacterSelection.SelectedCharacter)
        {
            case "Joe Biden":
                return bidenDialogClips;
            case "Bernie Sanders":
                return sandersDialogClips;
            case "Hillary Clinton":
                return clintonDialogClips;
            case "Barack Obama":
                return obamaDialogClips;
            default:
                return new DialogClip[0];
        }
    }

    public void SkipDialog()
    {
        StopAllCoroutines();
        audioSource.Stop();
        // Hier kannst du die Logik für das Ende des Dialogs hinzufügen, z.B. eine neue Szene laden oder das Interface aktualisieren
    }
}
