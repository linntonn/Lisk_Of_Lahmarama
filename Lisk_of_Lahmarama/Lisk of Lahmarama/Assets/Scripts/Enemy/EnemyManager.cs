using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int level;
    public float healthMAX;
    public float health;
    public int atk;
    public int def;
    public int speed;

    public List<Collider> hitboxes;
    public List<Collider> attackHitboxes;
    public List<Renderer> mesh;

    public bool enemyAI_PLACEHOLDER;
    public bool enemyAction_PLACEHOLDER;
    public int EnemyAICommand = 0; //Tells whether or not to stop moving forward or to jump

    public int biomeType;
    public List<bool> drops_PLACEHOLDER;
    public List<float> dropRates;

    public List<GameObject> droppedItem;
    public Transform dropSpawn;

    public bool damaged;
    public float damagedTimer = 0.7f;
    private float damagedCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (damaged)
        {
            damagedCounter -= Time.deltaTime;
            if (damagedCounter <= 0)
            {
                foreach (Renderer r in mesh)
                {
                    r.enabled = true;
                }
                damaged = false;
            }
            else
            {
                foreach (Renderer r in mesh)
                {
                    r.enabled = !r.enabled;
                }
            }
        }

        if (health <= 0)
        {
            int j = -1;
            foreach (int i in dropRates)
            {
                j += 1;
                if (Random.Range(0, 11) > dropRates[j])
                {
                    Vector3 pos = transform.position;
                    Quaternion rotation = transform.rotation;
                    GameObject ObjectToInstantiate = droppedItem[j];
                    Instantiate(ObjectToInstantiate, pos, rotation);
                }
            }
            
            Destroy(this.gameObject);
        }
    }
    public void HurtEnemy(float damage)
    {
        health -= damage;
        damaged = true;
        damagedCounter = damagedTimer;
    }
    void OnDestroy()
    {
    }
}
