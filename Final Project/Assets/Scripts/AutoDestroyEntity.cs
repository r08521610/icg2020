using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEntity : MonoBehaviour
{
  [SerializeField] float delay = 0f;
  [SerializeField] Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    if (animator != null) delay += animator.GetCurrentAnimatorClipInfo (0).Length;
    Destroy (gameObject, delay);
  }
}
