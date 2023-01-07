using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    [HideInInspector]
    public bool canSkipDialogue = true;

    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    //public Image speakerSprite;
    [HideInInspector]
    public static bool Talking = false;
    [HideInInspector]
    public int currentIndex;
    public static DialogueManager instance;

    [HideInInspector]
    public Conversation currentConvo;

    [HideInInspector]
    public Animator anime;


    void Awake()//intenta llamar al componente del animador cada vez que se activa este script
    {
        if (instance == null)// comprueba que no haya otra instancia de este objeto activa(Singleton)
        {
            instance = this;//si no la hay crea una nueva y llama al animator
            anime = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);//si SI la hay, la destruye
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Talking && canSkipDialogue)
        {
            Debug.Log("Triggered");
            ReadNext();
            //dialogtrig.Invoke();

        }
    }

    
    public static void StartConversation(Conversation convo)//funci?n comenzar conversaci?n
    {
        Talking = true;//activa el bool que usamos para determinar si se puede mover el personaje o no
        instance.anime.SetBool("DialogueOn", true);//activa el bool del animador en una instancia
        instance.currentIndex = 0;//se va al index 0 (posici?n en el array/lista/queue) de la conversaci?n en la que estemos
        instance.currentConvo = convo;//llama a la conversaci?n que nosotros determinemos en el inspector
        instance.speakerName.text = "";//vacia el nombre del hablante para que se pueda instanciar con el guardado en la conversaci?n
        instance.dialogue.text = "";//hace lo mismo que la variable anterior pero con el texto del di?logo
        instance.anime.SetBool("IsInTransition", true);
        
        // instance.navButtonText.text = "Continue";//iguala el texto guardado en el bot?n a Continue para asegurarse que es ese bot?n

        Debug.Log("start");
        instance.ReadNext();//llama a una instancia de la funci?n ReadNext
    }


    public void ReadNext()//funci?n para leer la siguiente linea
    {
        Debug.Log("middle1");
        
            if (currentIndex > currentConvo.GetLength())//comprueba que  la converasci?n no se haya acabado 
            {
            Debug.Log("End");
                currentConvo.hasPlayed = true;
                instance.anime.SetBool("DialogueOn", false);//si SI lo ha hecho desactiva el booleano del animador
                Talking = false;//tambi?n el booleano del movimiento
                return;//se sale de la funci?n
            }
            //si no se ha acabado continua

            speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();//iguala el texto del nombre del hablante al que sea en el index de la conversaci?n en la que se encuentre
            dialogue.text = currentConvo.GetLineByIndex(currentIndex).dialogue;// hace lo mismo pero con el di?logo
            //speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();// hace lo mismo pero con el sprite
                                                                                                 //el llamar a speakerName y speakerSprite acaban en GetName y GetSprite por que son un objeto distinto de la conversaci?n que es llamado POR la conversaci?n
            currentIndex++;// le suma 1 al index de la conversaci?n para pasar a la siguiente linea
        Debug.Log("Middle2");
    }
}
