using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthmagic : MonoBehaviour
{
    public GameObject eMagicl;
    public GameObject p1;
    public Rigidbody p1r;
    public GameObject p2;
    public Rigidbody p2r;
    public GameObject p3;
    public Rigidbody p3r;
    public Transform p1end;
    public Transform p2end;
    public Transform p3end;

    public float p1Timer;
    public float p2Timer;
    public float p3Timer;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        eMagicl.transform.SetParent(null, true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.deltaTime;
        p1.SetActive(true);
        p1r.velocity = new Vector3(0, 25, 0);
        if (counter > .15f)
        {
            p1r.velocity = Vector3.zero;
        }

        if (counter > .15f)
        {
            p2.SetActive(true);
            p2r.velocity = new Vector3(0, 25, 0);
        }
        if (counter > .3f)
        {
            p2r.velocity = Vector3.zero;
        }

        if (counter > .3f)
        {
            p3.SetActive(true);
            p3r.velocity = new Vector3(0, 25, 0);
        }
        if (counter > .45f)
        {
            p3r.velocity = Vector3.zero;
        }
        if (counter > 0.7f)
        {
            Destroy(eMagicl);
        }
    }
}
