using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YScrollLoop : MonoBehaviour
{
  private Vector3 startPosition;
  [field: SerializeField]
  private Vector3 loopPosition { get; set; }

    // Start is called before the first frame update
    void Start()
    {
      startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

      // transform.Rotate(v, h, 0);
      transform.Translate(new Vector3(0, 8 * Time.deltaTime, 0));
      // Debug.Log(transform.localPosition.y);
      if(transform.localPosition.y >= loopPosition.y)
      {
        Debug.LogError("LOOP");
        transform.localPosition = startPosition;
        return;
      }
    }
}
