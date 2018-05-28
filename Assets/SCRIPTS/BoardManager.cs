using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasBoard
{
    public class BoardManager : MonoBehaviour
    {
//         #region Constantes
//         private const int puntuacionPorEnemigo = 10;

//         private const float moveTime = 0.5f;
//         private const float spawnTime = 0.25f;

//         private const float minInputMagnitude = 150f;

//         //private const int tileOffset = 50;
//         #endregion

//         //public static GameManager reference;
//         private int tileOffset = 50;
//         public InventoryManager inventory;

//         [HideInInspector]
//         public GameState State;

//         public Vector2Int tamano;
//         public RectTransform rT;
//         public Transform canvas;

//         public Tile[,] allTiles;
//         [HideInInspector]
//         public List<Vector2Int> freeTiles;

//         [Header("Player Texts")]
//         public Text scoreText;

//         private int score = 0;
//         private int multiplier = 1;

//         public Mouse mouse;

//         #region Start & Update
//         private void Start()
//         {
//             //tileOffset = Mathf.RoundToInt((Screen.width * rT.lossyScale.x) - 100);

//             allTiles = new Tile[tamano.x, tamano.y];
//             Vector2 t = tamano * tileOffset;
//             rT.sizeDelta = tamano * 100;

//             float xOffset = (t.x % 2 == 0) ? -(t.x / 2) + tileOffset / 2 : t.x / -2;
//             float yOffset = (t.y % 2 == 0) ? -(t.y / 2) + tileOffset / 2 : t.y / -2;

//             for (int x = 0; x < tamano.x; x++)
//             {
//                 for (int y = 0; y < tamano.y; y++)
//                 {
//                     allTiles[x, y].Reset(true);

//                     allTiles[x, y].Pos = new Vector2((x * tileOffset) + xOffset + transform.position.x, (y * tileOffset) + yOffset + transform.position.y);
//                 }
//             }

//             //UpdateEmptyTiles();
//             SpawnPice(Player);
//             //UpdateEmptyTiles();
//             SpawnRandom();

//             Pieces = new List<GamePiece>(tamano.x * tamano.y);

//             //UpdatePiecesList();
//             SetInputMode();
//         }

//         float contador = 0;
//         private void Update()
//         {
//             switch (State)
//             {
//                 case GameState.Playing:
//                     InputUpdate();
//                     break;

//                 case GameState.PieceMovement:
//                     MovementUpdate();
//                     break;

//                 case GameState.PieceSpawn:
//                     SpawnUpdate();
//                     break;
//             }
//         }
//         #endregion

//         #region Input

//         private Vector2 inputStartPos;
//         private Vector2 inputEndPos;

//         private void InputUpdate()
//         {
// #if UNITY_ANDROID
//             if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//             {
//                 inputStartPos = Input.GetTouch(0).position;
//             }
//             else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
//             {
//                 inputEndPos = Input.GetTouch(0).position;
//             }
//             else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
//             {
//                 Vector2 vector = inputEndPos - inputStartPos;

//                 if (mouse.InGame(inputStartPos) && vector.magnitude > minInputMagnitude)
//                 {
//                     if (Mathf.Abs(vector.x) < Mathf.Abs(vector.y))
//                     {
//                         if (vector.y > 0)
//                         {
//                             Move(Vector2.up);
//                         }
//                         else
//                         {
//                             Move(Vector2.down);
//                         }
//                     }
//                     else
//                     {
//                         if (vector.x > 0)
//                         {
//                             Move(Vector2.right);
//                         }
//                         else
//                         {
//                             Move(Vector2.left);
//                         }
//                     }
//                 }
//             }
// #endif
// #if UNITY_EDITOR
//             if (Input.GetMouseButtonDown(0))
//             {
//                 inputStartPos = Input.mousePosition;
//             }
//             else if (Input.GetMouseButtonUp(0))
//             {
//                 inputEndPos = Input.mousePosition;
//                 Vector2 vector = inputEndPos - inputStartPos;

//                 if (mouse.InGame(inputStartPos) && vector.magnitude > minInputMagnitude)
//                 {
//                     if (Mathf.Abs(vector.x) < Mathf.Abs(vector.y))
//                     {
//                         if (vector.y > 0)
//                         {
//                             Move(Vector2.up);
//                         }
//                         else
//                         {
//                             Move(Vector2.down);
//                         }
//                     }
//                     else
//                     {
//                         if (vector.x > 0)
//                         {
//                             Move(Vector2.right);
//                         }
//                         else
//                         {
//                             Move(Vector2.left);
//                         }
//                     }
//                 }
//             }

//             if (Input.GetKeyDown(KeyCode.UpArrow))
//             {
//                 Move(Vector2.up);
//             }
//             else if (Input.GetKeyDown(KeyCode.DownArrow))
//             {
//                 Move(Vector2.down);
//             }
//             else if (Input.GetKeyDown(KeyCode.LeftArrow))
//             {
//                 Move(Vector2.left);
//             }
//             else if (Input.GetKeyDown(KeyCode.RightArrow))
//             {
//                 Move(Vector2.right);
//             }
// #endif
//         }

//         private void SetInputMode()
//         {
//             UpdatePiecesList();
//             State = GameState.Playing;

//             //Debug.Log(allTiles[0, 4].tT + " | " + allTiles[1, 4].tT + " | " + allTiles[2, 4].tT + " | " + allTiles[3, 4].tT + " | " + allTiles[4, 4].tT);
//             //Debug.Log(allTiles[0, 3].tT + " | " + allTiles[1, 3].tT + " | " + allTiles[2, 3].tT + " | " + allTiles[3, 3].tT + " | " + allTiles[4, 3].tT);
//             //Debug.Log(allTiles[0, 2].tT + " | " + allTiles[1, 2].tT + " | " + allTiles[2, 2].tT + " | " + allTiles[3, 2].tT + " | " + allTiles[4, 2].tT);
//             //Debug.Log(allTiles[0, 1].tT + " | " + allTiles[1, 1].tT + " | " + allTiles[2, 1].tT + " | " + allTiles[3, 1].tT + " | " + allTiles[4, 1].tT);
//             //Debug.Log(allTiles[0, 0].tT + " | " + allTiles[1, 0].tT + " | " + allTiles[2, 0].tT + " | " + allTiles[3, 0].tT + " | " + allTiles[4, 0].tT);
//             //Debug.Log("----------------------");
//         }
//         #endregion

//         #region Calculos Movimiento
//         private bool moved = false;
//         private Vector2 prevDir = Vector2.zero;
//         public void Move(Vector2 dir)
//         {
//             if (dir == prevDir)
//                 return;

//             prevDir = dir;
//             moved = false;
//             if (dir.y != 0)
//             {
//                 for (int x = 0; x < tamano.x; x++)
//                 {
//                     //Abajo
//                     if (dir.y < 0)
//                     {
//                         for (int y = 1; y < tamano.y; y++)
//                         {
//                             if (!allTiles[x, y].ocupy)// || allTiles[x, y - 1].ocupy)
//                                 continue;

//                             for (int i = 1; i <= y; i++)
//                             {
//                                 if (CheckCombat(new Vector2Int(x, y), new Vector2Int(x, y - i), Vector2Int.up))//allTiles[x, y - i].ocupy)
//                                 {
//                                     //if (allTiles[x, y].Id.GetComponent<GamePiece>().Attack(allTiles[x, y - i].Id.GetComponent<GamePiece>()))
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x, y - i));

