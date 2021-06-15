using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{

    private List<GameObject> players;
    [SerializeField]
    private float cameraMoveSpeed = 5f;

    [SerializeField]
    private bool scrollHorizontal = false;
    [SerializeField]
    private bool scrollVertical = false;

    [SerializeField]
    private Room initialRoom;

    [SerializeField]
    private float rightBarrier;

    [SerializeField]
    private float leftBarrier;

    [SerializeField]
    private float topBarrier;
    [SerializeField]
    private float bottomBarrier;

    public float verticalOffset;

    public float stopScrollDistanceX;
    public float stopScrollDistanceY;

    public float maxPlayerDistanceY;

    public bool noBarriers = true;

    private bool isMoving = false;

    private bool tempBlockScrollingVert = false;
    private bool tempBlockScrollingHor = false;

    private bool initialEnemySpawnsCorrect = false;

    private void Awake()
    {
        if (initialRoom != null)
        {
            UpdateMovement(initialRoom.scrollHorizontal, initialRoom.scrollVertical, initialRoom.getLimits());
        }
        players = new List<GameObject>();
        GameObject[] allPlayerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in allPlayerObjects)
        {
            if (g.GetComponent<PlayerInput>() != null)
            {
                players.Add(g);
            }
        }
        if (scrollHorizontal || scrollVertical)
        {
            noBarriers = false;
        }
    }

    public void UpdateMovement(bool hor, bool ver, List<float> newBarriers)
    {
        scrollHorizontal = hor;
        scrollVertical = ver;
        if (newBarriers == null)
        {
            scrollHorizontal = false;
            scrollVertical = false;
            removeBarriers();
            return;
        }

        if (newBarriers.Count == 0)
        {
            removeBarriers();
            return;
        }
        
        else if (hor && ver)
        {
            noBarriers = false;
            rightBarrier = newBarriers[0];
            leftBarrier = newBarriers[1];
            topBarrier = newBarriers[2];
            bottomBarrier = newBarriers[3];
        }
        else if (hor)
        {
            noBarriers = false;
            rightBarrier = newBarriers[0];
            leftBarrier = newBarriers[1];
        }
        else if (ver)
        {
            noBarriers = false;
            topBarrier = newBarriers[0];
            bottomBarrier = newBarriers[1];
        }
    }

    public void removeBarriers()
    {
        noBarriers = true;
    }

    public void setMoving(bool moving)
    {
        isMoving = moving;
    }

    public void Update()
    {
        if (!initialEnemySpawnsCorrect)
        {
            if (initialRoom != null)
            {
                foreach (SpawnPoint sp in initialRoom.enemySpawns)
                {
                    sp.respawn();
                }
            }
            initialEnemySpawnsCorrect = true;
        }
        if (isMoving)
        {
            return;
        }

        CheckPlayerPositions();

        float newXPos = transform.position.x;

        if (scrollHorizontal && !tempBlockScrollingHor)
        {

            float avgx = 0;
            foreach (GameObject p in players)
            {
                avgx += p.transform.position.x;
            }
            avgx /= players.Count;
            if (!noBarriers)
            {
                avgx = Mathf.Clamp(avgx, leftBarrier, rightBarrier);
            }
            newXPos = avgx;
        }

        float newYPos = transform.position.y;

        if (scrollVertical && !tempBlockScrollingVert)
        {
            float avgy = 0;
            foreach (GameObject p in players)
            {
                avgy += p.transform.position.y;
            }
            avgy /= players.Count;
            avgy += verticalOffset;
            if (!noBarriers)
            {
                avgy = Mathf.Clamp(avgy, bottomBarrier, topBarrier);
            }
            newYPos = avgy;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3 (newXPos, newYPos, transform.position.z), cameraMoveSpeed * Time.deltaTime);
    }

    private void CheckPlayerPositions()
    {

        GameObject player1 = players[0];
        GameObject player2 = players[1];

        float xDist = Vector3.Distance(new Vector3 (player1.transform.position.x, 0, 0), new Vector3 (player2.transform.position.x, 0, 0));
        float yDist = Vector3.Distance(new Vector3(0, player1.transform.position.y, 0), new Vector3(0, player2.transform.position.y, 0));

        PlayerInput p1PlayerInput = player1.GetComponent<PlayerInput>();
        PlayerInput p2PlayerInput = player2.GetComponent<PlayerInput>();

        if (yDist >= maxPlayerDistanceY && (p1PlayerInput.moveDirection.y < p1PlayerInput.baseWeight || p2PlayerInput.moveDirection.y < p2PlayerInput.baseWeight))
        {
            if (p1PlayerInput.moveDirection.y < p2PlayerInput.moveDirection.y && player1.transform.position.y < player2.transform.position.y)
            {
                player1.GetComponent<CharacterController>().enabled = false;
                player1.transform.position = new Vector3 (player2.transform.position.x + 0.5f, player2.transform.position.y, player2.transform.position.z);
                player1.GetComponent<CharacterController>().enabled = true;
            }
            else if (p1PlayerInput.moveDirection.y > p2PlayerInput.moveDirection.y && player1.transform.position.y > player2.transform.position.y)
            {
                player2.GetComponent<CharacterController>().enabled = false;
                player2.transform.position = new Vector3 (player1.transform.position.x + 0.5f, player1.transform.position.y, player1.transform.position.z);
                player2.GetComponent<CharacterController>().enabled = true;
            }
        }


        if (xDist >= stopScrollDistanceX)
        {
            tempBlockScrollingHor = true;
        }
        else if (xDist < stopScrollDistanceX)
        {
            tempBlockScrollingHor = false;
        }

        if (yDist >= stopScrollDistanceY)
        {
            tempBlockScrollingVert = true;
        }
        else if (yDist < stopScrollDistanceY)
        {
            tempBlockScrollingVert = false;
        }

    }
}
