# 总结

> **算法源代码在每个项目里的program.cs 文件里** 

- [位运算](#位运算) 
- [布隆过滤器](#布隆过滤器) 
- [排序算法](#排序算法 )

## 位运算

为什么需要位运算：机器里的数字表示方式和存储格式就是二进制 

### **位运算符**

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

### **指定位置的位运算** 

1. 将 x 最右边的 n 位清零：x & (~0 << n) 
2. 获取 x 的第 n 位值（0 或者 1）： (x >> n) & 1 
3. 获取 x 的第 n 位的幂值：x & (1 << n) 
4. 仅将第 n 位置为 1：x | (1 << n) 
5. 仅将第 n 位置为 0：x & (~ (1 << n)) 
6. 将 x 最高位至第 n 位（含）清零：x & ((1 << n) - 1)

### 实战位运算要点 

- 判断奇偶： 

  ​	x % 2 == 1 —> (x & 1) == 1 

  ​	x % 2 == 0 —> (x & 1) == 0 

- x >> 1 —>  x / 2.  

  ​	  即： x = x / 2; —> x = x >> 1; 

  ​		  mid = (left + right) / 2; —> mid = (left + right) >> 1; 

- X = X & (X-1) 清零最低位的 1 

- X & -X => 得到最低位的 1 

- X & ~X => 0

## 布隆过滤器

是一个占用空间很小，效率很高的随机数据结构 。

一个很长的二进制向量和一系列随机映射函数。布隆过滤器可以用于检索 一个元素是否在一个集合中。 

优点: 是空间效率和查询时间都远远超过一般的算法，  

缺点: 是有一定的误识别率和删除困难。

### 什么情况下需要布隆过滤器？

案例 : 

- 先来看几个比较常见的例子
- 字处理软件中，需要检查一个英语单词是否拼写正确
- 在 FBI，一个嫌疑人的名字是否已经在嫌疑名单上
- 在网络爬虫里，一个网址是否被访问过
- 比特币网络  
- 分布式系统（Map-Reduce） — Hadoop、search engine  
- Redis 缓存  
- 垃圾邮件、评论等的过滤 

### 布隆过滤器原理

布隆过滤器（Bloom Filter）的核心实现是一个超大的位数组和几个哈希函数。假设位数组的长度为m，哈希函数的个数为k.

### 布隆过滤器添加元素

- 将要添加的元素给k个哈希函数
- 得到对应于位数组上的k个位置
- 将这k个位置设为1

### 布隆过滤器查询元素

- 将要查询的元素给k个哈希函数
- 得到对应于位数组上的k个位置
- 如果k个位置有一个为0，则肯定不在集合中
- 如果k个位置全部为1，则可能在集合中

## LRU缓存

- 两个要素： 大小 、替换策略  
- Hash Table + Double LinkedList  
- O(1) 查询  
  O(1) 修改、更新



代码示例

```Python
# Python 

class LRUCache(object): 

	def __init__(self, capacity): 
		self.dic = collections.OrderedDict() 
		self.remain = capacity

	def get(self, key): 
		if key not in self.dic: 
			return -1 
		v = self.dic.pop(key) 
		self.dic[key] = v   # key as the newest one 
		return v 

	def put(self, key, value): 
		if key in self.dic: 
			self.dic.pop(key) 
		else: 
			if self.remain > 0: 
				self.remain -= 1 
			else:   # self.dic is full
				self.dic.popitem(last=False) 
		self.dic[key] = value
```

```javascript
// JavaScript
class LRUCache {
  constructor(capacity) {
    this.capacity = capacity;
    this.cache = new Map();
  }

  get(key) {
    if (!this.cache.has(key)) return -1;
    
    let value = this.cache.get(key);
    this.cache.delete(key);
    this.cache.set(key, value);
  }

  put(key, value) {
    if (this.cache.has(key)) {
      this.cache.delete(key);
    } else {
      if (this.cache.size >= this.capacity) {
        // Map 中新 set 的元素会放在后面
        let firstKey = this.cache.keys().next();
        this.cache.delete(firstKey.value);
      }
    }
    this.cache.set(key, value);
  }
}

```

```java
// java
class LRUCache {
    /**
     * 缓存映射表
     */
    private Map<Integer, DLinkNode> cache = new HashMap<>();
    /**
     * 缓存大小
     */
    private int size;
    /**
     * 缓存容量
     */
    private int capacity;
    /**
     * 链表头部和尾部
     */
    private DLinkNode head, tail;

    public LRUCache(int capacity) {
        //初始化缓存大小，容量和头尾节点
        this.size = 0;
        this.capacity = capacity;
        head = new DLinkNode();
        tail = new DLinkNode();
        head.next = tail;
        tail.prev = head;
    }

    /**
     * 获取节点
     * @param key 节点的键
     * @return 返回节点的值
     */
    public int get(int key) {
        DLinkNode node = cache.get(key);
        if (node == null) {
            return -1;
        }
        //移动到链表头部
         (node);
        return node.value;
    }

    /**
     * 添加节点
     * @param key 节点的键
     * @param value 节点的值
     */
    public void put(int key, int value) {
        DLinkNode node = cache.get(key);
        if (node == null) {
            DLinkNode newNode = new DLinkNode(key, value);
            cache.put(key, newNode);
            //添加到链表头部
            addToHead(newNode);
            ++size;
            //如果缓存已满，需要清理尾部节点
            if (size > capacity) {
                DLinkNode tail = removeTail();
                cache.remove(tail.key);
                --size;
            }
        } else {
            node.value = value;
            //移动到链表头部
            moveToHead(node);
        }
    }

    /**
     * 删除尾结点
     *
     * @return 返回删除的节点
     */
    private DLinkNode removeTail() {
        DLinkNode node = tail.prev;
        removeNode(node);
        return node;
    }

    /**
     * 删除节点
     * @param node 需要删除的节点
     */
    private void removeNode(DLinkNode node) {
        node.next.prev = node.prev;
        node.prev.next = node.next;
    }

    /**
     * 把节点添加到链表头部
     *
     * @param node 要添加的节点
     */
    private void addToHead(DLinkNode node) {
        node.prev = head;
        node.next = head.next;
        head.next.prev = node;
        head.next = node;
    }

    /**
     * 把节点移动到头部
     * @param node 需要移动的节点
     */
    private void moveToHead(DLinkNode node) {
        removeNode(node);
        addToHead(node);
    }

    /**
     * 链表节点类
     */
    private static class DLinkNode {
        Integer key;
        Integer value;
        DLinkNode prev;
        DLinkNode next;

        DLinkNode() {
        }

        DLinkNode(Integer key, Integer value) {
            this.key = key;
            this.value = value;
        }
    }
}
```




## 排序算法

1. 比较类排序： 通过比较来决定元素间的相对次序，由于其时间复杂度不能突破 O(nlogn)，因此也称为非线性时间比较类排序。 
2. 非比较类排序： 不通过比较来决定元素间的相对次序，它可以突破基于比较排序的时间下界，以线性时间运行，因此也称为线性时间非比较类排序。

### **初级排序 - O(n^2)** 

1. 选择排序（Selection Sort） 

   每次找最小值，然后放到待排序数组的起始位置。 

2. 插入排序（Insertion Sort） 

   从前到后逐步构建有序序列；对于未排序数据，在已排序序列中从后 向前扫描，找到相应位置并插入。 

3. 冒泡排序（Bubble Sort） 

   嵌套循环，每次查看相邻的元素如果逆序，则交换。

### **高级排序 - O(N*LogN)** 

- 快速排序（Quick Sort） 

  数组取标杆 pivot，将小元素放 pivot左边，大元素放右侧，然后依次对右边和右边的子数组继续快排；以达到整个序列有序。

  代码示例：

  ```Java
  // Java
  public static void quickSort(int[] array, int begin, int end) {
      if (end <= begin) return;
      int pivot = partition(array, begin, end);
      quickSort(array, begin, pivot - 1);
      quickSort(array, pivot + 1, end);
  }
  static int partition(int[] a, int begin, int end) {
      // pivot: 标杆位置，counter: 小于pivot的元素的个数
      int pivot = end, counter = begin;
      for (int i = begin; i < end; i++) {
          if (a[i] < a[pivot]) {
              int temp = a[counter]; a[counter] = a[i]; a[i] = temp;
              counter++;
          }
      }
      int temp = a[pivot]; a[pivot] = a[counter]; a[counter] = temp;
      return counter;
  }
  ```

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

  ```JavaScript
  // JavaScript
  const quickSort = (nums, left, right) => {
    if (nums.length <= 1) return nums
    if (left < right) {
      index = partition(nums, left, right)
      quickSort(nums, left, index-1)
      quickSort(nums, index+1, right)
    }
  }
        
  const partition = (nums, left, right) => {
    let pivot = left, index = left + 1
    for (let i = index; i <= right; i++) {
      if (nums[i] < nums[pivot]) {
        [nums[i], nums[index]] = [nums[index], nums[i]]
        index++
      }
    }
    [nums[pivot], nums[index-1]] = [nums[index-1], nums[pivot]]
    return index -1
  }
  ```

  

- 归并排序（Merge Sort）— 分治 

  1. 把长度为n的输入序列分成两个长度为n/2的子序列； 

  2. 对这两个子序列分别采用归并排序； 

  3. 将两个排序好的子序列合并成一个最终的排序序列。

     代码示例：
     
   ```java
  // Java
  public static void mergeSort(int[] array, int left, int right) {
      if (right <= left) return;
      int mid = (left + right) >> 1; // (left + right) / 2
  
      mergeSort(array, left, mid);
      mergeSort(array, mid + 1, right);
      merge(array, left, mid, right);
  }
  
  public static void merge(int[] arr, int left, int mid, int right) {
          int[] temp = new int[right - left + 1]; // 中间数组
          int i = left, j = mid + 1, k = 0;
  
          while (i <= mid && j <= right) {
              temp[k++] = arr[i] <= arr[j] ? arr[i++] : arr[j++];
          }
  
          while (i <= mid)   temp[k++] = arr[i++];
          while (j <= right) temp[k++] = arr[j++];
  
          for (int p = 0; p < temp.length; p++) {
              arr[left + p] = temp[p];
          }
          // 也可以用 System.arraycopy(a, start1, b, start2, length)
  }
   ```

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

  ```JavaScript
  // JavaScript
  const mergeSort = (nums) => {
    if (nums.length <= 1) return nums
    let mid = Math.floor(nums.length/2), 
        left = nums.slice(0, mid), 
        right = nums.slice(mid)
    return merge(mergeSort(left), mergeSort(right))
  }
  
  const merge(left, right) => {
    let result = []
    while(left.length && right.length) {
      result.push(left[0] <= right[0] ? left.shift() : right.shift()
    }
    while(left.length) result.push(left.shift())
    while(right.length) result.push(right.shift())
    return result
  }
  ```

- 堆排序（Heap Sort） — 堆插入 O(logN)，取最大/小值 O(1) 

  1. 数组元素依次建立小顶堆 

  2. 依次取堆顶元素，并删除

     代码示例：

   ```java
  static void heapify(int[] array, int length, int i) {
      int left = 2 * i + 1, right = 2 * i + 2；
      int largest = i;
      if (left < length && array[left] > array[largest]) {
          largest = left;
      }
      if (right < length && array[right] > array[largest]) {
          largest = right;
      }
      if (largest != i) {
          int temp = array[i]; array[i] = array[largest]; array[largest] = temp;
          heapify(array, length, largest);
      }
  }
  public static void heapSort(int[] array) {
      if (array.length == 0) return;
      int length = array.length;
      for (int i = length / 2-1; i >= 0; i-) 
          heapify(array, length, i);
      for (int i = length - 1; i >= 0; i--) {
          int temp = array[0]; array[0] = array[i]; array[i] = temp;
          heapify(array, i, 0);
      }
  }
   ```

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

  ```javascript
  // Javascript
  function heapSort(arr) {
    if (arr.length === 0) return;
    let len = arr.length;
    // 建堆
    for (let i = Math.floor(len / 2) - 1; i >= 0; i--) {
      heapify(arr, len, i);
    }
    // 排序
    for (let i = len - 1; i >= 0; i--) {
      // 堆顶元素与最后一个互换
      [arr[0], arr[i]] = [arr[i], arr[0]];
      // 对 0 ～ i 的数组建堆
      heapify(arr, i, 0);
    }
  }
  function heapify(arr, len, i) {
    let left = i * 2 + 1;
    let right = i * 2 + 2;
    let largest = i;
    if (left < len && arr[left] > arr[largest]) {
      largest = left;
    }
    if (right < len && arr[right] > arr[largest]) {
      largest = right;
    }
    if (largest !== i) {
      [arr[i], arr[largest]] = [arr[largest], arr[i]];
      heapify(arr, len, largest);
    }
  }
  ```

  

### 特殊排序 - O(n) 

  - 计数排序（Counting Sort）

    计数排序要求输入的数据必须是有确定范围的整数。将输入的数据值转化为键存储在额外开辟的数组空间中；然后依次把计数大于 1 的填充回原数组。 

  - 桶排序（Bucket Sort） 

    桶排序 (Bucket sort)的工作的原理：假设输入数据服从均匀分布，将数据分到有限数量的桶里，每个桶再分别排序（有可能再使用别的排序算法或是以递归方式继续使用桶排序进行排）。 

  - 基数排序（Radix Sort） 

    基数排序是按照低位先排序，然后收集；再按照高位排序，然后再收集；依次类推，直到最高位。有时候有些属性是有优先级顺序的，先按低优先级排序，再按高优先级排序。

    

归并 和 快排 具有相似性，但步骤顺序相反

归并：先排序左右子数组，然后合并两个有序子数组 

快排：先调配出左右子数组，然后对于左右子数组进行排序



