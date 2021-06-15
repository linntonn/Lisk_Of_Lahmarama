using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectList : MonoBehaviour
{
    // Start is called before the first frame update
    IDictionary<string, effect> effectList;
    delegate IEnumerator effect();

    public float hpPerTick = 5f;
    public float damageBoost = 10f;
    public float mDamageBoost = 10f;
    public float defenseBoost = 10f;
    //public float testBoost = 10f;

    public float duration = 20f;

    void Start()
    {
        effectList = new Dictionary<string, effect>()
        {
            {"Regeneration", regen},
            {"Damage Boost", damage},
            {"Magic Damage Boost", mDamage},
            {"Defense Boost", defense}
        };
    }

    public void doEffect(string effect)
    {
        StartCoroutine(effectList[effect]());
    }

    /**
    IEnumerator test()
    {
        gameObject.GetComponent<TestScript>().change(testBoost);
        yield return new WaitForSeconds(20f);
        gameObject.GetComponent<TestScript>().change(-testBoost);
    }
    **/

    IEnumerator regen()
    {
        for(int i = 0; i < duration; i++)
        {
            gameObject.GetComponent<PlayerInput>().hurtPlayer(-hpPerTick);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator damage()
    {
        gameObject.GetComponent<PlayerInput>().statChange("atk", damageBoost);
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<PlayerInput>().statChange("atk", -damageBoost);
    }

    IEnumerator mDamage()
    {
        gameObject.GetComponent<PlayerInput>().statChange("mag", mDamageBoost);
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<PlayerInput>().statChange("mag", -mDamageBoost);
    }

    IEnumerator defense()
    {
        gameObject.GetComponent<PlayerInput>().statChange("def", defenseBoost);
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<PlayerInput>().statChange("def", -defenseBoost);
    }

}
