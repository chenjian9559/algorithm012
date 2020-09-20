# 总结

> **算法源代码在每个项目里的program.cs 文件里** 

- [字典树](#字典树)
- [并查集](#并查集)
- [高级搜索](#高级搜索)
  - [剪枝](#剪枝)
  - [双向BFS](#双向BFS)
  - [启发式搜索](#启发式搜索)
- [红黑树](#红黑树)
- [AVL树](#AVL树)
- [AVL树和红黑树对比](#**AVL树和红黑树对比** )

## 字典树

**基本结构**

字典树(Trie树)，又称单词查找树，是一种树形结构。

典型应用： 统计和排序大量的字符串（不限与字符串）。

经常被搜索引擎文本词汇统计。

*优点： 最大限度的减少无谓的字符串比较，查询效率比哈希还高。*

**基本性质**

- 结点本身不存完整单词；  

- 从根结点到某一结点，路径上经过的字符连接起来，为该结点对应的字符串；  
- 每个结点的所有子结点路径代表的字符都不相同。

**核心思想** 

- 空间换时间。
- 利用字符串的公共前缀来降低查询时间的开销以达到提高效率的目的。

## 并查集

**场景**
	组团、配对问题。

**基本操作**
- makeSet(s)：建立一个新的并查集，其中包含 s 个单元素集合。
- unionSet(x, y)：把元素 x 和元素 y 所在的集合合并，要求 x 和 y 所在的集合不相交，如果相交则不合并。
- find(x)：找到元素 x 所在的集合的代表，该操作也可以用于判断两个元素是否位于同一个集合，只要将它们各自的代表比较一下就可以了。

## 高级搜索

### 剪枝

在递归时 在整个状态树 这一个分治在没有必要的时候，那么我们就把他剪掉。

这种没有必要性是来自重复 或者 每次找最优解，有一个分支是不够优或者次优的，就把这个剪掉。



### 双向BFS

从两个方向同时进行BFS。

从两端开始搜索，中间相遇。 

**代码模板**

```c#
// TODO

```

启发式搜索

启发式搜索（Heuristic Search），又称**A*算法，**优先搜索。

启发式函数，又称估价函数，h(n)用来评价哪些结点最有希望的是一个我们要找的节点，h(n)会返回一个非负实数，也可以认为是从结点n的目标结点路径的估计成本。

启发式函数是一种告知搜索方向的方法。它提供了一种明智的方法来猜测哪个邻居结点会导向下一个目标 。

**代码模板**

```Python
# Python
def AstarSearch(graph, start, end):
	pq = collections.priority_queue() # 优先级 —> 估价函数
	pq.append([start]) 
	visited.add(start)

	while pq: 
		node = pq.pop() # can we add more intelligence here ?
		visited.add(node)
		process(node) 
		nodes = generate_related_nodes(node) 
    unvisited = [node for node in nodes if node not in visited]
		pq.push(unvisited)

```



```java
//Java
public class AStar
{
	public final static int BAR = 1; // 障碍值
	public final static int PATH = 2; // 路径
	public final static int DIRECT_VALUE = 10; // 横竖移动代价
	public final static int OBLIQUE_VALUE = 14; // 斜移动代价
		
	Queue<Node> openList = new PriorityQueue<Node>(); // 优先队列(升序)
	List<Node> closeList = new ArrayList<Node>();
		
    /**
	 * 开始算法
	 */
	public void start(MapInfo mapInfo)
	{
			if(mapInfo==null) return;
			// clean
			openList.clear();
			closeList.clear();
			// 开始搜索
			openList.add(mapInfo.start);
			moveNodes(mapInfo);
	}
	/**
	 * 移动当前结点
	 */
	private void moveNodes(MapInfo mapInfo)
	{
		while (!openList.isEmpty())
		{
			Node current = openList.poll();
			closeList.add(current);
			addNeighborNodeInOpen(mapInfo,current);
			if (isCoordInClose(mapInfo.end.coord))
			{
				drawPath(mapInfo.maps, mapInfo.end);
				break;
			}
		}
	}
		
	/**
	 * 在二维数组中绘制路径
	 */
	private void drawPath(int[][] maps, Node end)
	{
		if(end==null||maps==null) return;
		System.out.println("总代价：" + end.G);
		while (end != null)
		{
			Coord c = end.coord;
			maps[c.y][c.x] = PATH;
			end = end.parent;
		}
	}

	/**
	 * 添加所有邻结点到open表
	 */
	private void addNeighborNodeInOpen(MapInfo mapInfo,Node current)
	{
		int x = current.coord.x;
		int y = current.coord.y;
		// 左
		addNeighborNodeInOpen(mapInfo,current, x - 1, y, DIRECT_VALUE);
		// 上
		addNeighborNodeInOpen(mapInfo,current, x, y - 1, DIRECT_VALUE);
		// 右
		addNeighborNodeInOpen(mapInfo,current, x + 1, y, DIRECT_VALUE);
		// 下
		addNeighborNodeInOpen(mapInfo,current, x, y + 1, DIRECT_VALUE);
		// 左上
		addNeighborNodeInOpen(mapInfo,current, x - 1, y - 1, OBLIQUE_VALUE);
		// 右上
		addNeighborNodeInOpen(mapInfo,current, x + 1, y - 1, OBLIQUE_VALUE);
		// 右下
		addNeighborNodeInOpen(mapInfo,current, x + 1, y + 1, OBLIQUE_VALUE);
		// 左下
		addNeighborNodeInOpen(mapInfo,current, x - 1, y + 1, OBLIQUE_VALUE);
	}
	/**
	 * 添加一个邻结点到open表
	 */
	private void addNeighborNodeInOpen(MapInfo mapInfo,Node current, int x, int y, int value)
	{
		if (canAddNodeToOpen(mapInfo,x, y))
		{
			Node end=mapInfo.end;
			Coord coord = new Coord(x, y);
			int G = current.G + value; // 计算邻结点的G值
			Node child = findNodeInOpen(coord);
			if (child == null)
			{
				int H=calcH(end.coord,coord); // 计算H值
				if(isEndNode(end.coord,coord))
				{
					child=end;
					child.parent=current;
					child.G=G;
					child.H=H;
				}
				else
				{
					child = new Node(coord, current, G, H);
				}
				openList.add(child);
			}
			else if (child.G > G)
			{
				child.G = G;
				child.parent = current;
				openList.add(child);
			}
		}
	}

	/**
	 * 从Open列表中查找结点
	 */
	private Node findNodeInOpen(Coord coord) {
		if (coord == null || openList.isEmpty()) return null;
		for (Node node : openList) {
			if (node.coord.equals(coord)) {
				return node;
			}
		}
		return null;
	}
	/**
	 * 计算H的估值：“曼哈顿”法，坐标分别取差值相加
	 */
	private int calcH(Coord end,Coord coord) {
		return Math.abs(end.x - coord.x) + Math.abs(end.y - coord.y);
	}
	/**
	 * 判断结点是否是最终结点
	 */
	private boolean isEndNode(Coord end,Coord coord) {
		return coord != null && end.equals(coord);
	}

	/**
	 * 判断结点能否放入Open列表
	 */
	private boolean canAddNodeToOpen(MapInfo mapInfo,int x, int y) {
		// 是否在地图中
		if (x < 0 || x >= mapInfo.width || y < 0 || y >= mapInfo.hight) return false;
		// 判断是否是不可通过的结点
		if (mapInfo.maps[y][x] == BAR) 
			return false;
		// 判断结点是否存在close表
		if (isCoordInClose(x, y)) 
			return false;
		return true;
	}
	/**
	 * 判断坐标是否在close表中
	 */
	private boolean isCoordInClose(Coord coord) {
		return coord!=null&&isCoordInClose(coord.x, coord.y);
	}
	/**
	 * 判断坐标是否在close表中
	 */
	private boolean isCoordInClose(int x, int y) {
		if (closeList.isEmpty()) return false;
		for (Node node : closeList) {
			if (node.coord.x == x && node.coord.y == y){
					return true;
			}
		}
		return false;
	}
}
```

```Javascript
// Javascript
function aStarSearch(graph, start, end) {
  // graph 使用二维数组来存储数据
  let collection = new SortedArray([start], (p1, p2) => distance(p1) - distance(p2));

  while (collection.length) {
    let [x, y] = collection.take();
    if (x === end[0] && y === end[1]) {
      return true;
    }

    insert([x - 1, y]);
    insert([x + 1, y]);
    insert([x, y - 1]);
    insert([x, y + 1]);
  }
  return false;

  function distance([x, y]) {
    return (x - end[0]) ** 2 - (y - end[1]) ** 2;
  }

  function insert([x, y]) {
    if (graph[x][y] !== 0) return;
    if (x < 0 || y < 0 || x >= graph[0].length || y > graph.length) {
      return;
    }
    graph[x][y] = 2;
    collection.insert([x, y]);
  }
}


class SortedArray {
  constructor(data, compare) {
    this.data = data;
    this.compare = compare;
  }

  // 每次取最小值
  take() {
    let min = this.data[0];

    let minIndex = 0;
    for (let i = 1; i < this.data.length; i++) {
      if (this.compare(min, this.data[i]) > 0) {
        min = this.data[i];
        minIndex = i;
      }
    }
    this.data[minIndex] = this.data[this.data.length - 1];
    this.data.push();

    return min;
  }

  insert(value) {
    this.data.push(value);
  }

  get length() {
    return this.data.length;
  }
}
```



## 红黑树

红黑树是一种近似平衡的二叉搜索树（Binary Search Tree），它能够确保任何一个结点的左右子树的高度差小于两倍。

具体来说，红黑树是满足如下条件的二叉搜索树： 

-  每个结点要么是红色，要么是黑色。 

-  根结点是黑色 。
-  每个叶结点（NIL结点，空结点）是黑色的。 
-  不能有相邻接的两个红色结点。 
-  从任一结点到其每个叶子的所有路径都包含相同数目的黑色结点。

**关键性质**

从根到叶子的最长的可能路径不多于最短的可能路径的两倍长。 

## AVL树

1. 发明者 G. M. Adelson-Velsky和 Evgenii Landis .

2. Balance Factor（平衡因子）： 

   - 是它的左子树的高度减去它的右子树的高度（有时相反）。 

   - balance factor = {-1, 0, 1} 

3. 通过旋转操作来进行平衡（四种）

    - 左旋 
    - 右旋 
    - 左右旋 
    - 右左旋

4. https://en.wikipedia.org/wiki/Self-balancing_binary_search_tree

  ​     
  **不足**：结点需要存储额外信息、且调整次数频繁 。

  

## **AVL树和红黑树对比** 

-  AVL trees provide faster lookups than Red Black Trees because they are more strictly balanced. 
  - AVL树查询更快，因为是严格平衡树
- Red Black Trees provide faster insertion and removal operations than AVL trees as  fewer rotations are done due to relatively relaxed balancing. 
  - 红黑树插入和删除更快，因为不用频繁进行旋转操作
- AVL trees store balance factors or heights with each node, thus requires storage for  an integer per node whereas Red Black Tree requires only 1 bit of information per  node. 
  - AVL树每个节点会存储平衡因子或高度，因而每个节点需要存储一个整数， 而红黑树每个节点只用1位。
- Red Black Trees are used in most of the language libraries  like map, multimap, multisetin C++ whereas AVL trees are used in databases where  faster retrievals are required.
  - 红黑树在大多数语言库（例如C ++中的map，multimap，multiset）中使用，而AVL树用在需要更快检索的databases 中使用。