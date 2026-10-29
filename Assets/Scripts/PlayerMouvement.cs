using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Key leftKey = Key.A;
    [SerializeField] private Key rightKey = Key.D;
    [SerializeField] private Key downKey = Key.S;
    [SerializeField] private Key upKey = Key.W;
    
    private Rigidbody2D body;
    private Vector2 playerDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerDirection = ReadPlayerDirection();
    }

    void FixedUpdate()
    {
        body.linearVelocity = playerDirection * speed;
        float angle = AngleOf(playerDirection);
        if(playerDirection != Vector2.zero)
        {
            body.rotation = angle;
        }
    }

    
    private Vector2 ReadPlayerDirection()
    {
        Keyboard keyboard = Keyboard.current;
        float horizontalAxis = AxisValue(keyboard, leftKey, rightKey);
        float verticalAxis = horizontalAxis != 0 ? 0f : AxisValue(keyboard, downKey, upKey);
        return new Vector2(horizontalAxis, verticalAxis).normalized;
    }
    private static float AxisValue(Keyboard keyboard, Key negativeKey, Key positiveKey)
    {
        float value = 0f;
        if (keyboard[negativeKey].isPressed) value -= 1f;
        if (keyboard[positiveKey].isPressed) value += 1f;
        return value;
    }

    private static float AngleOf(Vector2 dir) => Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
}
