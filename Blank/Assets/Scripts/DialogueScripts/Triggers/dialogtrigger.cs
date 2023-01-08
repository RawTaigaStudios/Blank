using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class dialogtrigger : MonoBehaviour
{
    public Conversation convo;

    public UnityEvent dialogueStart;
    public UnityEvent dialogueEnded;
    // Start is called before the first frame update
    void Start()
    {

        if (convo.canRepeat)
        {
            convo.hasPlayed = false;
        }
        if(convo.hasPlayed == false && convo.playOnStart)
        {
            StartCoroutine(ConversationStartedDelay());
            DialogueManager.StartConversation(convo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (convo.hasPlayed)
        {
            dialogueEnded.Invoke();
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dialogueStart.Invoke();
            Debug.Log("Encontrado player");
            convo.hasPlayed = false;
            DialogueManager.instance.canSkipDialogue = true;
            DialogueManager.StartConversation(convo);
            //StartCoroutine(ConversationStartedDelay());
            Debug.Log(DialogueManager.instance.canSkipDialogue);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public IEnumerator ConversationStartedDelay()
    {
        DialogueManager.instance.canSkipDialogue = false;

        yield return new WaitForSeconds(0.2f);

        DialogueManager.instance.canSkipDialogue = true;
    }
}
