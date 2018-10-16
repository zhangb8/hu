using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public Interactable[] interactables;
    public Enemy[] enemies;
    public SpriteRenderer background;
    public PolygonCollider2D walls;
}
