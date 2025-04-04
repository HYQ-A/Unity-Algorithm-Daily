using System;


//57.插入区间
//给你一个 无重叠的 ，按照区间起始端点排序的区间列表 intervals，其中 intervals[i] = [starti, endi] 表示第 i 个区间的开始和结束，并且 intervals 按照 starti 升序排列。同样给定一个区间 newInterval = [start, end] 表示另一个区间的开始和结束。
//在 intervals 中插入区间 newInterval，使得 intervals 依然按照 starti 升序排列，且区间之间不重叠（如果有必要的话，可以合并区间）。
//返回插入之后的 intervals。
//注意 你不需要原地修改 intervals。你可以创建一个新数组然后返回它。
//示例 1：
//输入：intervals = [[1,3],[6,9]], newInterval = [2,5]
//输出：[[1,5],[6,9]]
//示例 2：
//输入：intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
//输出：[[1,2],[3,10],[12,16]]
//解释：这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠。给你一个 无重叠的 ，按照区间起始端点排序的区间列表 intervals，其中 intervals[i] = [starti, endi] 表示第 i 个区间的开始和结束，并且 intervals 按照 starti 升序排列。同样给定一个区间 newInterval = [start, end] 表示另一个区间的开始和结束。
//在 intervals 中插入区间 newInterval，使得 intervals 依然按照 starti 升序排列，且区间之间不重叠（如果有必要的话，可以合并区间）。
//返回插入之后的 intervals。
//注意 你不需要原地修改 intervals。你可以创建一个新数组然后返回它。
//示例 1：
//输入：intervals = [[1,3],[6,9]], newInterval = [2,5]
//输出：[[1,5],[6,9]]
//示例 2：
//输入：intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
//输出：[[1,2],[3,10],[12,16]]
//解释：这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠。

//时间复杂度：O(N)

//贪心
//TODO:待重做巩固
public class Solution1
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        int start = newInterval[0];
        int end = newInterval[1];
        List<int[]> resoult = new List<int[]>();
        bool find = true;//用于判断是否插入新区间

        for (int i = 0;i<intervals.Length;i++)
        {
            int[] current = intervals[i];
            if (current[1] < start)//当前区间在插入区间的左侧且无重叠 则直接添加到新数组中
            {
                resoult.Add(current);
            }
            else if (current[0]>end)//当前区间处于新区间的右侧且无重叠 则直接添加到新数组中
            {
                if(find)//但会漏掉新区间 所以需要在此处先插入新区间 再添加右侧无重叠的旧区间
                {
                    resoult.Add(new int[] { start, end });
                    find = false;
                }
                resoult.Add(current);
            }
            else
            {
                //每次都更新重复区间的开头和结尾
                start = Math.Min(current[0], start);
                end = Math.Max(current[1], end);
            }
        }

        if (find)//当旧区间为空 则直接插入新区间内容
        {
            resoult.Add(new int[] { start, end });
            find = false;
        }

        return resoult.ToArray();
    }
}