//                                     //else
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x, y - i + 1));

//                                     break;
//                                 }
//                                 else if (i == y)
//                                 {
//                                     MovePiece(new Vector2Int(x, y), new Vector2Int(x, 0));
//                                 }
//                             }
//                         }
//                     }

//                     //Arriba
//                     else
//                     {
//                         for (int y = tamano.y - 2; y >= 0; y--)
//                         {
//                             if (!allTiles[x, y].ocupy)// || allTiles[x, y + 1].ocupy)
//                                 continue;

//                             for (int i = 1; i <= (tamano.y - 1) - y; i++)
//                             {
//                                 if (CheckCombat(new Vector2Int(x, y), new Vector2Int(x, y + i), Vector2Int.down))//allTiles[x, y + i].ocupy)
//                                 {
//                                     //if (allTiles[x, y].Id.GetComponent<GamePiece>().Attack(allTiles[x, y + i].Id.GetComponent<GamePiece>()))
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x, y + i));

//                                     //else
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x, y + i - 1));

//                                     break;
//                                 }
//                                 else if (i == (tamano.y - 1) - y)
//                                 {
//                                     MovePiece(new Vector2Int(x, y), new Vector2Int(x, tamano.y - 1));
//                                 }
//                             }
//                         }
//                     }
//                 }
//             }
//             else
//             {
//                 for (int y = 0; y < tamano.y; y++)
//                 {
//                     //Izquierda
//                     if (dir.x < 0)
//                     {
//                         for (int x = 1; x < tamano.y; x++)
//                         {
//                             if (!allTiles[x, y].ocupy)// || allTiles[x - 1, y].ocupy)
//                                 continue;

