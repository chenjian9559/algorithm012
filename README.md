# 总结



## 学习方法

算法学习和练习 **一定要过遍数，一定要过遍数，一定要过遍**数----重要的事说三遍。

遇到不懂的地方不要死磕，超过5分钟想不出来马上找题解或资料。敢于放手、敢于死记硬背。慢慢的就理解了。

重要过遍数，而不是每次花很长时间。

- 第一遍，思考题目的解法，没有思路直接看题解，默写背诵。  

- 第二遍，马上自己写，重新刷一遍题目。  

- 第三遍，过了一天再重复做题。 

- 第四遍，过了一周反复回来练习相同题目。  

- 第五遍，恢复性训练。

  持续的刻意练习，去面对，然后熟视无睹。

## 时间复杂度分析

常用的时间复杂度有:

1. O(1) Constant Complexity 常数时间复杂度
2. O(log n) Logarithmic Complexity  对数复杂度
3. O(n) Linear Complexity 线性时间复杂度
4. O(n^2) N square Complexity 平方
5. O(n^3) N cubic Complexity 立方
6. O(2^n)Exponential Growth 指数
7. O(n!) Factorial 阶乘

## 空间时间复杂度分析

原则:
    申请数组的长度
    递归的深度

-------



## 数据结构

 数据接口可分一维、二维、特殊数据结构；  

- 一维
  - 数组、链表 
  - 栈、队列、双端队列、集合。   
- 二维
  - 数、图   
  - 二叉搜索树、堆、并查集、字典树    
- 特殊
  - 位运算等。

------



### 字典树

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

### 并查集

**场景**
	组团、配对问题。

**基本操作**

- makeSet(s)：建立一个新的并查集，其中包含 s 个单元素集合。

- unionSet(x, y)：把元素 x 和元素 y 所在的集合合并，要求 x 和 y 所在的集合不相交，如果相交则不合并。

- find(x)：找到元素 x 所在的集合的代表，该操作也可以用于判断两个元素是否位于同一个集合，只要将它们各自的代表比较一下就可以了。

### 红黑树

红黑树是一种近似平衡的二叉搜索树（Binary Search Tree），它能够确保任何一个结点的左右子树的高度差小于两倍。

具体来说，红黑树是满足如下条件的二叉搜索树： 

- 每个结点要么是红色，要么是黑色。 
- 根结点是黑色 。
- 每个叶结点（NIL结点，空结点）是黑色的。 
- 不能有相邻接的两个红色结点。 
- 从任一结点到其每个叶子的所有路径都包含相同数目的黑色结点。

**关键性质**

从根到叶子的最长的可能路径不多于最短的可能路径的两倍长。 

### AVL树

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

   

### **AVL树和红黑树对比**

- AVL trees provide faster lookups than Red Black Trees because they are more strictly balanced. 
  - AVL树查询更快，因为是严格平衡树

- Red Black Trees provide faster insertion and removal operations than AVL trees as  fewer rotations are done due to relatively relaxed balancing. 
  - 红黑树插入和删除更快，因为不用频繁进行旋转操作

- AVL trees store balance factors or heights with each node, thus requires storage for  an integer per node whereas Red Black Tree requires only 1 bit of information per  node. 
  - AVL树每个节点会存储平衡因子或高度，因而每个节点需要存储一个整数， 而红黑树每个节点只用1位。

- Red Black Trees are used in most of the language libraries  like map, multimap, multisetin C++ whereas AVL trees are used in databases where  faster retrievals are required.
  - 红黑树在大多数语言库（例如C ++中的map，multimap，multiset）中使用，而AVL树用在需要更快检索的databases 中使用。

### 布隆过滤器

是一个占用空间很小，效率很高的随机数据结构 。

一个很长的二进制向量和一系列随机映射函数。布隆过滤器可以用于检索 一个元素是否在一个集合中。 

优点: 是空间效率和查询时间都远远超过一般的算法，  

缺点: 是有一定的误识别率和删除困难。

#### 什么情况下需要布隆过滤器？

案例 : 

- 先来看几个比较常见的例子
- 字处理软件中，需要检查一个英语单词是否拼写正确
- 在 FBI，一个嫌疑人的名字是否已经在嫌疑名单上
- 在网络爬虫里，一个网址是否被访问过
- 比特币网络  
- 分布式系统（Map-Reduce） — Hadoop、search engine  
- Redis 缓存  
- 垃圾邮件、评论等的过滤 

#### 布隆过滤器原理

布隆过滤器（Bloom Filter）的核心实现是一个超大的位数组和几个哈希函数。假设位数组的长度为m，哈希函数的个数为k.

#### 布隆过滤器添加元素

- 将要添加的元素给k个哈希函数
- 得到对应于位数组上的k个位置
- 将这k个位置设为1

