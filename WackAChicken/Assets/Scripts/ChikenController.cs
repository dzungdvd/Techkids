using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenController : MonoBehaviour
{

  public float speed;
  public GameObject target;
  private Controller2D controller2D;

  void Awake()
  {
    controller2D = GetComponent<Controller2D>();
  }
  void Start()
  {
    target = GameplayManager.instance.GetRandomCabbage();
  }

	public void Die(){
		gameObject.SetActive(false);
	}

  void Update()
  {
    transform.position = controller2D.Move(
      transform.position,
      (target.transform.position - transform.position).ScaleTo(speed)
    ).position;
  }
}