//                             for (int i = 1; i <= x; i++)
//                             {
//                                 if (CheckCombat(new Vector2Int(x, y), new Vector2Int(x - i, y), Vector2Int.right))//allTiles[x - i, y].ocupy)
//                                 {
//                                     //if (allTiles[x, y].Id.GetComponent<GamePiece>().Attack(allTiles[x - i, y].Id.GetComponent<GamePiece>()))
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x - i, y));

//                                     //else
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x - i + 1, y));

//                                     break;
//                                 }
//                                 else if (i == x)
//                                 {
//                                     MovePiece(new Vector2Int(x, y), new Vector2Int(0, y));
//                                 }
//                             }
//                         }
//                     }

//                     //Derecha
//                     else
//                     {
//                         for (int x = tamano.x - 2; x >= 0; x--)
//                         {
//                             if (!allTiles[x, y].ocupy)// || allTiles[x + 1, y].ocupy)
//                                 continue;

//                             for (int i = 1; i <= (tamano.x - 1) - x; i++)
//                             {
//                                 if (CheckCombat(new Vector2Int(x, y), new Vector2Int(x + i, y), Vector2Int.left))//allTiles[x + i, y].ocupy)
//                                 {
//                                     //if (allTiles[x, y].Id.GetComponent<GamePiece>().Attack(allTiles[x + i, y].Id.GetComponent<GamePiece>()))
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x + i, y));

//                                     //else
//                                     //{
//                                     //    //Debug.Log(allTiles[x, y].Id + ": " + allTiles[x, y].Pos);
//                                     //    //Debug.Log(allTiles[x + i, y].Id + ": " + allTiles[x + i, y].Pos);
//                                     //    movePiece(new Vector2Int(x, y), new Vector2Int(x + i - 1, y));
//                                     //    //Debug.Log(allTiles[x + i - 1, y].Id + ": " + allTiles[x + i - 1, y].Pos);
//                                     //    //Debug.Log(allTiles[x + i, y].Id + ": " + allTiles[x + i, y].Pos);
//                                     //    //Debug.Log("---------------------------------");
//                                     //}

//                                     break;
//                                 }
//                                 else if (i == (tamano.x - 1) - x)
//                                 {
//                                     MovePiece(new Vector2Int(x, y), new Vector2Int(tamano.x - 1, y));
//                                 }
//                             }
//                         }
//                     }
//                 }
//             }
//             if (moved)
//                 SetMovementMode();
//         }

