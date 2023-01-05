using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class dialogtrigger : MonoBehaviour
{
    public Conversation convo;

    public UnityEvent dialogueEvents;
    // Start is called before the first frame update
    void Start()
    {
        if (convo.canRepeat)
        {
            convo.hasPlayed = false;
            StartCoroutine(ConversationStartedDelay());
            DialogueManager.StartConversation(convo);
        }
        else if(!convo.canRepeat || convo.hasPlayed == false)
        {
            StartCoroutine(ConversationStartedDelay());
            DialogueManager.StartConversation(convo);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public IEnumerator ConversationStartedDelay()
    {
        DialogueManager.instance.canSkipDialogue = false;

        yield return new WaitForSeconds(DialogueManager.instance.anime.GetCurrentAnimatorStateInfo(0).normalizedTime);

        DialogueManager.instance.canSkipDialogue = true;
    }
}
