// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObstacleGenerator.cs" company="nGratis">
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
// <creation_timestamp>Wednesday, 28 October 2015 9:42:44 AM UTC</creation_timestamp>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using JetBrains.Annotations;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [UsedImplicitly]
    private void Start()
    {
        for (var index = 1; index <= 10; index++)
        {
            this.CreateObstacle(
                string.Format(CultureInfo.InvariantCulture, "Obstacle_X{0:000}", index),
                new Vector3(index * 10, 0, 0),
                Color.red);

            this.CreateObstacle(
                string.Format(CultureInfo.InvariantCulture, "Obstacle_Y{0:000}", index),
                new Vector3(0, index * 10, 0),
                Color.green);

            this.CreateObstacle(
                string.Format(CultureInfo.InvariantCulture, "Obstacle_Z{0:000}", index),
                new Vector3(0, 0, index * 10),
                Color.blue);
        }
    }

    private void CreateObstacle(string id, Vector3 position, Color color)
    {
        var obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);

        obstacle.name = id;
        obstacle.transform.position = position;
        obstacle.transform.parent = this.gameObject.transform;
        obstacle.GetComponent<Renderer>().material.color = color;
    }
}