//         private bool CheckCombat(Vector2Int from, Vector2Int to, Vector2Int dir)
//         {
//             //¿siguente tile ocupado?
//             if (allTiles[to.x, to.y].ocupy)
//             {
//                 if (allTiles[from.x, from.y].tT == TileTipe.Player && allTiles[from.x, from.y].Id.GetComponent<GamePiece>().Action(allTiles[to.x, to.y]))
//                 {
//                     if (allTiles[to.x, to.y].tT == TileTipe.Enemy)
//                     {
//                         score += puntuacionPorEnemigo * multiplier;
//                         multiplier++;
//                     }

//                     allTiles[to.x, to.y].Reset();
//                     return false;
//                 }
//                 //enemigos
//                 else if (allTiles[from.x, from.y].tT == TileTipe.Enemy && ((TileTipe.enemyInt & allTiles[to.x, to.y].tT) != 0) && allTiles[from.x, from.y].Id.GetComponent<GamePiece>().Action(allTiles[to.x, to.y]))
//                 {
//                     allTiles[to.x, to.y].Reset();
//                     return false;
//                 }
//                 //pociones
//                 else if (allTiles[from.x, from.y].tT == TileTipe.Item && ((TileTipe.itemInt & allTiles[to.x, to.y].tT) != 0) && allTiles[from.x, from.y].Id.GetComponent<GamePiece>().Action(allTiles[to.x, to.y]))
//                 {
//                     MovePiece(new Vector2Int(from.x, from.y), new Vector2Int(to.x, to.y), true);

//                     return true;
//                 }

//                 //Dejar la pieza en su posición
//                 MovePiece(new Vector2Int(from.x, from.y), new Vector2Int(to.x + dir.x, to.y + dir.y));

//                 //Dejar el bucle
//                 return true;
//             }
//             //Continuar con el siguente tile
//             return false;
//         }

//         private void MovePiece(Vector2Int from, Vector2Int to, bool pickup = false)
//         {
//             if (from == to)
//                 return;

//             allTiles[from.x, from.y].Id.GetComponent<GamePiece>().setMovementMode(allTiles[to.x, to.y].Pos);

//             if (!pickup)
//             {
//                 allTiles[to.x, to.y].ocupy = true;
//                 allTiles[to.x, to.y].Id = allTiles[from.x, from.y].Id;
//                 allTiles[to.x, to.y].tT = allTiles[from.x, from.y].tT;
//             }

//             allTiles[from.x, from.y].Reset();

//             moved = true;
//         }
//         #endregion

//         #region Animaciones Movimiento

//         private List<GamePiece> Pieces;

//         private void MovementUpdate()
//         {
//             contador += Time.deltaTime;

//             float t = contador / moveTime;

//             foreach (GamePiece m in Pieces)
//             {
//                 m.updateMovement(t);
//             }

//             if (contador > moveTime)
//             {
//                 multiplier = 1;
//                 scoreText.text = score.ToString();

//                 SetSpawnMode();
//             }
//         }

//         private void SetMovementMode()
//         {
//             contador = 0;
//             //UpdatePiecesList();
//             State = GameState.PieceMovement;
//         }

//         private void UpdatePiecesList()
//         {
//             Pieces.Clear();
//             for (int x = 0; x < tamano.x; x++)
//             {
//                 for (int y = 0; y < tamano.y; y++)
//                 {
//                     if (allTiles[x, y].ocupy)
//                         Pieces.Add(allTiles[x, y].Id.GetComponent<GamePiece>());
//                 }
//             }
//         }
//         #endregion

//         #region Spawn

//         [Header("Spawn")]
//         public GameObject Player;
//         public GameObject Enemy;
//         public GameObject Item;

//         public AnimationCurve mappingQuality;

//         //public GameObject Enemy;

//         public pice[] objs;

//         private void SpawnUpdate()
//         {
//             contador += Time.deltaTime;

//             if (contador > spawnTime)
//             {
//                 SetInputMode();
//             }
//         }

