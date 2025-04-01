using System;

//力扣数组1
//两数之和 给定一个数组和值target，数组中两数之和的值为target，输出在数组中的序号即可输入：nums = [2,7,11,15], target = 9
//案例：num[2,7,11,15] target=9
//时间复杂度:O(N^2)
public class Solution1
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }
        return [];
    }
}


//力扣数组15
//给你一个整数数组 nums ，判断是否存在三元组 [nums[i], nums[j], nums[k]] 满足 i != j、i != k 且 j != k ，同时还满足 nums[i] + nums[j] + nums[k] == 0 。请你返回所有和为 0 且不重复的三元组。
//案例：
//输入：nums = [-1,0,1,2,-1,-4]
//输出：[[-1,-1,2],[-1,0,1]]
//解释：
//nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0 。
//nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0 。
//nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0 。
//不同的三元组是 [-1,0,1] 和 [-1,-1,2] 。
//注意，输出的顺序和三元组的顺序并不重要。输入：nums = [-1,0,1,2,-1,-4]
//输出：[[-1,-1,2],[-1,0,1]]
//解释：
//nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0 。
//nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0 。
//nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0 。
//不同的三元组是 [-1,0,1] 和 [-1,-1,2] 。
//注意，输出的顺序和三元组的顺序并不重要。
//时间复杂度:O(N^2)

//使用了双指针的思维
//TODO:待重做巩固
public class Solution2
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        //排序小到大
        Array.Sort(nums);

        //结果集
        IList<IList<int>> resoult = new List<IList<int>>();

        //外层循环固定第一个元素
        for (int i = 0; i < nums.Length - 2; i++)
        {
            //跳过重复元素 注意：当前元素与上一个元素重复才跳过，因为上个元素已经判断寻找过，而下一个为寻找
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            //双指针 一头一尾
            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];
                if (sum == 0)
                {
                    resoult.Add(new List<int>() { nums[i], nums[left], nums[right] });

                    //跳过重复元素
                    while (left < right && nums[left] == nums[left + 1])
                        left++;
                    while (left < right && nums[right] == nums[right - 1])
                        right--;
                    left++;
                    right--;
                }
                else if ((sum < 0))
                {
                    //sum<0则三数之和过小
                    left++;
                }
                else
                {
                    //sum>0则三数之和过大
                    right--;
                }
            }

        }

        return resoult;
    }
}