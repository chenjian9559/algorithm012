# 总结

> **算法源代码在每个项目里的program.cs 文件里** 

---

- [递归](#递归-Recursion)

- [分治](#分治-Divide-&-Conquer)
- [回溯](#回溯-Backtracking)

## 递归 Recursion

泛型递归、树的递归 

递归**本质上是循环**

​	通过函数体来进行的循环 

核心思想是把规模大的问题转化为规模小的相似的子问题来解决。

**思维要点：**

1. 不要人肉进行递归（最大误区）  
2. 找到最近最简方法，将其拆解成可重复解决的问题（重复子问题）  
3. 数学归纳法思维

###     递归代码模板

1. recursion terminator 递归终结
2. process logic in current level 处理当前层逻辑
3. drill down 下探下层
4. reverse the current level status if needed. 清理当前层

		Javascript 代码模板

``` JavaScript
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


## 分治 Divide & Conquer

​	分治和回溯的**本质上也是递归**，算是其中一个的细分类，可能认为特殊或者比较复杂的递归。

***分治***：找问题的重复性。
	重复性有：
		<u>最近重复性</u>：分治/回溯 
		<u>最优重复性</u>：动态规划

​	问题拆机成小问题处理后，组合结果后返回。代码上是递归，是一种函数自我调用缩小问题规模的方法。
	从字面的意思来看，分治法的核心思想就是“分而治之”。利用分而治之的思想，就可以把一个大规模、高难度的问题，分解为若干个小规模、低难度的小问题。

使用方法： 分解问题 =》解决问题 =》合并结果 =》 分解问题 ...

###     分治代码模板

  1. 递归终止条件;

  2. 处理当前逻辑，将大问题如何分解成一个个子问题;

3. 下探到下一层，各个层级解决各个层级的问题;

4. 组装各个层级的结果;

5. 清理当前层;

  Python 代码模板

``` Python
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



## 回溯 Backtracking

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

