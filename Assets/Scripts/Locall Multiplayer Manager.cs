using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LocallMultiplayerManager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;
    public void onPlayerJoined(PlayerInput player)
    {
        players.Add(player);

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        LocalMutiplayerController controller = player.GetComponent<LocalMutiplayerController>();
        controller.manager = this;
    }

    public void playerAttacking(PlayerInput attackingPlayer)
    {
        for (int i = 0; i < players.Count; i++) 
        {
            if(attackingPlayer == players[i]) continue;

            if(Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position)<0.5f)
            {
                Debug.Log("Player" + attackingPlayer.playerIndex + " attacked player" + players[i].playerIndex);
            }
        }  
    }
}
