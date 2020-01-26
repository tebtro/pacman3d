using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacManMovement : MonoBehaviour
{

    enum move_directions
    {
        LEFT,
        RIGHT,
        FORWARD,
        BACKWARD
    }

    private move_directions next_move_direction = move_directions.FORWARD;

    public Rigidbody rbody;
    public float basic_movement_speed = 1.0f;
    public const float rotation_speed = 1.0f;

    private Vector3 direction;

    private readonly float RAY_DISTANCE = 1.0f;
    private readonly bool DEBUG_SHOW_RAY = true;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    //
    // @TODO(rortner): Fix ray starting pos not working when player is rotated
    //
    void Update()
    {
        // Move Player forward every Update
        rbody.velocity = transform.forward * basic_movement_speed;

        if (Input.GetKeyUp(KeyCode.W))
        {
            next_move_direction = move_directions.FORWARD;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            next_move_direction = move_directions.LEFT;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            next_move_direction = move_directions.BACKWARD;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            next_move_direction = move_directions.RIGHT;
        }
        
        if (next_move_direction == move_directions.BACKWARD)
        {
            transform.Rotate(0, 180, 0);
            next_move_direction = move_directions.FORWARD;
        }
        if (next_move_direction == move_directions.LEFT)
        {
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            bool ray1_hit = true;
            {
                Transform ray_transform = transform;
                Vector3 ray_position = transform.TransformPoint(0, 0, 1);
                Vector3 ray_direction = transform.forward;
                ray_direction = Quaternion.AngleAxis(-90, Vector3.up) * ray_direction;

                ray1_hit = Physics.Raycast(ray_position,
                    ray_direction * RAY_DISTANCE,
                    RAY_DISTANCE,
                    layerMask);

                if (DEBUG_SHOW_RAY)
                {
                    //Debug.Log(ray_position);
                    //Debug.Log(ray_direction);
                    Debug.DrawRay(/* origin    */ ray_position /* + offset */,
                          /* direction */ ray_direction * RAY_DISTANCE,
                          Color.red,
                          0.5f);
                }
            }

            bool ray2_hit = true;
            {
                Transform ray_transform = transform;
                Vector3 ray_position = transform.TransformPoint(0, 0, -1);
                Vector3 ray_direction = transform.forward;
                ray_direction = Quaternion.AngleAxis(-90, Vector3.up) * ray_direction;

                ray2_hit = Physics.Raycast(ray_position,
                    ray_direction * RAY_DISTANCE,
                    RAY_DISTANCE,
                    layerMask);

                if (DEBUG_SHOW_RAY)
                {
                    //Debug.Log(ray_position);
                    //Debug.Log(ray_direction);
                    Debug.DrawRay(/* origin    */ ray_position /* + offset */,
                          /* direction */ ray_direction * RAY_DISTANCE,
                          Color.green,
                          0.5f);
                }
            }

            if (!ray1_hit && !ray2_hit)
            {
                transform.Rotate(0, -90, 0);
                next_move_direction = move_directions.FORWARD;
            }
        }
        if (next_move_direction == move_directions.RIGHT)
        {
            // Bit shift the index of the layer (8) to get a bit mask
            int layerMask = 1 << 8;

            // This would cast rays only against colliders in layer 8.
            // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            bool ray1_hit = true;
            {
                Transform ray_transform = transform;
                Vector3 ray_position = transform.TransformPoint(0, 0, 1);
                Vector3 ray_direction = transform.forward;
                ray_direction = Quaternion.AngleAxis(90, Vector3.up) * ray_direction;

                ray1_hit = Physics.Raycast(ray_position,
                    ray_direction * RAY_DISTANCE,
                    RAY_DISTANCE,
                    layerMask);

                if (DEBUG_SHOW_RAY)
                {
                    //Debug.Log(ray_position);
                    //Debug.Log(ray_direction);
                    Debug.DrawRay(/* origin    */ ray_position /* + offset */,
                          /* direction */ ray_direction * RAY_DISTANCE,
                          Color.red,
                          0.5f);
                }
            }

            bool ray2_hit = true;
            {
                Transform ray_transform = transform;
                Vector3 ray_position = transform.TransformPoint(0, 0, -1);
                Vector3 ray_direction = transform.forward;
                ray_direction = Quaternion.AngleAxis(90, Vector3.up) * ray_direction;

                ray2_hit = Physics.Raycast(ray_position,
                    ray_direction * RAY_DISTANCE,
                    RAY_DISTANCE,
                    layerMask);

                if (DEBUG_SHOW_RAY)
                {
                    //Debug.Log(ray_position);
                    //Debug.Log(ray_direction);
                    Debug.DrawRay(/* origin    */ ray_position /* + offset */,
                          /* direction */ ray_direction * RAY_DISTANCE,
                          Color.green,
                          0.5f);
                }
            }

            if (!ray1_hit && !ray2_hit)
            {
                transform.Rotate(0, 90, 0);
                next_move_direction = move_directions.FORWARD;
            }
        }
    }
}
