using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshGen : MonoBehaviour {

	public SquareGrid squareGrid;
	public MeshFilter walls;
	public MeshFilter level;

	List<Vector3> vertices; //list of vector3 vertices
	List<int> triangles; //list of int triangles

	//Dictionary, takes in key and value, key = int generates list of triangles for a vertex, value is the list of triangles
	Dictionary<int,List<Triangle>> triangleDictionary = new Dictionary<int, List<Triangle>> ();
	List<List<int>> outlines = new List<List<int>> (); //Int list of outlines 
	HashSet<int> checkedVertices = new HashSet<int>(); //Hash used to check vertices and not having to check them again, quicker checks

	public void GenerateMesh(int[,] map, float squareSize) {
		//reset variables with every generation of new mesh for triangledictionary, outlines and checkedVertices
		triangleDictionary.Clear ();
		outlines.Clear ();
		checkedVertices.Clear ();

		squareGrid = new SquareGrid(map, squareSize);

		vertices = new List<Vector3>(); //intialises lists
		triangles = new List<int>();

		//for each square grid triangulate the square
		for (int x = 0; x < squareGrid.squares.GetLength(0); x ++) {
			for (int y = 0; y < squareGrid.squares.GetLength(1); y ++) {
				TriangulateSquare(squareGrid.squares[x,y]);
			}
		}

		Mesh mesh = new Mesh();
		//GetComponent<MeshFilter>().mesh = mesh;
		level.mesh = mesh;

		mesh.vertices = vertices.ToArray(); //covert list to array
		mesh.triangles = triangles.ToArray(); //convert triangles list to array
		mesh.RecalculateNormals();

		CreateWallMesh ();
	}

	void CreateWallMesh() {

		CalculateMeshOutlines (); //call method

		List<Vector3> wallVertices = new List<Vector3> ();
		List<int> wallTriangles = new List<int> ();
		Mesh wallMesh = new Mesh ();
		float wallHeight = 7;//5

		//go through every outline in outline list, loop through each vertex
		foreach (List<int> outline in outlines) {
			for (int i = 0; i < outline.Count -1; i ++) { // -1 to prevent outofbounds
				int startIndex = wallVertices.Count; 
				wallVertices.Add(vertices[outline[i]]); //top left
				wallVertices.Add(vertices[outline[i+1]]); // top right
				wallVertices.Add(vertices[outline[i]] - Vector3.up * wallHeight); // bottom left
				wallVertices.Add(vertices[outline[i+1]] - Vector3.up * wallHeight); // bottom right

				//1st triangle ,Assign vertices, winding anti-clockwise (L->BL->BR)
				wallTriangles.Add(startIndex + 0);
				wallTriangles.Add(startIndex + 2);
				wallTriangles.Add(startIndex + 3);
				//2nd triangle, (BR->TR->TL)
				wallTriangles.Add(startIndex + 3);
				wallTriangles.Add(startIndex + 1);
				wallTriangles.Add(startIndex + 0);
			}
		}
		wallMesh.vertices = wallVertices.ToArray (); //convert to array
		wallMesh.triangles = wallTriangles.ToArray ();//to array 
		walls.mesh = wallMesh;// assign to Mesh Filter object 
		//Problem here with map regeneration, creates a new wall mesh each time with collision physics. Delete oldest wall mesh
		//FIXED
		MeshCollider wallCollider = walls.gameObject.AddComponent<MeshCollider> ();
		wallCollider.sharedMesh = wallMesh;
	}

	public void removeWallMesh()
	{
		MeshCollider wallCollider = walls.gameObject.GetComponent<MeshCollider> ();
		Destroy (wallCollider);
		//Debug.Log ("Wall Mesh removed");
	}

	void TriangulateSquare(Square square) {

		// 16 possible cased for configurations of points
		switch (square.configuration) {
		case 0:
			break; //no points so no mesh

			// 1 points
		case 1: //see diagram for explanation of triangles in squares 
			MeshFromPoints(square.centreLeft, square.centreBottom, square.bottomLeft);
			break;
		case 2:
			MeshFromPoints(square.bottomRight, square.centreBottom, square.centreRight);
			break;
		case 4:
			MeshFromPoints(square.topRight, square.centreRight, square.centreTop);
			break;
		case 8:
			MeshFromPoints(square.topLeft, square.centreTop, square.centreLeft);
			break;

			// 2 points
		case 3:
			MeshFromPoints(square.centreRight, square.bottomRight, square.bottomLeft, square.centreLeft);
			break;
		case 6:
			MeshFromPoints(square.centreTop, square.topRight, square.bottomRight, square.centreBottom);
			break;
		case 9:
			MeshFromPoints(square.topLeft, square.centreTop, square.centreBottom, square.bottomLeft);
			break;
		case 12:
			MeshFromPoints(square.topLeft, square.topRight, square.centreRight, square.centreLeft);
			break;
		case 5:
			MeshFromPoints(square.centreTop, square.topRight, square.centreRight, square.centreBottom, square.bottomLeft, square.centreLeft);
			break;
		case 10:
			MeshFromPoints(square.topLeft, square.centreTop, square.centreRight, square.bottomRight, square.centreBottom, square.centreLeft);
			break;

			// 3 point
		case 7:
			MeshFromPoints(square.centreTop, square.topRight, square.bottomRight, square.bottomLeft, square.centreLeft);
			break;
		case 11:
			MeshFromPoints(square.topLeft, square.centreTop, square.centreRight, square.bottomRight, square.bottomLeft);
			break;
		case 13:
			MeshFromPoints(square.topLeft, square.topRight, square.centreRight, square.centreBottom, square.bottomLeft);
			break;
		case 14:
			MeshFromPoints(square.topLeft, square.topRight, square.bottomRight, square.centreBottom, square.centreLeft);
			break;

			// 4 point
		case 15: //all four points are active and all walls, automatically added to check vertices
			MeshFromPoints(square.topLeft, square.topRight, square.bottomRight, square.bottomLeft);
			checkedVertices.Add(square.topLeft.vertexIndex);
			checkedVertices.Add(square.topRight.vertexIndex);
			checkedVertices.Add(square.bottomRight.vertexIndex);
			checkedVertices.Add(square.bottomLeft.vertexIndex);
			break;
		}
	}

	void MeshFromPoints(params Node[] points) { //Takes in points and creates mesh , //params for unknown number
		AssignVertices(points); //passes in points

		//creation of mesh through the use triangles
		if (points.Length >= 3)
			CreateTriangle(points[0], points[1], points[2]);
		if (points.Length >= 4)
			CreateTriangle(points[0], points[2], points[3]);
		if (points.Length >= 5) 
			CreateTriangle(points[0], points[3], points[4]);
		if (points.Length >= 6)
			CreateTriangle(points[0], points[4], points[5]);

	}

	void AssignVertices(Node[] points) { //takes in array of nodes, loops through the list of points with increments
		for (int i = 0; i < points.Length; i ++) {
			if (points[i].vertexIndex == -1) { //vertex index - 1 is default, shows it is unassigned
				points[i].vertexIndex = vertices.Count; //first point will have a vertice count of 0
				vertices.Add(points[i].position);
			}
		}
	}

	void CreateTriangle(Node a, Node b, Node c) { //takes in 3 nodes, gets the points from triangle list and vertex index
		triangles.Add(a.vertexIndex);
		triangles.Add(b.vertexIndex);
		triangles.Add(c.vertexIndex);

		Triangle triangle = new Triangle (a.vertexIndex, b.vertexIndex, c.vertexIndex); //see AddTriangleToDictionary method
		AddTriangleToDictionary (triangle.vertexIndexA/*key*/, triangle);
		AddTriangleToDictionary (triangle.vertexIndexB, triangle);
		AddTriangleToDictionary (triangle.vertexIndexC, triangle);
	}

	void AddTriangleToDictionary(int vertexIndexKey, Triangle triangle) {
		if (triangleDictionary.ContainsKey (vertexIndexKey)) { 
			triangleDictionary [vertexIndexKey].Add (triangle);
		} else {
			List<Triangle> triangleList = new List<Triangle>();// if dictionary does not contain vertex then new triangle is added to dictionary 
			triangleList.Add(triangle);
			triangleDictionary.Add(vertexIndexKey, triangleList);
		}
	}

	void CalculateMeshOutlines() { //go through every vertex in map and check every outline vertex and follow outline until it reconnectes with itself and then adds this to list 

		for (int vertexIndex = 0; vertexIndex < vertices.Count; vertexIndex ++) {
			if (!checkedVertices.Contains(vertexIndex)) {
				int newOutlineVertex = GetConnectedOutlineVertex(vertexIndex);
				if (newOutlineVertex != -1) {
					checkedVertices.Add(vertexIndex);

					List<int> newOutline = new List<int>();
					newOutline.Add(vertexIndex);
					outlines.Add(newOutline);
					FollowOutline(newOutlineVertex, outlines.Count-1); // call to method
					outlines[outlines.Count-1].Add(vertexIndex);
				}
			}
		}
	}

	void FollowOutline(int vertexIndex, int outlineIndex) { //takes in int for outline index and vertex index
		outlines [outlineIndex].Add (vertexIndex);
		checkedVertices.Add (vertexIndex); 
		int nextVertexIndex = GetConnectedOutlineVertex (vertexIndex);

		if (nextVertexIndex != -1) {
			FollowOutline(nextVertexIndex, outlineIndex);
		}
	}

	int GetConnectedOutlineVertex(int vertexIndex) { //finds connected vertex to form outside edge
		List<Triangle> trianglesContainingVertex = triangleDictionary [vertexIndex];

		for (int i = 0; i < trianglesContainingVertex.Count; i ++) { //looping through triangles
			Triangle triangle = trianglesContainingVertex[i]; //look at  edges of a triangle along with the vertex A and B and see if forms a edge

			for (int j = 0; j < 3; j ++) {
				int vertexB = triangle[j];
				if (vertexB != vertexIndex && !checkedVertices.Contains(vertexB)) //prevents infinite loop of vertexB = VertexIndex
				{
					if (IsOutlineEdge(vertexIndex, vertexB)) {
						return vertexB;
					}
				}
			}
		}

		return -1; //if no connected vertex with no edge 
	}

	bool IsOutlineEdge(int vertexA, int vertexB) {
		List<Triangle> trianglesContainingVertexA = triangleDictionary [vertexA]; // getting list of all the triangles that vertex A belongs to and how many triangles share with vertex B
																				  //if one common triangle is found then it is a outline edge
		int sharedTriangleCount = 0;

		for (int i = 0; i < trianglesContainingVertexA.Count; i ++) {
			if (trianglesContainingVertexA[i].Contains(vertexB)) {
				sharedTriangleCount ++;
				if (sharedTriangleCount > 1) {
					break;
				}
			}
		}
		return sharedTriangleCount == 1;
	}

	struct Triangle { //needed to create wall edges, which triangle does a vertex belong to
		public int vertexIndexA;
		public int vertexIndexB;
		public int vertexIndexC;
		int[] vertices; //integer array of vertices

		public Triangle (int a, int b, int c) { //constructor 
			vertexIndexA = a;
			vertexIndexB = b;
			vertexIndexC = c;

			vertices = new int[3]; 
			vertices[0] = a;
			vertices[1] = b;
			vertices[2] = c;
		}
		//Indexer, allows access of vertices of triangle like array
		public int this[int i] {
			get {
				return vertices[i];
			}
		}


		public bool Contains(int vertexIndex) { // returns vertex index, for outline edge
			return vertexIndex == vertexIndexA || vertexIndex == vertexIndexB || vertexIndex == vertexIndexC;
		}
	}

	public class SquareGrid { 
		public Square[,] squares; //holds 2D arrays of squares

		public SquareGrid(int[,] map, float squareSize) { //constructor, gets map from mapGen
			int nodeCountX = map.GetLength(0);
			int nodeCountY = map.GetLength(1);
			float mapWidth = nodeCountX * squareSize;
			float mapHeight = nodeCountY * squareSize;

			ControlNode[,] controlNodes = new ControlNode[nodeCountX,nodeCountY]; //2D array of control nodes

			for (int x = 0; x < nodeCountX; x ++) {
				for (int y = 0; y < nodeCountY; y ++) {
					Vector3 pos = new Vector3(-mapWidth/2 + x * squareSize + squareSize/2, 0, -mapHeight/2 + y * squareSize + squareSize/2); //Calculate positions of control node
					controlNodes[x,y] = new ControlNode(pos,map[x,y] == 1, squareSize); // map is active if = 1 , // grid of control nodes
				}
			}

			squares = new Square[nodeCountX -1,nodeCountY -1]; //creation of grid of squares from control nodes
			for (int x = 0; x < nodeCountX-1; x ++) {
				for (int y = 0; y < nodeCountY-1; y ++) {
					squares[x,y] = new Square(controlNodes[x,y+1] /*topleft*/ , controlNodes[x+1,y+1] /*topright*/ , controlNodes[x+1,y] /*bottomright*/ , controlNodes[x,y] /*bottomleft*/ ); //each square equal to new square with control node attributes from array
				}
			}
		}
	}

	public class Square { //references all 4 control nodes of a square

		public ControlNode topLeft, topRight, bottomRight, bottomLeft;
		public Node centreTop, centreRight, centreBottom, centreLeft;
		public int configuration; //16 possible configuaration of a square , control nodes 

		public Square (ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomRight, ControlNode _bottomLeft) { // constructor
			topLeft = _topLeft;
			topRight = _topRight;
			bottomRight = _bottomRight;
			bottomLeft = _bottomLeft;

			centreTop = topLeft.right;
			centreRight = bottomRight.above;
			centreBottom = bottomLeft.right;
			centreLeft = bottomLeft.above;

			//Nodes that are active generate number
			if (topLeft.active)
				configuration += 8;
			if (topRight.active)
				configuration += 4;
			if (bottomRight.active)
				configuration += 2;
			if (bottomLeft.active)
				configuration += 1;
		}
	}

	public class Node { //node for a square
		public Vector3 position;
		public int vertexIndex = -1;

		public Node(Vector3 _pos) {
			position = _pos;
		}
	}

	public class ControlNode : Node { //inherit from Node class

		public bool active; //wall or not wall
		public Node above, right; 

		public ControlNode (Vector3 _pos, bool _active, float squareSize) : base(_pos) { //constructor
			active = _active;
			above = new Node(position + Vector3.forward * squareSize/2f);
			right = new Node(position + Vector3.right * squareSize/2f);
		}
	}
}