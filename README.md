# Unity Generic Binary Serializer

📄 Player.cs file
```c#
//Your data holder class
[System.Serializable]
public class PlayerData
{
	//This class contains only player data that you want to save.
	//don't add any logic code here (methods,..).

	public string nickName = "Default Name";
	public int score = 0;
	public Color color = Color.white;
	public Vector2 pos = Vector2.zero;
	public Quaternion rot = Quaternion.identity;

	//You can add Arrays, Dictionaries, Lists...
	//public List<int> listOfItems = new List<int>();
	//...
}


//Your Player class (MonoBehavior)
public class Player : MonoBehaviour
{
	//References
	//....

	public PlayerData playerDataInstance = new PlayerData ();

	void Start ()
	{
		//Load data from file.
		playerDataInstance = BinarySerializer.Load<PlayerData> ("player.txt");

		//Change Data.
		playerDataInstance.score++;
		playerDataInstance.color = Color.Red;
		playerDataInstance.pos += Vector2.Up*0.5f;

		Debug.Log(playerDataInstance.score);

		//Save new Data to file after change.
		BinarySerializer.Save (playerDataInstance, "player.txt");
	}
}
```

# BinarySerializer has 3 accessible static methods :



# ☴ Save Data
- public static void Save <T> (T data, string filename)
	
Saves any data with a given type T in a file (filename).
```c#
BinarySerializer.Save (dataHolder, "filename");
```
⚠Note! : You will find saved data "filename" in your app's persistent data path :
```c#
//Add this line in the Start if you want to see where data is saved in your machine.
Debug.Log(Application.persistentDataPath+"/GameData/");
```


# ☴ Load Data
- public static T Load<T> (string filename)
	
Loads data from a saved file (filename).
```c#
dataHolder = BinarySerializer.Load ("filename");
```
⚠Note! : The Load method already has a check for file existance, that's why you need to add default values to your Data Holder class fields, because the BinarySerializer's Load method returns a new instance of the Data if it's not saved before.

# ☴ Check if data is already saved
- public static bool HasSaved (string filename)

Check if there is saved data for a given filename.
```c#
if (BinarySerializer.HasSaved("filename")){
	//do something.
}
```

#

#
⚠⚠Note : 
Not all data types are allowed inside Data holder class.
# Allowed types :
all variables that's not part of the Unity engine is allowed :
- int, float, bool, string, char, ....

Concerning UnityEngine types you can only use :
- Vector2, Vector3, Vector4, Color, and Quaternion

You can also save :
- Arrays, Lists, .... of thoes allowed types.

# Unallowed types :
Except the 5 types mentioned above (Vector2, Vector3, Vector4, Color, and Quaternion),, all variables of UnityEngine are not allowed :

- Transform, Gameobject, SpriteRenderer, BoxCollider, Mesh, .....
