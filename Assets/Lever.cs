using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool isUp;
    [SerializeField] private GameObject up, down;
    [SerializeField] private float timer, maxTimer;
    [SerializeField] private bool isCountingDown;
    // Start is called before the first frame update
    void Start()
    {
        isUp = true;
        up.gameObject.SetActive(true);
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            down.SetActive(false);
            up.gameObject.SetActive(true);
        }
        else
        {
            up.SetActive(false);
            down.SetActive(true);
        }

        if (timer > 0)
        {
            isCountingDown = true;
            timer -= Time.deltaTime;
        }
        else
        {
            isCountingDown = false;
        }
    }

    public void PushDown()
    {
        isUp = false;
    }
    public void PushUp()
    {
        isUp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCountingDown) return;
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Selectable")) return;
        if (isUp)
        {
            PushDown();
            timer = maxTimer;

        }
        else
        {
            PushUp();
            timer = maxTimer;
        }
    }
}
