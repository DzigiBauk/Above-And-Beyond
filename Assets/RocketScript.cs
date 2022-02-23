using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{
    //Audio
    public AudioSource thrusterSound;

    //UI
    public Text fuelLabel;
    public Text heightLabel;
    public Text moneyLabel;

    //Promenljive za kontrole
    public float maxHeight = 1000;
    public float height = 0;
    public float thrust = 0;
    public float maxThrust = 0;
    public float rotateSpeed = 100;
    public float maxFuel = 100;
    public float fuel;
    public float acceleration = 0;
    public int truePos = 0;

    //Sistemi
    public ParticleSystem thrustParticle;
    public playerScript player;
    Rigidbody2D rb;

    //UI
    public Slider fuelBar;
    public Slider heightBar;

    Vector3 startPos;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        setMaxBar();
        player.setStats();

        maxThrust = player.maxThrust;
        maxFuel = player.rocketMaxFuel;
        acceleration = player.rocketAcceleration;
        fuel = maxFuel;
    }

    void Awake()
    {
        player.setSprite();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Money Update
        moneyLabel.text = "MONEY: " + player.getMoney();

        //Fuel Check
        if (fuel > 0)
        {
            rb.AddForce(transform.up * thrust);
            
        } else { thrust = 0; fuel = 0; }

        //Fuel Label Update
        fuelLabel.text = "FUEL: " + fuel;

        //Height Label Update
        if ((int)transform.localPosition.y - (int)startPos.y > truePos)
        {
            truePos = (int)transform.localPosition.y - (int)startPos.y;
        }
        if (truePos < 0) { truePos = 0; }
        height = truePos;
        heightLabel.text = "HEIGHT: " + truePos;
        setHeightBar();


        //Rotations
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
        }

        if (thrust > 0)
        {
            fuel = fuel - thrust / 100;
        }

        //Fuel Bar Update
        setFuelBar();

        //Thrust
        thrustParticle.emissionRate = thrust * 10;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && thrust < maxThrust && fuel != 0)
        {
            thrust += Time.deltaTime * acceleration;
            
        }

        if (Input.GetKey(KeyCode.UpArrow) && !thrusterSound.isPlaying && thrust > 0 && fuel != 0)
        {
            thrusterSound.Play(0);
        } else if (fuel == 0 || thrust <= 0)
        {
            thrusterSound.Stop();
        }


        if (Input.GetKey(KeyCode.DownArrow) && thrust > 0)
        {
            thrust -= Time.deltaTime * acceleration * 2;
        }
    }

    

    void setMaxBar()
    {
        fuelBar.maxValue = maxFuel;
        fuelBar.value = fuel;

        heightBar.maxValue = maxHeight;
    }

    void setFuelBar()
    {
        fuelBar.value = fuel;
    }

    void setHeightBar()
    {
        heightBar.value = height;
    }

    void gameFinish()
    {

    }

    public void onDestroy()
    {
        player.addMoney((int)height);
        Application.LoadLevel(Application.loadedLevel);
    }
}
