using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicTalk : MonoBehaviour
{
    [TextArea(2, 3)]
    public List<string> helloTalk; //falas usadas quando o jogador chega na sala
    [TextArea(2, 3)]
    public List<string> clickTalk;  ///falas usadas quando o jogador clica no Mimic
    [TextArea(2, 3)]
    public List<string> randomTalk; //falas usadas aleatoriamente quando o jogador fica parado 
    [TextArea(2, 3)]
    public List<string> goodbyTalk;  //falas usadas quando o jogador vai pra aventura 
}