#### 布隆过滤器查询元素

- 将要查询的元素给k个哈希函数
- 得到对应于位数组上的k个位置
- 如果k个位置有一个为0，则肯定不在集合中
- 如果k个位置全部为1，则可能在集合中

### LRU缓存

- 两个要素： 大小 、替换策略  
- Hash Table + Double LinkedList  
- O(1) 查询  
  O(1) 修改、更新

-------------




## 算法

- if-else switch -> branch
- for while loop -> iteration
- 递归 Recursion
- 搜索 ：深度优先搜索(DFS)、广度优先搜索 (BFS)、A*、etc 
- 动态规划 Dynamic Programming, 求最优解的问题。
- 二分查找 Binary Search
- 贪心 Greedy
- 数学 Math、几何Geometry

### 感触

1. 人肉递归低效、很累
2. 找到最近最简方法，将其拆解成可重复解决的问题
3. 数学归纳法思维
4. 代码风格
   - 规范写代码
   - 快捷键的熟练使用
   - **自顶向下编程方式：重点在前面，逻辑在后面**

----------

### 递归 Recursion

泛型递归、树的递归 

递归**本质上是循环**

​	通过函数体来进行的循环 

核心思想是把规模大的问题转化为规模小的相似的子问题来解决。

**思维要点：**

1. 不要人肉进行递归（最大误区）  
2. 找到最近最简方法，将其拆解成可重复解决的问题（重复子问题）  
3. 数学归纳法思维

#### 递归代码模板

1. recursion terminator 递归终结

2. process logic in current level 处理当前层逻辑

3. drill down 下探下层

4. reverse the current level status if needed. 清理当前层

   Javascript 代码模板

```javascript
// JavaScript
const recursion = (level, params) =>{
	// recursion terminator 递归终止条件
	if(level > MAX_LEVEL){
  		process_result
  		return 
	}
	// process current level 处理当前层逻辑
	process(level, params)
	//drill down 下探到下一层
	recursion(level+1, params)
	//clean current level status if needed 清理当前层
}
```

### 分治 Divide & Conquer

​	分治和回溯的**本质上也是递归**，算是其中一个的细分类，可能认为特殊或者比较复杂的递归。

***分治***：找问题的重复性。
	重复性有：
		<u>最近重复性</u>：分治/回溯 
		<u>最优重复性</u>：动态规划

​	问题拆机成小问题处理后，组合结果后返回。代码上是递归，是一种函数自我调用缩小问题规模的方法。
	从字面的意思来看，分治法的核心思想就是“分而治之”。利用分而治之的思想，就可以把一个大规模、高难度的问题，分解为若干个小规模、低难度的小问题。

使用方法： 分解问题 =》解决问题 =》合并结果 =》 分解问题 ...

### 分治代码模板

1. 递归终止条件;

2. 处理当前逻辑，将大问题如何分解成一个个子问题;

3. 下探到下一层，各个层级解决各个层级的问题;

4. 组装各个层级的结果;

5. 清理当前层;

   Python 代码模板

```python
Python
def divide_conquer(problem, param1, param2, ...): 
  # recursion terminator 
  if problem is None: 
	print_result 
	return 

  # prepare data 
  data = prepare_data(problem) 
  subproblems = split_problem(problem, data) 

  # conquer subproblems 
  subresult1 = self.divide_conquer(subproblems[0], p1, ...) 
  subresult2 = self.divide_conquer(subproblems[1], p1, ...) 
  subresult3 = self.divide_conquer(subproblems[2], p1, ...) 
  …

  # process and generate the final result 
  result = process_result(subresult1, subresult2, subresult3, …)
	
  # revert the current level states 
```



### 回溯 Backtracking

递归循环每一层进行尝试找出一个正确答案，最后分步方法都没有答案，那整个问题就没有答案。 

**百度百科解释**：

回溯法采用试错的思想，它尝试分步的去解决一个问题。在分步解决问题的过程 
中，当它通过尝试发现现有的分步答案不能得到有效的正确的解答的时候，它将 
取消上一步甚至是上几步的计算，再通过其它的可能的分步解答再次尝试寻找问 
题的答案。  

回溯法通常用最简单的递归方法来实现，在反复重复上述的步骤后可能出现两种 
情况：  

• 找到一个可能存在的正确的答案；  
• 在尝试了所有可能的分步方法后宣告该问题没有答案。  

在最坏的情况下，回溯法会导致一次复杂度为指数时间的计算。

### 搜索

• 每个节点都要访问一次  

**• 每个节点仅仅要访问一次**  

• 对于节点的访问顺序不限  

​	\- 深度优先：depth fifirst search  

​	\- 广度优先：breadth fifirst search

还有其他优先级搜索。

如果要比较智能搜索涉及到机器学习。

