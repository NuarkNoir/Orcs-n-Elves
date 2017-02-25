/**
***		Generates game map from *.nl files, which contains len, wid and matrix of map.
***		Created by Nuark on 25.02.17 23:47
**/

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject BigCubeFloor, BigCubeWall;
	int c_x = 0;
	int c_y = 0;

	void Start () {
		string[] file = File.ReadAllLines (Application.dataPath + "/Levels/1.nl");
		print (file [0] + "x" + file [1] + " map loading...");
		//onx is |	ony is -
		int onx = int.Parse(file [0]);
		int ony = int.Parse(file [1]);
		//Map matrix
		string[,] mat = new string[onx, ony];

		print ("Map matrix:");
		for (int i = 0; i < onx; i++) {
			file [i + 2] = ReverseArrayManual (file [i + 2]);
			for (int j = 0; j < ony; j++) {
				mat [i, j] = file [i + 2][j].ToString();
			}
		}

		for (int i = 0; i < onx; i++){
			for (int j = 0; j < ony; j++){
				instantianator(mat[i,j], c_x, c_y);
				c_x += 4;
			};
			c_x = 0;
			c_y += 4;
		};
		print ("Map loaded.");
	}

	void instantianator(string type, int c_x, int c_y){
		switch (type) {
		case "■":
			Instantiate (BigCubeWall, new Vector3 (c_x, 3.0f, c_y), new Quaternion ());
			break;
		case "□":
			Instantiate (BigCubeFloor, new Vector3 (c_x, 0f, c_y), new Quaternion ());
			break;
		}
	}	
	
    static string ReverseArrayManual(string originalString)
    {
        char[] reversedCharArray = new char[originalString.Length];
        for (int i = originalString.Length - 1; i > -1; i--)
            reversedCharArray[originalString.Length - i - 1] = originalString[i];
        return new string(reversedCharArray);
    }

}
