using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // Start is called before the first frame update


    private SpriteRenderer self;

    void Start()
    {
        self = GetComponent<SpriteRenderer>();
        StartCoroutine(Gone());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Gone()
    {
        float time = 1;
        while(time > 0)
        {
            time -= Time.deltaTime * 0.5f;
            self.color = new Color(self.color.r, self.color.g, self.color.b, time);
            yield return null;
        }
        Destroy(gameObject);
    }
}
