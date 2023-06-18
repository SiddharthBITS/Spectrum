using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappelPoint : MonoBehaviour
{
  [SerializeField]
  public int color;
  public static int pointcolor;

  void start()
  {
      pointcolor = color;

  }
  
}
