// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MouseLook.cs" company="nGratis">
//   The MIT License (MIT)
//
//   Copyright (c) 2014 - 2015 Cahya Ong
//
//   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//   associated documentation files (the "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the
//   following conditions:
//
//   The above copyright notice and this permission notice shall be included in all copies or substantial
//   portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO
//   EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//   IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR
//   THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <author>Cahya Ong - cahya.ong@gmail.com</author>
// <creation_timestamp>Wednesday, 28 October 2015 10:33:40 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;

public class FirstPersonView : MonoBehaviour
{
    private float _rotationX;

    private float _rotationY;

    private GUIStyle _crosshairStyle;

    private void Awake()
    {
        var crosshairTexture = new Texture2D(1, 1);

        this._crosshairStyle = new GUIStyle
        {
            normal = { background = crosshairTexture }
        };
    }

    private void Update()
    {
        this._rotationX += Input.GetAxis("Mouse X") * 5;
        this._rotationY += Input.GetAxis("Mouse Y") * 5;
        this._rotationY = Mathf.Clamp(this._rotationY, -90, 90);

        this.transform.localRotation =
            Quaternion.AngleAxis(this._rotationX, Vector3.up) *
            Quaternion.AngleAxis(this._rotationY, Vector3.left);
    }

    private void OnGUI()
    {
        var center = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
        GUI.Box(new Rect(center.x - 10, center.y, 21, 1), GUIContent.none, this._crosshairStyle);
        GUI.Box(new Rect(center.x, center.y - 10, 1, 21), GUIContent.none, this._crosshairStyle);
    }
}