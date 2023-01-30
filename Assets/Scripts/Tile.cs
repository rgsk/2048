using UnityEngine;
using TMPro;

using UnityEngine.UI;
public class Tile : MonoBehaviour {
    public TileState state { get; private set; }
    public TileCell cell { get; private set; }
    public int number { get; private set; }

    private Image image;
    private TextMeshProUGUI text;

    private void Awake() {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetState(TileState state, int number) {
        this.state = state;
        this.number = number;
        image.color = state.backgroundColor;
        text.color = state.textColor;
        text.text = number.ToString();
    }
    public void Spawn(TileCell cell) {
        if (this.cell != null) {
            this.cell.tile = null;
        }
        this.cell = cell;
        this.cell.tile = this;
        transform.position = cell.transform.position;
    }
}