#### 深度优先搜索-DFS

##### DFS 代码模板

##### 递归写法

```python
#Python
visited = set()
def dfs(node, visited):
	if node in visited: # terminator
		# already visited 
		return 
		
	visited.add(node) 

	# process current node here. 
	...
	for next_node in node.children(): 
		if next_node not in visited: 
			dfs(next_node, visited)
```

##### 非递归写法

```python
#Python
def DFS(self, tree): 

	if tree.root is None: 
		return [] 

	visited, stack = [], [tree.root]

	while stack: 
		node = stack.pop() 
		visited.add(node)

		process (node) 
		nodes = generate_related_nodes(node) 
		stack.push(nodes) 

	# other processing work 
	...
```

#### 广度优先搜索-BFS

##### BFS 代码模板

```python
# Python
def BFS(graph, start, end):
    visited = set()
	queue = [] 
	queue.append([start]) 
	while queue: 
		node = queue.pop() 
		visited.add(node)
		process(node) 
		nodes = generate_related_nodes(node) 
		queue.push(nodes)
	# other processing work 
	...
```

### 贪心算法

> 贪心算法是一种在每一步选择中都才去在当前状态下最好或最优的选择 从而希望导致结果是全局最好或最优的算法。而与动态规划不同在于，贪心算法不能回退，动态规划会保存以前的结果，并根据以前的结果对当前进行选择，有回退功能。

> 贪心：当下做局部最优判断 
> 回溯：能够回退 
> 动态规划：最优判断 + 回退

### 动态规划

#### 注意

1. 人肉递归低效、很累  
2. 找到最近最简方法，将其拆解成可重复解决的问题  
3. 数学归纳法思维（抵制人肉递归的诱惑）

#### 本质

​	**寻找重复性 —> 计算机指令集** 

#### 关键点

- 动态规划 和 递归或者分治 没有根本上的区别（关键看有无最优的子结构）  
- 共性：找到重复子问题 
- 差异性：最优子结构、中途可以淘汰次优解

### 高级搜索

#### 剪枝

在递归时 在整个状态树 这一个分治在没有必要的时候，那么我们就把他剪掉。

这种没有必要性是来自重复 或者 每次找最优解，有一个分支是不够优或者次优的，就把这个剪掉。

#### 双向BFS

从两个方向同时进行BFS。

从两端开始搜索，中间相遇。 

**代码模板**

```c#
// TODO

```

### 启发式搜索

启发式搜索（Heuristic Search），又称**A*算法**，优先搜索。

启发式函数，又称估价函数，h(n)用来评价哪些结点最有希望的是一个我们要找的节点，h(n)会返回一个非负实数，也可以认为是从结点n的目标结点路径的估计成本。

启发式函数是一种告知搜索方向的方法。它提供了一种明智的方法来猜测哪个邻居结点会导向下一个目标 。

**代码模板**

