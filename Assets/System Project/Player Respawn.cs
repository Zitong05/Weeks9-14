using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;
    public CinemachineImpulseSource impulseSource;


    public float DisappearTime = 3f;
    public float respawnDelay = 1f;

    public Coroutine respawnCoroutine;
    public bool isRespawning = false;

    public void PlayerEnteredLight()
    {
        if (respawnCoroutine != null)
        {
            StopCoroutine(respawnCoroutine);
            respawnCoroutine = null;
        }
    }

    public void PlayerExitedLight()
    {
        if (respawnCoroutine == null && !isRespawning)
        {
            respawnCoroutine = StartCoroutine(RespawnRoutine());
        }
    }

    public IEnumerator RespawnRoutine()
    {
        float timer = 0f;

        while (timer < DisappearTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        isRespawning = true;

        //player disappears and generates impulse
        player.SetActive(false);
        impulseSource.GenerateImpulse();

        //wait for 1 second to respawn
        yield return new WaitForSeconds(respawnDelay);

        // reset player position
        player.transform.position = respawnPoint.position;


        //player appears
        player.SetActive(true);

        isRespawning = false;
        respawnCoroutine = null;
    }
}
