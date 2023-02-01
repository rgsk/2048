using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
public class Tile : MonoBehaviour {
    public TileState state { get; private set; }
    public TileCell cell { get; private set; }
    public int number { get; private set; }
    public bool locked;
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
    public void MoveTo(TileCell cell) {
        if (this.cell != null) {
            this.cell.tile = null;
        }
        this.cell = cell;
        this.cell.tile = this;
        StartCoroutine(Animate(cell.transform.position, false));
    }
    private IEnumerator Animate(Vector3 to, bool merging) {
        float elapsed = 0f;
        float duration = 0.1f;
        Vector3 from = transform.position;
        while (elapsed < duration) {
            var percentageOfAnimationComplete = elapsed / duration;
            transform.position = Vector3.Lerp(from, to, percentageOfAnimationComplete);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = to;
        if (merging) {
            Destroy(gameObject);
        }
    }
    public void Merge(TileCell cell) {
        if (this.cell != null) {
            this.cell.tile = null;
        }
        this.cell = null;
        cell.tile.locked = true;
        StartCoroutine(Animate(cell.transform.position, true));
    }
}
