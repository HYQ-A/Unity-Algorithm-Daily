using System;


//LCR 074. 合并区间
//以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。请你合并所有重叠的区间，并返回一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间。
//示例 1：
//输入：intervals = [[1,3],[2,6],[8,10],[15,18]]
//输出：[[1,6],[8,10],[15,18]]
//解释：区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
//示例 2：
//输入：intervals = [[1,4],[4,5]]
//输出：[[1,5]]
//解释：区间 [1,4] 和 [4,5] 可被视为重叠区间。以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。请你合并所有重叠的区间，并返回一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间。
//示例 1：
//输入：intervals = [[1,3],[2,6],[8,10],[15,18]]
//输出：[[1,6],[8,10],[15,18]]
//解释：区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
//示例 2：
//输入：intervals = [[1,4],[4,5]]
//输出：[[1,5]]
//解释：区间 [1,4] 和 [4,5] 可被视为重叠区间。

//时间复杂度：O(NLogN)

//排序＋贪心合并思维
//TODO:待重做巩固
public class Solution1
{
    public int[][] Merge(int[][] intervals)
    {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();//先排序，按照每个一元数组第一个元素大小排序，从小到大
        List<int[]> resoult = new List<int[]>();
        resoult.Add(sorted[0]);//将排序后的第一个元素(第一个数组)放入结果集中

        for (int i = 1;i<sorted.Length;i++)//遍历合并
        {
            int[] last = resoult[resoult.Count - 1];
            int[] current = sorted[i];

            if (current[0] <= last[1])//比较当前数组的头部与上一个数组的尾部元素
            {
                last[1] = Math.Max(last[1], current[1]);//更新区间
            }
            else
            {
                resoult.Add(current);
            }
        }

        return resoult.ToArray();
    }
}
