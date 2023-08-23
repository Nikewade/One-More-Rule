using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGems : MonoBehaviour
{
    RuleController rules;
    CollectiblesTotal total;
    // Start is called before the first frame update
    void Start()
    {
        rules = GetComponentInParent<RuleController>();
        total = GameObject.Find("SceneController").GetComponent<CollectiblesTotal>();
        rules.canWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (total.candy <= 0)
        {
            rules.canWin = true;
        }
    }
}
