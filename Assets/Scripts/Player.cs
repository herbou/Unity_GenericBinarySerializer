using UnityEngine;
using TMPro;

[System.Serializable]
public class PlayerData
{
	//Player Data
	public string nickName = "default";
	public Color color = Color.white;
	public Vector2 pos = Vector2.zero;
	public Quaternion rot = Quaternion.identity;
}

public class Player : MonoBehaviour
{
	//References
	[SerializeField] SpriteRenderer playerSprite;
	[SerializeField] TMP_Text playerNickNameUIText;

	public PlayerData playerData = new PlayerData ();

	void Start ()
	{
		//Load data (if it's already saved)
		playerData = BinarySerializer.Load<PlayerData> ("playerdata");

		UpdatePlayer (); //Update player at the beginning.
	}

	void Update ()
	{
		if (Input.GetMouseButtonUp (0))
			UpdatePlayer (); //Update player on mouse click.
	}

	void UpdatePlayer ()
	{
		playerNickNameUIText.text = playerData.nickName; //Update player nickname in UI.
		playerSprite.color = playerData.color; //Update player color.
		transform.position = playerData.pos; //Update player position.
		transform.rotation = playerData.rot; //Update player position.
	}

	void OnApplicationQuit ()
	{
		//save data before quit.
		//in your game you may want to save data in different ways.. maybe when player pos changed , ...
		BinarySerializer.Save (playerData, "playerdata");
	}
}
