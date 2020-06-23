# Unity Generic Binary Serializer

Player.cs file
```c#
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
		playerDataInstance.pos += Vector2.Up+0.5f;

		Debug.Log(playerDataInstance.score);

		//Save new Data to file after change.
		BinarySerializer.Save (playerDataInstance, "player.txt");
	}
}
```

BinarySerializer has 3 accessible static methods.

# Save Data
public static void Save <T> (T data, string filename)
Saves any data with a given type T in a file (filename).
```c#
BinarySerializer.Save (dataHolder, "filename");
```
Note! : You will find saved data "filename" in your app's persistent data path.
add :
```c#
Debug.Log(Application.persistentDataPath+"/GameData/");
```
if you want to see where data is saved in your machine.


# Load Data
public static T Load<T> (string filename)
Loads data from a saved file (filename).
```c#
dataHolder = BinarySerializer.Load ("filename");
```
Note! : The Load method already has a check for file existance, that's why you need to add default values to your DataHolder class, because the BinarySerializer's Load method returns a new instance of the Data if it's not saved before (first Load).

# Check if data is already saved
public static bool HasSaved (string filename)
Check if there is saved data for a given filename.
```c#
if (BinarySerializer.HasSaved("filename")){
	//do something.
}
```