```python
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

### 位运算

为什么需要位运算：机器里的数字表示方式和存储格式就是二进制 

#### **位运算符**

1. 左移(<<)：位向左移动，前面出去，后面补0.    eg: 0011 => 0110 

2. 右移(>>)：位向右移动，前面补0.     eg: 0110 => 0011

3. 按位或(|)：有1或1.       eg: 0011 -- 1011  => 1011 

4. 按位与(&)：有0与0 .     eg: 0011 -- 1011 =>  0011

5. 按位取反(~)：1变成0，0变成1.                       eg: 0011 => 1100 

6. ***XOR - 异或*** : 按位异或（相同为零不同为一） eg: 0011 --1011 =>1000 

   异或：相同为 0，不同为 1。也可用“不进位加法”来理解。 

   异或操作的一些特点： 

   x ^ 0 = x 

   x ^ 1s = ~x  // 注意 1s = ~0 

   x ^ (~x) = 1s 

   x ^ x = 0 

   c = a ^ b => a ^ c = b, b ^ c = a // 交换两个数 

   a ^ b ^ c = a ^ (b ^ c) = (a ^ b) ^ c // associative 

#### **指定位置的位运算**

1. 将 x 最右边的 n 位清零：x & (~0 << n) 
2. 获取 x 的第 n 位值（0 或者 1）： (x >> n) & 1 
3. 获取 x 的第 n 位的幂值：x & (1 << n) 
4. 仅将第 n 位置为 1：x | (1 << n) 
5. 仅将第 n 位置为 0：x & (~ (1 << n)) 
6. 将 x 最高位至第 n 位（含）清零：x & ((1 << n) - 1)

#### 实战位运算要点

- 判断奇偶： 

  ​	x % 2 == 1 —> (x & 1) == 1 

  ​	x % 2 == 0 —> (x & 1) == 0 

- x >> 1 —>  x / 2.  

  ​	  即： x = x / 2; —> x = x >> 1; 

  ​		  mid = (left + right) / 2; —> mid = (left + right) >> 1; 

- X = X & (X-1) 清零最低位的 1 

- X & -X => 得到最低位的 1 

- X & ~X => 0

  

### 排序算法

1. 比较类排序： 通过比较来决定元素间的相对次序，由于其时间复杂度不能突破 O(nlogn)，因此也称为非线性时间比较类排序。 
2. 非比较类排序： 不通过比较来决定元素间的相对次序，它可以突破基于比较排序的时间下界，以线性时间运行，因此也称为线性时间非比较类排序。

#### **初级排序 - O(n^2)**

1. 选择排序（Selection Sort） 

   每次找最小值，然后放到待排序数组的起始位置。 

2. 插入排序（Insertion Sort） 

   从前到后逐步构建有序序列；对于未排序数据，在已排序序列中从后 向前扫描，找到相应位置并插入。 

3. 冒泡排序（Bubble Sort） 

   嵌套循环，每次查看相邻的元素如果逆序，则交换。

#### **高级排序 - O(N*LogN)**

- 快速排序（Quick Sort） 

  数组取标杆 pivot，将小元素放 pivot左边，大元素放右侧，然后依次对右边和右边的子数组继续快排；以达到整个序列有序。

  代码示例：
  ``` Python
  #Python
  def quick_sort(begin, end, nums):
      if begin >= end:
          return
      pivot_index = partition(begin, end, nums)
      quick_sort(begin, pivot_index-1, nums)
      quick_sort(pivot_index+1, end, nums)
      
  def partition(begin, end, nums):
      pivot = nums[begin]
      mark = begin
      for i in range(begin+1, end+1):
          if nums[i] < pivot:
              mark +=1
              nums[mark], nums[i] = nums[i], nums[mark]
      nums[begin], nums[mark] = nums[mark], nums[begin]
      return mark
  ```

- 归并排序（Merge Sort）— 分治 

  1. 把长度为n的输入序列分成两个长度为n/2的子序列； 

  2. 对这两个子序列分别采用归并排序； 

  3. 将两个排序好的子序列合并成一个最终的排序序列。

     代码示例：
  ```Python
  #Python
  def mergesort(nums, left, right):
      if right <= left:
          return
      mid = (left+right) >> 1
      mergesort(nums, left, mid)
      mergesort(nums, mid+1, right)
      merge(nums, left, mid, right)
  
  def merge(nums, left, mid, right):
      temp = []
      i = left
      j = mid+1
      while i <= mid and j <= right:
          if nums[i] <= nums[j]:
              temp.append(nums[i])
              i +=1
          else:
              temp.append(nums[j])
              j +=1
      while i<=mid:
          temp.append(nums[i])
          i +=1
      while j<=right:
          temp.append(nums[j])
          j +=1
      nums[left:right+1] = temp
  ```

- 堆排序（Heap Sort） — 堆插入 O(logN)，取最大/小值 O(1) 

  1. 数组元素依次建立小顶堆 

  2. 依次取堆顶元素，并删除

     代码示例：
  ```Python
  #Python
  def heapify(parent_index, length, nums):
      temp = nums[parent_index]
      child_index = 2*parent_index+1
      while child_index < length:
          if child_index+1 < length and nums[child_index+1] > nums[child_index]:
              child_index = child_index+1
          if temp > nums[child_index]:
              break
          nums[parent_index] = nums[child_index]
          parent_index = child_index
          child_index = 2*parent_index + 1
      nums[parent_index] = temp
  
  
  def heapsort(nums):
      for i in range((len(nums)-2)//2, -1, -1):
          heapify(i, len(nums), nums)
      for j in range(len(nums)-1, 0, -1):
          nums[j], nums[0] = nums[0], nums[j]
          heapify(0, j, nums)
  ```
  

#### 特殊排序 - O(n)

- 计数排序（Counting Sort）

  计数排序要求输入的数据必须是有确定范围的整数。将输入的数据值转化为键存储在额外开辟的数组空间中；然后依次把计数大于 1 的填充回原数组。 

- 桶排序（Bucket Sort） 

  桶排序 (Bucket sort)的工作的原理：假设输入数据服从均匀分布，将数据分到有限数量的桶里，每个桶再分别排序（有可能再使用别的排序算法或是以递归方式继续使用桶排序进行排）。 

- 基数排序（Radix Sort） 

  基数排序是按照低位先排序，然后收集；再按照高位排序，然后再收集；依次类推，直到最高位。有时候有些属性是有优先级顺序的，先按低优先级排序，再按高优先级排序。

  

  归并 和 快排 具有相似性，但步骤顺序相反

  归并：先排序左右子数组，然后合并两个有序子数组 

  快排：先调配出左右子数组，然后对于左右子数组进行排序