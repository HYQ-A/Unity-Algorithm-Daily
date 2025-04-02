using System;


//力扣数组11.盛最多水的容器
//给定一个长度为 n 的整数数组 height 。有 n 条垂线，第 i 条线的两个端点是 (i, 0) 和 (i, height[i]) 。
//找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。
//返回容器可以储存的最大水量。
//说明：你不能倾斜容器。
//案例：
//输入：[1,8,6,2,5,4,8,3,7]
//输出：49 
//解释：图中垂直线代表输入数组 [1,8,6,2,5,4,8,3,7]。在此情况下，容器能够容纳水（表示为蓝色部分）的最大值为 49。输入：[1,8,6,2,5,4,8,3,7]

//时间复杂度：O(N)

//使用了双指针思维
//TODO:待重做巩固
public class Solution1
{
    public int MaxArea(int[] height)
    {
        int area = 0;
        int left = 0;
        int right = height.Length - 1;
        while (left < right)
        {
            int nowHeight = Math.Min(height[left], height[right]);
            int nowWith = right - left;
            int nowArea = nowHeight * nowWith;
            if (nowArea > area)
                area = nowArea;
            if (height[left] < height[right])
                left++;
            else
                right--;
        }

        return area;
    }
}


//我的收藏189.轮转数组
//给定一个整数数组 nums，将数组中的元素向右轮转 k 个位置，其中 k 是非负数。
//示例 1:
//输入: nums = [1,2,3,4,5,6,7], k = 3
//输出: [5,6,7,1,2,3,4]
//解释:
//向右轮转 1 步: [7,1,2,3,4,5,6]
//向右轮转 2 步: [6,7,1,2,3,4,5]
//向右轮转 3 步: [5,6,7,1,2,3,4]给定一个整数数组 nums，将数组中的元素向右轮转 k 个位置，其中 k 是非负数。
//示例 1:
//输入: nums = [1,2,3,4,5,6,7], k = 3
//输出: [5,6,7,1,2,3,4]
//解释:
//向右轮转 1 步: [7,1,2,3,4,5,6]
//向右轮转 2 步: [6,7,1,2,3,4,5]
//向右轮转 3 步: [5,6,7,1,2,3,4]

//时间复杂度：O(N)

//翻转数组，双指针法
//TODO:待重做巩固
public class Solution2
{
    public void Rotate(int[] nums, int k)
    {
        k %= nums.Length;//实际要反转的个数

        Reverse(nums, 0, nums.Length - 1);//第一次翻转全部翻转
        Reverse(nums, 0, k - 1);//第二次翻转前面的数字 恢复原始顺序
        Reverse(nums, k, nums.Length - 1);//第三次翻转剩余的数字 恢复原始顺序
    }

    //翻转函数  双指针法
    private void Reverse(int[] nums, int start, int end)
    {
        while(start<end)
        {
            int temp = nums[end];
            nums[end] = nums[start];
            nums[start] = temp;
            start++;
            end--;
        }
    }
}