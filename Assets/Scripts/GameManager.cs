using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ChatGPTWrapper;

//The credit to most of this code goes to what we learned in class. Admitfully, I mostly just followed along, but did try to make my own changes here and there.
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    ChatGPTConversation chatGPT;

    [SerializeField]
    TMP_InputField if_PlayerTalk;
    [SerializeField]
    TextMeshProUGUI tx_AIReply;
   
    [SerializeField]
    NPCController npc; 

    string npcName = "Mimi";
    string playerName = "Human";

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        chatGPT.Init();
    }

    private void Start()
    {
        chatGPT.SendToChatGPT("{\"player_said\":"+"\"Hi. Who are you and what are you doing?\"}");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonUp("Submit"))
        {
            SubmitChatMessage();
        }
    }

    //Callback from ai
    public void ReceiveChatGPTReply(string message) //keeping things bug free
    {
        try
        {
            if (!message.EndsWith("}")) //Ai messed stuff up
            {
                if (message.Contains("}"))
                {
                    message = message.Substring(0, message.LastIndexOf("}") + 1);
                }
                else
                {
                    message += "}";
                }
            }
            message = message.Replace("\\", "\\\\");
            NPCJsonReceiver npcJSON = JsonUtility.FromJson<NPCJsonReceiver>(message);
            string talkLine = npcJSON.reply_to_player;
            tx_AIReply.text = "<color=#ff7082>" + npcName + ": </color>" + talkLine;
            npc.ShowAnimation(npcJSON.animation_name); //gives the animation she wants to play
        }
        catch(System.Exception e) 
        {
            Debug.Log(e.Message);
            string talkLine = "Don't say that!";
        }


    }

    public void SubmitChatMessage() 
    {
        Debug.Log("Message sent: " + if_PlayerTalk);
        chatGPT.SendToChatGPT("{\"player_said\":\"" + if_PlayerTalk.text + "\"}");
        ClearText();
    }

    void ClearText()
    {
        if_PlayerTalk.text = "";
    }
}
