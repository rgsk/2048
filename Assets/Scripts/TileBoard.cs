using System.Collections.Generic;
using UnityEngine;

public class TileBoard : MonoBehaviour {

    public Tile tilePrefab;
    public TileState[] tileStates;
    private TileGrid grid;
    private List<Tile> tiles;
    private void Awake() {
        grid = GetComponentInChildren<TileGrid>();
        tiles = new List<Tile>();
    }
    private void Start() {
        CreateTile();
        CreateTile();
    }
    private void CreateTile() {
        var tile = Instantiate(tilePrefab, grid.transform);
        tile.SetState(tileStates[0], 2);
        tile.Spawn(grid.GetRandomEmptyCell());
        tiles.Add(tile);
    }
    private void TestCreatingAllCells() {
        for (int i = 0; i <= 10; i++) {
            int number = (int)Mathf.Pow(2, i + 1);
            var tile = Instantiate(tilePrefab, grid.transform);
            tile.SetState(tileStates[i], number);
            tile.Spawn(grid.GetRandomEmptyCell());
        }
    }
}