//         private void SetSpawnMode()
//         {
//             contador = 0;
//             State = GameState.PieceSpawn;
//             SpawnRandom();
//         }

//         public void SpawnRandom()
//         {
//             //Aqui crear una serie de reglas para los spawns
//             UpdateEmptyTiles();
//             int r = UnityEngine.Random.Range(0, freeTiles.Count);

//             int x = freeTiles[r].x;
//             int y = freeTiles[r].y;

//             int rand = Mathf.FloorToInt(mappingQuality.Evaluate(Random.value));
//             allTiles[x, y].ocupy = true;

//             if (objs[rand].tT == TileTipe.Enemy)
//                 allTiles[x, y].Id = Instantiate(Enemy);
//             else
//                 allTiles[x, y].Id = Instantiate(Item);

//             allTiles[x, y].Id.GetComponent<GamePiece>().token = objs[rand].Id;
//             allTiles[x, y].tT = objs[rand].tT;

//             allTiles[x, y].Id.transform.SetParent(transform, false);
//             allTiles[x, y].Id.transform.position = allTiles[x, y].Pos;
//             allTiles[x, y].Id.transform.SetAsFirstSibling();
//         }

//         private void SpawnPice(GameObject obj)
//         {
//             UpdateEmptyTiles();
//             int r = Random.Range(0, freeTiles.Count);

//             int x = freeTiles[r].x;
//             int y = freeTiles[r].y;

//             GameObject id;
//             id = Instantiate(obj);
//             id.transform.SetParent(canvas, false);
//             id.transform.position = allTiles[x, y].Pos;

//             PlayerPice pp = id.GetComponent<PlayerPice>();
//             pp.iM = inventory;

//             allTiles[x, y].ocupy = true;
//             allTiles[x, y].Id = id;
//             allTiles[x, y].tT = TileTipe.Player;
//         }

//         public void UpdateEmptyTiles()
//         {
//             freeTiles.Clear();
//             for (int x = 0; x < tamano.x; x++)
//             {
//                 for (int y = 0; y < tamano.y; y++)
//                 {
//                     if (allTiles[x, y].ocupy)
//                         continue;

//                     freeTiles.Add(new Vector2Int(x, y));
//                 }
//             }
//         }

//         #endregion

//         #region Debug
//         //private void OnDrawGizmos()
//         //{
//         //    //gameInputRect = new Rect(0, 0, Screen.width, Screen.height);
//         //    Gizmos.color = new Color(0, 1, 0, 0.5f);
//         //    Gizmos.DrawCube(inventory.position, inventory.sizeDelta/2);
//         //}

//         void OnGUI()
//         {
//             //GUI.Box(new Rect(0, 0, 100, 50), Screen.height.ToString() + "x" + Screen.width.ToString());
//             GUI.Box(new Rect(0, 0, 100, 50), tileOffset.ToString());
//         }
//         #endregion
    }

    #region Structs y Enums
    [System.Serializable]
    public struct Tile
    {
        public Vector2 Pos;
        public bool ocupy;

        public GameObject Id;
        public TileTipe tT;

        public void Reset(bool pos = false)
        {
            if (pos) Pos = Vector2.zero;

            ocupy = false;
            Id = null;
            tT = TileTipe.na;
        }
    }

    [System.Serializable]
    public struct pice
    {
        public Token Id;
        public TileTipe tT;
        public int cantidad;
    }

    public enum TileTipe
    {
        na = 0,
        Player = 1, //Ataca y defiende  Todos
        Enemy = 2,  //Ataca y defiende  Solo con jugadores
        Item = 4,   //Defiende         Solo con jugadores

        All = Player | Enemy | Item,
        //playerInt = All,
        enemyInt = Player,
        itemInt = Player
    }

    public enum GameState
    {
        Playing,
        GameOver,
        PieceMovement,
        PieceSpawn
    }
    #endregion
}