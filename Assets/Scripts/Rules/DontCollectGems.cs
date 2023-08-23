using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontCollectGems : MonoBehaviour
{
    RuleController rules;
    CollectiblesTotal total;
    InitializeRules intRules;
    int totalStart;
    // Start is called before the first frame update
    void Start()
    {
        rules = GetComponentInParent<RuleController>();
        total = GameObject.Find("SceneController").GetComponent<CollectiblesTotal>();
        intRules = GameObject.Find("SceneController").GetComponent<InitializeRules>();
        totalStart = total.candy;
    }

    private void Update()
    {
        if(totalStart > total.candy)
        {
            intRules.Death();
            total.candy = totalStart;
        }
    }
}
