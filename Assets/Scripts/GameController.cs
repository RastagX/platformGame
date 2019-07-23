using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text tex_life, tex_coin;
    //private Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var player = Player.FindObjectOfType<Player>();
        tex_life.text = player.life.ToString();
        tex_coin.text = player.score.ToString();
    }
}
