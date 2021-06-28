# Unity Generic Binary Serializer
Generic BinarySerializer is a great and easy to use tool that helps you to save/load and secure your game data easily,
Click on the image to watch the video tutorial :

[![Tutorial](https://img.youtube.com/vi/PbPCW8vK3RQ/0.jpg)](https://www.youtube.com/watch?v=PbPCW8vK3RQ)

# ☴ How to use ?
1. Add ```GenericBinarySerializer``` package to your project.
2. Create a class (or struct) to hold your data and mark it as ```Serializable```:

```📄 PlayerData.cs```
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
}
```
# ☴ Methods and properties :
## Load data : 
```c#
obj = BinarySerializer.Load<T> ("filename");
```
Example :
```📄 Player.cs```
```c#
public class Player : MonoBehaviour
{
	// References
	// ...
	// ...
	
	// Your data holder reference :
	public PlayerData playerDataInstance = new PlayerData ();


	void Start ()
	{
		//Load data from file.
		playerDataInstance = BinarySerializer.Load<PlayerData> ("player.txt");
	}
}
```
## Save data : 
```c#
BinarySerializer.Save (obj, "filename");
```
Example :
```📄 Player.cs```
```c#
public class Player : MonoBehaviour
{
	// References
	// ...
	// ...
	
	// Your data holder reference :
	public PlayerData playerDataInstance = new PlayerData ();


	void Start ()
	{
		//Save new Data to file after change.
		BinarySerializer.Save (playerDataInstance, "player.txt");
	}
}
```
## Check if data is already saved : 
```c#
BinarySerializer.HasSaved ("filename");
```
Example :
```c#
if (BinarySerializer.HasSaved("player.txt")){
	//do something.
}
```

## Delete saved file : 
```c#
BinarySerializer.DeleteDataFile ("filename");
```
## Delete all saved files : 
```c#
BinarySerializer.DeleteAllDataFiles ( );
```
## Get the path where data is saved. : 
```c#
BinarySerializer.GetDataPath ( );
```



⚠Notes! : 

- The Load method already has a check for file existance, that's why you need to add default values to your Data Holder class fields, because the BinarySerializer's Load method returns a new instance of the Data if it's not saved before.
- Not all data types are allowed inside Data holder class.
### Allowed types :
- all variables that's not part of the Unity engine are allowed : int, float, bool, string, char, ....
- Concerning UnityEngine types you can only use : Vector2, Vector3, Vector4, Color, and Quaternion
- You can also save : Arrays, Lists, .... of thoes allowed types.

### Unallowed types :
Except the 5 types mentioned above (Vector2, Vector3, Vector4, Color, and Quaternion),, all variables of UnityEngine are not allowed :
- Transform, Gameobject, SpriteRenderer, BoxCollider, Mesh, .....





<br><br><br>
## ❤️ Donate

<a href="https://paypal.me/hamzaherbou" title="https://paypal.me/hamzaherbou" target="_blank"><img align="left" height="50" src="https://www.mediafire.com/convkey/72dc/iz78ys7vtfsl957zg.jpg" alt="Paypal"></a>

<a href="https://www.buymeacoffee.com/hamzaherbou" title="https://www.buymeacoffee.com/hamzaherbou" target="_blank"><img align="left" height="50" src="https://www.mediafire.com/convkey/66bc/dg3xdk96km1pt7gzg.jpg" alt="BuyMeACoffee"></a>

<a href="https://patreon.com/herbou" title="https://patreon.com/herbou" target="_blank"><img align="left" height="50" src="https://www.mediafire.com/convkey/dc61/9kn26we5y76t8vlzg.jpg" alt="Patreon"></a>

