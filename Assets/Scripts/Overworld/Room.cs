using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public Interactable[] interactables;
    public List<Enemy> enemies;
    public SpriteRenderer background;
    public PolygonCollider2D walls;
}
