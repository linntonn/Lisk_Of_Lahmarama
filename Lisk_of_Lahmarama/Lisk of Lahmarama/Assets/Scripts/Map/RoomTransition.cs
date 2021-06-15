using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    enum Direction {
        
        [InspectorName("Horizontal Direction (Right = 0; Left = 1)")]
        Horizontal,
        [InspectorName("Vertical Direction (Up = 0; Down = 1)")]
        Vertical};

    [SerializeField]
    private Direction transitionDirection = Direction.Horizontal;

    [SerializeField]
    private CameraControls mainCamera;

    [SerializeField]
    private Transform[] newCameraPositions = new Transform[2];

    [SerializeField]
    private Transform[] newPlayerPositions = new Transform[2];

    [SerializeField]
    private Room rightRoom;

    [SerializeField]
    private Room leftRoom;

    [SerializeField]
    private float waitTime = 2.0f;

    public bool immediateTransition = false;

    private float transitionTimer = -1;
    private bool cameraMoving = false;
    private bool movingRight = false;
    private List<PlayerInput> playersInTrigger = new List<PlayerInput>();

    private List<PlayerInput> playerInputScripts;

    private void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playerInputScripts = new List<PlayerInput>();
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<PlayerInput>() != null)
                playerInputScripts.Add(players[i].GetComponent<PlayerInput>());
        }
    }

    private void Update()
    {
        if (transitionTimer == -1)
            return;

        if (transitionTimer <= 0)
        {
            if (cameraMoving == false)
            {
                for (int i = 0; i < playerInputScripts.Count; i++)
                {
                    playerInputScripts[i].enabled = false;
                    StartCoroutine(LerpPlayer(playerInputScripts[i].gameObject));
                    
                }
                cameraMoving = true;
                mainCamera.setMoving(cameraMoving);
                StartCoroutine(LerpCamera());
                despawnOldEnemies();
                respawnNewEnemies();
            }

        }
        else
        {
            transitionTimer -= Time.deltaTime;
        }
    }

    private void despawnOldEnemies()
    {
        List<SpawnPoint> spawns = leftRoom.enemySpawns;
        if (!movingRight)
        {
            spawns = rightRoom.enemySpawns;
        }

        foreach (SpawnPoint sp in spawns)
        {
            sp.despawn();
        }
    }

    private void respawnNewEnemies()
    {
        List<SpawnPoint> spawns = rightRoom.enemySpawns;
        if (!movingRight)
        {
            spawns = leftRoom.enemySpawns;
        }

        foreach (SpawnPoint sp in spawns)
        {
            sp.respawn();
        }
    }

    IEnumerator LerpCamera()
    {
        float time = 0;
        Vector3 startPosition = mainCamera.transform.position;
        Vector3 newCameraPosition = newCameraPositions[0].position;
        bool scrollHor = rightRoom.scrollHorizontal;
        bool scrollVer = rightRoom.scrollVertical;
        List<float> newBarriers = rightRoom.getLimits();
        if (!movingRight)
        {
            newCameraPosition = newCameraPositions[1].position;
            scrollHor = leftRoom.scrollHorizontal;
            scrollVer = leftRoom.scrollVertical;
            newBarriers = leftRoom.getLimits();
        }

        while (time < waitTime)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, newCameraPosition, time / waitTime);
            time += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = newCameraPosition;
        cameraMoving = false;
        mainCamera.setMoving(cameraMoving);
        foreach (PlayerInput p in playerInputScripts)
        {
            if (p != null)
                p.enabled = true;
        }
        mainCamera.UpdateMovement(scrollHor, scrollVer, newBarriers);
        transitionTimer = -1;
    }

    IEnumerator LerpPlayer(GameObject player)
    {
        float time = 0;
        Vector3 startPosition = player.transform.position;
        Vector3 newPlayerPosition = newPlayerPositions[0].position;
        if (!movingRight)
        {
            newPlayerPosition = newPlayerPositions[1].position;
        }
        while (time < waitTime)
        {
            player.transform.position = Vector3.Lerp(startPosition, newPlayerPosition, time / waitTime);
            time += Time.deltaTime;
            yield return null;
        }

        player.transform.position = newPlayerPosition;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            PlayerInput playerInBox = other.gameObject.GetComponent<PlayerInput>();
            if (!playersInTrigger.Contains(playerInBox))
                playersInTrigger.Add(playerInBox);

            if (transitionDirection == Direction.Horizontal)
            {
                if (other.transform.rotation.y > 0)
                    movingRight = true;
                else
                    movingRight = false;
            }
            else if (transitionDirection == Direction.Vertical)
            {
                if (playerInBox.moveDirection.y > 0)
                    movingRight = true;
                else
                    movingRight = false;
            }
            if (playersInTrigger.Count == playerInputScripts.Count || immediateTransition)
                transitionTimer = 0;
            else
                transitionTimer = waitTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            PlayerInput playerInBox = other.gameObject.GetComponent<PlayerInput>();
            if (playersInTrigger.Contains(playerInBox))
            {
                playersInTrigger.Remove(playerInBox);
            }

            if (playersInTrigger.Count == 0)
                transitionTimer = -1;
        }
    }
}
