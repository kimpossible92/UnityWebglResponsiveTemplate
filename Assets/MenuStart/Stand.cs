using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stand
{
    internal int width;
    internal int height;
    // Start is called before the first frame update
    internal void Start(int width1,int height1)
    {
        width = width1;
        height = height1;
    }
    internal void setColor(Material sprite1,string c)
    {
        if (c == "white") sprite1.color = Color.white;
        if (c == "red") sprite1.color = Color.red;
        if (c == "green") sprite1.color = Color.green;
        if (c == "blue") sprite1.color = Color.blue;
        if (c == "gray") sprite1.color = Color.gray;
        if (c == "grey") sprite1.color = Color.grey;
        if (c == "cyan") sprite1.color = Color.cyan;
        if (c == "yellow") sprite1.color = Color.yellow;
        if (c == "black") sprite1.color = Color.black;
        if (c == "magenta") sprite1.color = Color.magenta;
        if (c == "c1") sprite1.color = Color.Lerp(Color.red, Color.green, 0.1f);
        if (c == "c2") sprite1.color = Color.Lerp(Color.black, Color.green, 0.4f);
        if (c == "c3") sprite1.color = Color.Lerp(Color.red, Color.black, 0.8f);
        if (c == "c4") sprite1.color = Color.Lerp(Color.red, Color.black, 0.8f);
    }
    internal void SetImageColor(Image sprite1, string c)
    {
        if (c == "white") sprite1.color = Color.white;
        if (c == "red") sprite1.color = Color.red;
        if (c == "green") sprite1.color = Color.green;
        if (c == "blue") sprite1.color = Color.blue;
        if (c == "gray") sprite1.color = Color.gray;
        if (c == "grey") sprite1.color = Color.grey;
        if (c == "cyan") sprite1.color = Color.cyan;
        if (c == "yellow") sprite1.color = Color.yellow;
        if (c == "black") sprite1.color = Color.black;
        if (c == "magenta") sprite1.color = Color.magenta;
        if (c == "c1") sprite1.color = Color.Lerp(Color.red, Color.green, 0.1f);
        if (c == "c2") sprite1.color = Color.Lerp(Color.black, Color.green, 0.4f);
        if (c == "c3") sprite1.color = Color.Lerp(Color.red, Color.black, 0.8f);
        if (c == "c4") sprite1.color = Color.Lerp(Color.red, Color.black, 0.8f);
    }
    // Update is called once per frame
    internal void Update()
    {
        
    }
}
