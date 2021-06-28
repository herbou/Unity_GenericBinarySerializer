using UnityEngine ;
using TMPro ;

[System.Serializable]
public class PlayerData {
   //Player Data
   public string nickName = "default" ;
   public Color color = Color.white ;
   public Vector3 pos = Vector3.zero ;
   public Quaternion rot = Quaternion.identity ;
}

public class Player : MonoBehaviour {
   //References
   [SerializeField] SpriteRenderer playerSprite ;
   [SerializeField] TMP_Text playerNickNameUIText ;

   public PlayerData playerData = new PlayerData () ;



   void Start () {
      //Load data (if it's already saved)
      playerData = BinarySerializer.Load<PlayerData> ("playerdata") ;

      Debug.Log (BinarySerializer.GetDataPath ()) ;

      UpdatePlayer () ; //Update player at the beginning.
   }


   void Update () {
      // Update player on mouse click.
      if (Input.GetMouseButtonUp (0))
         UpdatePlayer () ; 

      // delete saved data "playerdata" when X key is pressed
      if (Input.GetKeyUp (KeyCode.X))
         BinarySerializer.DeleteDataFile ("playerdata") ;
   }


   void UpdatePlayer () {
      playerNickNameUIText.text = playerData.nickName ; //Update player nickname in UI.
      playerSprite.color = playerData.color ; //Update player color.
      transform.position = playerData.pos ; //Update player position.
      transform.rotation = playerData.rot ; //Update player rotation.
   }


   void OnApplicationQuit () {
      //save data before quit.
      //in your game you may want to save data in different ways.. maybe when player pos changed , ...
      BinarySerializer.Save (playerData, "playerdata") ;
   }
}
