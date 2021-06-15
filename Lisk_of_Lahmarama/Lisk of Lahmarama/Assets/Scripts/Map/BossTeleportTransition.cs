using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleportTransition : MonoBehaviour
{

    [SerializeField]
    private GameObject bossHealthBar;
    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private Transform newCameraPosition;
    [SerializeField]
    private Transform newPlayerPosition;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;

    private void Awake()
    {
        bossHealthBar.SetActive(false);
        boss.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player1.GetComponent<CharacterController>().enabled = false;
            player2.GetComponent<CharacterController>().enabled = false;
            player1.transform.position = newPlayerPosition.position;
            player2.transform.position = newPlayerPosition.position;
            player1.GetComponent<CharacterController>().enabled = true;
            player2.GetComponent<CharacterController>().enabled = true;
            mainCamera.transform.position = newCameraPosition.position;
            mainCamera.GetComponent<CameraControls>().UpdateMovement(false, false, new List<float> { 0, 0, 0, 0 });
            bossHealthBar.SetActive(true);
            boss.SetActive(true);
        }
    }
}
