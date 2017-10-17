using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour {
	public LayerMask collideMask;
	public int numberOfRaycast;

	private BoxCollider2D boxCollider;
	private float skinWidth = 0.01f;
	private float raySpacingHorizontal;
	private float raySpacingVertical;

	private RaycastOrigins raycastOrigins = new RaycastOrigins();

	private Vector2 topLeftOffset;
	private Vector2 topRightOffset;
	private Vector2 bottomLeftOffset;
	private Vector2 bottomRightOffset;
	
	void Awake()
	{
		boxCollider = GetComponent<BoxCollider2D>();
		InitRaycastOriginsOffset();
	}

	void InitRaycastOriginsOffset(){
		Bounds colliderBounds = boxCollider.bounds;
		colliderBounds.Expand(-skinWidth);

		topRightOffset = colliderBounds.max.xy() - transform.position.xy();
		bottomLeftOffset = colliderBounds.min.xy() - transform.position.xy();
		topLeftOffset = colliderBounds.max.xy().WithX(colliderBounds.min.x) - transform.position.xy();
		bottomRightOffset = colliderBounds.min.xy().WithX(colliderBounds.max.x) - transform.position.xy();

		numberOfRaycast = Mathf.Max(2, numberOfRaycast);
		raySpacingHorizontal = colliderBounds.extents.x * 2 / (numberOfRaycast-1);
		raySpacingVertical = colliderBounds.extents.y * 2 / (numberOfRaycast-1);
	}

	void UpdateRaycastOrigins(Vector2 currentPosition){
		raycastOrigins.topLeft = topLeftOffset + currentPosition;
		raycastOrigins.bottomLeft = bottomLeftOffset + currentPosition;
		raycastOrigins.topRight = topRightOffset + currentPosition;
		raycastOrigins.bottomRight = bottomRightOffset + currentPosition;
	}

	public PlayerState Move(Vector2 currentPosition, Vector2 currentVelocity){
		UpdateRaycastOrigins(currentPosition);

			PlayerState result = new PlayerState() {
			position = currentPosition,
			velocity = currentVelocity,
			collidingLeft = false,
			collidingRight = false,
			collidingTop = false,
			collidingBottom = false
		};

		result = MoveHorizontal(result);
		result = MoveVertical(result);

		result.position += result.velocity;
		return result;
	}

	public PlayerState MoveHorizontal(PlayerState playerState){
		Vector2 rayOrigin = (playerState.velocity.x > 0) ? raycastOrigins.bottomRight : raycastOrigins.bottomLeft;

		for(int i=0; i < numberOfRaycast;i++){
			RaycastHit2D hit = Physics2D.Raycast(
				rayOrigin + Vector2.up * i * raySpacingVertical,
				playerState.velocity.WithY(0),
				playerState.velocity.WithY(0).magnitude + skinWidth,
				collideMask
			);

			Debug.DrawRay(rayOrigin + Vector2.up * i * raySpacingVertical, playerState.velocity.WithY(0), Color.red, 1);

			if(hit){
				playerState.collidingLeft = playerState.velocity.x < 0;
				playerState.collidingRight = playerState.velocity.x > 0;
				playerState.velocity.x = Mathf.Sign(playerState.velocity.x) * (hit.distance - skinWidth);
			}
		}

		return playerState;
	}

	public PlayerState MoveVertical(PlayerState playerState){
		Vector2 rayOrigin = (playerState.velocity.y > 0) ? raycastOrigins.topLeft : raycastOrigins.bottomLeft;

		for (int i = 0; i < numberOfRaycast; i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(
				rayOrigin + Vector2.right * i * raySpacingHorizontal, 
				playerState.velocity.WithX(0),
				playerState.velocity.WithX(0).magnitude + skinWidth,
				collideMask
			);

			Debug.DrawRay(rayOrigin + Vector2.right * i * raySpacingHorizontal, playerState.velocity.WithX(0), Color.red, 1);

			if(hit){
				playerState.collidingTop = playerState.velocity.y > 0;
				playerState.collidingBottom = playerState.velocity.y < 0;
				playerState.velocity.y = Mathf.Sign(playerState.velocity.y) * (hit.distance - skinWidth);
			}
		}

		return playerState;
	}
}

public struct PlayerState {
	public Vector2 position;
	public Vector2 velocity;
	public bool collidingLeft;
	public bool collidingRight;
	public bool collidingTop;
	public bool collidingBottom;
}

public struct RaycastOrigins {
	public Vector2 topLeft;
	public Vector2 topRight;
	public Vector2 bottomLeft;
	public Vector2 bottomRight;
}
