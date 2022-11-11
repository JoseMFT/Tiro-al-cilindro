using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorColor: MonoBehaviour {
    public Texture2D cursorTexture;
    void Awake () {
        Cursor.SetCursor (cursorTexture, new Vector2 (15, 15), CursorMode.ForceSoftware);
    }
}
