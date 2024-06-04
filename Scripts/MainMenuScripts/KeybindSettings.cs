using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindSettings : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text heal, jump, left, fireball, right, sword, block, mana;

    public static string lefter;
    public static string righter;
    public static string firer;
    public static string jumper;
    public static string sworder;
    public static string healer;
    public static string blocked;
    public static string magicer;

    private GameObject currentKey;


    private void Awake()
    {
        //print("running keybinds");
        keys.Add("JumpKey", KeyCode.W);
        keys.Add("FireballKey", KeyCode.Q);
        keys.Add("LeftKey", KeyCode.A);
        keys.Add("RightKey", KeyCode.D);
        keys.Add("HealKey", KeyCode.R);      
        keys.Add("SwordKey", KeyCode.Z);
        keys.Add("PotionKey", KeyCode.E);
        keys.Add("BlockKey", KeyCode.Space);
    }
    private void Start()
    {
        jump.text = keys["JumpKey"].ToString();
        fireball.text = keys["FireballKey"].ToString();
        left.text = keys["LeftKey"].ToString();
        right.text = keys["RightKey"].ToString();
        heal.text = keys["HealKey"].ToString();
        sword.text = keys["SwordKey"].ToString();
        mana.text = keys["PotionKey"].ToString();
        block.text = keys["BlockKey"].ToString();

        lefter = left.text;
        righter = right.text;
        firer = fireball.text;
        jumper = jump.text;
        healer = heal.text;
        sworder = sword.text;
        magicer = mana.text;
        blocked = block.text;

        //print(mana.text);
        
    }

    private string getAlpha(string key)
    {
        if (key.Contains("Alpha"))
        {
            for (int i = 0; i < 10; i++)
            {
                if (key.Contains(i.ToString()))
                {
                    return i.ToString();
                }
            }
            return key;
        }
        return key;   
    }

    private void Update()
    {
        if (Input.GetKeyDown(keys["JumpKey"]))
        {
            Debug.Log("Jump");
        }
        if (Input.GetKeyDown(keys["FireballKey"]))
        {
            Debug.Log("Fireball");
        }
        if (Input.GetKeyDown(keys["RightKey"]))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys["LeftKey"]))
        {
            Debug.Log("Left");
        }if (Input.GetKeyDown(keys["HealKey"]))
        {
            Debug.Log("heal");
        }
        if (Input.GetKeyDown(keys["SwordKey"]))
        {
            Debug.Log("Sword");
        }
        if (Input.GetKeyDown(keys["BlockKey"]))
        {
            Debug.Log("Block");
        }
        if (Input.GetKeyDown(keys["PotionKey"]))
        {
            Debug.Log("Potion");
        }
        
    }

    private void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;

                if (currentKey.name.Equals("RightKey"))
                {
                    //print("change righter");
                    if (!keys["RightKey"].ToString().Equals(left.text) && !keys["RightKey"].ToString().Equals(right.text)
                    && !keys["RightKey"].ToString().Equals(block.text) && !keys["RightKey"].ToString().Equals(sword.text)
                    && !keys["RightKey"].ToString().Equals(mana.text) && !keys["RightKey"].ToString().Equals(heal.text)
                    && !keys["RightKey"].ToString().Equals(fireball.text))
                        righter = keys[currentKey.name].ToString();

                }
                if (currentKey.name.Equals("LeftKey"))
                {
                    //print("change left");
                    if (!keys["LeftKey"].ToString().Equals(left.text) && !keys["LeftKey"].ToString().Equals(right.text)
                    && !keys["LeftKey"].ToString().Equals(block.text) && !keys["LeftKey"].ToString().Equals(sword.text)
                    && !keys["LeftKey"].ToString().Equals(mana.text) && !keys["LeftKey"].ToString().Equals(heal.text)
                    && !keys["LeftKey"].ToString().Equals(fireball.text))
                        lefter = keys[currentKey.name].ToString();
                }
                if (currentKey.name.Equals("JumpKey"))
                {
                    //print("change jumper");
                    if (!keys["JumpKey"].ToString().Equals(left.text) && !keys["JumpKey"].ToString().Equals(right.text)
                    && !keys["JumpKey"].ToString().Equals(block.text) && !keys["JumpKey"].ToString().Equals(sword.text)
                    && !keys["JumpKey"].ToString().Equals(mana.text) && !keys["JumpKey"].ToString().Equals(heal.text)
                    && !keys["JumpKey"].ToString().Equals(fireball.text))
                        jumper = keys[currentKey.name].ToString();
                }
                if (currentKey.name.Equals("FireballKey"))
                {
                    //print("change fireball");
                    if (!keys["FireballKey"].ToString().Equals(left.text) && !keys["FireballKey"].ToString().Equals(right.text)
                    && !keys["FireballKey"].ToString().Equals(block.text) && !keys["FireballKey"].ToString().Equals(sword.text)
                    && !keys["FireballKey"].ToString().Equals(mana.text) && !keys["FireballKey"].ToString().Equals(heal.text)
                    && !keys["FireballKey"].ToString().Equals(fireball.text))
                        firer = keys[currentKey.name].ToString();
                }
                 if (currentKey.name.Equals("HealKey"))
                {
                    //print("change heal");
                    if (!keys["HealKey"].ToString().Equals(left.text) && !keys["HealKey"].ToString().Equals(right.text)
                    && !keys["HealKey"].ToString().Equals(block.text) && !keys["HealKey"].ToString().Equals(sword.text)
                    && !keys["HealKey"].ToString().Equals(mana.text) && !keys["HealKey"].ToString().Equals(heal.text)
                    && !keys["HealKey"].ToString().Equals(fireball.text))
                        healer = keys[currentKey.name].ToString();
                }

                if (currentKey.name.Equals("SwordKey"))
                {
                    //print("change sword");
                    if (!keys["SwordKey"].ToString().Equals(left.text) && !keys["SwordKey"].ToString().Equals(right.text)
                    && !keys["SwordKey"].ToString().Equals(block.text) && !keys["SwordKey"].ToString().Equals(sword.text)
                    && !keys["SwordKey"].ToString().Equals(mana.text) && !keys["SwordKey"].ToString().Equals(heal.text)
                    && !keys["SwordKey"].ToString().Equals(fireball.text))
                        sworder = keys[currentKey.name].ToString();
                }
                if (currentKey.name.Equals("PotionKey"))
                {
                    //print("change potion");
                    if (!keys["PotionKey"].ToString().Equals(left.text) && !keys["PotionKey"].ToString().Equals(right.text)
                    && !keys["PotionKey"].ToString().Equals(block.text) && !keys["PotionKey"].ToString().Equals(sword.text)
                    && !keys["PotionKey"].ToString().Equals(mana.text) && !keys["PotionKey"].ToString().Equals(heal.text)
                    && !keys["PotionKey"].ToString().Equals(fireball.text))
                        magicer = keys[currentKey.name].ToString();
                }
                if (currentKey.name.Equals("BlockKey"))
                {
                    //print("change block");
                    if (!keys["BlockKey"].ToString().Equals(left.text) && !keys["BlockKey"].ToString().Equals(right.text)
                    && !keys["BlockKey"].ToString().Equals(block.text) && !keys["BlockKey"].ToString().Equals(sword.text)
                    && !keys["BlockKey"].ToString().Equals(mana.text) && !keys["BlockKey"].ToString().Equals(heal.text)
                    && !keys["BlockKey"].ToString().Equals(fireball.text))
                        blocked = keys[currentKey.name].ToString();
                }

                if(!e.keyCode.ToString().Equals(left.text) && !e.keyCode.ToString().Equals(right.text) 
                    && !e.keyCode.ToString().Equals(block.text) && !e.keyCode.ToString().Equals(sword.text) 
                    && !e.keyCode.ToString().Equals(mana.text) && !e.keyCode.ToString().Equals(heal.text) 
                    && !e.keyCode.ToString().Equals(fireball.text))
                {
                    currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                }
                //currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;

            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
    /*private PlayerMovement player;
    private string input;
    public string fireballKey;
    public string jumpKey;
    public string rightKey;
    public string leftKey;

    public static InputField FireballAttackInput;
    private GameObject inputs;

    public static InputField JumpInput;
    private GameObject inputs2;

    public static InputField LeftInput;
    private GameObject inputs3;

    public static InputField RightInput;
    private GameObject inputs4;

    private void Awake()
    {
        print("KeybindSettingsRan");
        inputs = GameObject.Find("FireballAttackInput");
        FireballAttackInput = inputs.GetComponent<InputField>();

        inputs2 = GameObject.Find("JumpInput");
        JumpInput = inputs2.GetComponent<InputField>();

        inputs3 = GameObject.Find("LeftInput");
        LeftInput = inputs3.GetComponent<InputField>();

        inputs4 = GameObject.Find("RightInput");
        RightInput = inputs4.GetComponent<InputField>();

        fireballKey = "e".ToUpper();
        jumpKey = "w".ToUpper();
        rightKey = "d".ToUpper();
        leftKey = "a".ToUpper();

        FireballAttackInput.text = fireballKey;
        JumpInput.text = jumpKey;
        LeftInput.text = leftKey;
        RightInput.text = rightKey;
    }

    // Start is called before the first frame update
    void Start()
    {
        FireballAttackInput.text = fireballKey;
        JumpInput.text = jumpKey;
        LeftInput.text = leftKey;
        RightInput.text = rightKey;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getFireball(string s)
    {
        if(!(s.Equals(jumpKey)) && 
            !(s.Equals(rightKey)) &&
            !(s.Equals(leftKey)))
        {
            fireballKey = s.ToString().ToUpper();
        }
        else
        {
            FireballAttackInput.text = fireballKey.ToUpper();
        }
    }

    public void getJump(string s)
    {
        if (!s.Equals(fireballKey) &&
            !s.Equals(rightKey) &&
            !s.Equals(leftKey))
        { jumpKey = s.ToString().ToUpper(); }
        else
        {
            JumpInput.text = jumpKey.ToUpper();
        }
    }

    public void getRight(string s)
    {
        if (!s.Equals(fireballKey) &&
            !s.Equals(leftKey) &&
            !s.Equals(jumpKey))
        {rightKey = s.ToString().ToUpper(); }
        else
        {
            RightInput.text = rightKey.ToUpper();
        }
    }

    public void getLeft(string s)
    {
        if (!s.Equals(jumpKey) &&
            !s.Equals(rightKey) &&
            !s.Equals(fireballKey))
        {leftKey = s.ToString().ToUpper(); }
        else
        {
            LeftInput.text = leftKey.ToUpper();
        }
    }

    public string getKey(string mode)
    {
        if (mode.Equals("attackFire"))
        {
            return fireballKey.ToUpper();
        }
        if (mode.Equals("jump"))
        {
            return jumpKey.ToUpper();
        }
        if (mode.Equals("left"))
        {
            return leftKey.ToUpper();
        }
        if (mode.Equals("right"))
        {
            return rightKey.ToUpper();
        }
        return null;
    }*/
}
