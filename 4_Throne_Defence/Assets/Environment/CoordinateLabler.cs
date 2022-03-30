using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.black;
    Color pathColor = Color.yellow;

    GridManager gridManager;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;

        DisplayCoordinates();
    }

    void Update()
    {
        if(!Application.isPlaying)
       {
           DisplayCoordinates();
           UpdateObjectName();
           label.enabled = true;
       }

       SetLabelColor();
       ToggleLabels();
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor()
    {
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    void DisplayCoordinates()
    {
        if (gridManager == null) { return; }

        coordinates.x = Mathf.RoundToInt(
            transform.parent.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(
            transform.parent.position.z / gridManager.UnityGridSize);

        label.text = coordinates.x + ", " +coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
