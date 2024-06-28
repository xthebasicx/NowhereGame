using System.Collections;
using UnityEngine;
using TMPro;

public class CallDialogue : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject E;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool playerIsClose;
    private bool isTyping;

    void Start()
    {
        if (dialogue != null)
        {
            dialogue.SetActive(false);
        }
        if (E != null)
        {
            E.SetActive(false);
        }

    }

    void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogue != null && !dialogue.activeInHierarchy)
            {
                dialogue.SetActive(true);
                StartCoroutine(TypeLine());
            }
        }

        if (dialogue != null && dialogue.activeInHierarchy && Input.GetMouseButtonDown(0) && !isTyping)
        {
            NextLine();
        }
    }

    private void ZeroText()
    {
        if (textComponent != null)
        {
            textComponent.text = string.Empty;
        }
        index = 0;
        if (dialogue != null)
        {
            dialogue.SetActive(false);
        }
    }

    private IEnumerator TypeLine()
    {
        if (textComponent != null && lines != null && lines.Length > index)
        {
            isTyping = true;
            textComponent.text = string.Empty;

            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            isTyping = false;
        }
    }

    private void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            ZeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            E.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            E.SetActive(false);
            ZeroText();
        }
    }
}
