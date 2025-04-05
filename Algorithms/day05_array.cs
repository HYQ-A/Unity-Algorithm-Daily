using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


//867.转置矩阵
//给你一个二维整数数组 matrix， 返回 matrix 的 转置矩阵 。
//矩阵的 转置 是指将矩阵的主对角线翻转，交换矩阵的行索引与列索引。
//示例 1：
//输入：matrix = [[1, 2, 3],[4, 5, 6],[7, 8, 9]]
//输出：[[1, 4, 7],[2, 5, 8],[3, 6, 9]]
//示例 2：
//输入：matrix = [[1, 2, 3],[4, 5, 6]]
//输出：[[1, 4],[2, 5],[3, 6]]

//时间复杂度：O(Mn)

//矩阵
//TODO:待重做巩固
public class Solution1
{
    public int[][] Transpose(int[][] matrix)
    {
        int m = matrix.Length;//原数组行数
        int n = matrix[0].Length;//原数组列数
        int[][] resoult = new int[n][];

        for (int i = 0;i<n;i++)
        {
            resoult[i] = new int[m];//除了要new二维数组的行数，还要new其一维数组有多少
            for (int j = 0;j<m;j++)
            {
                resoult[i][j] = matrix[j][i];//行列互换
            }
        }

        return resoult;
    }
}



//54.螺旋矩阵
//给你一个 m 行 n 列的矩阵 matrix ，请按照 顺时针螺旋顺序 ，返回矩阵中的所有元素。
//示例 1：
//输入：matrix = [[1,2,3],[4,5,6],[7,8,9]]
//输出：[1,2,3,6,9,8,7,4,5]
//示例 2：
//输入：matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
//输出：[1,2,3,4,8,12,11,10,9,5,6,7]给你一个 m 行 n 列的矩阵 matrix ，请按照 顺时针螺旋顺序 ，返回矩阵中的所有元素。
//示例 1：
//输入：matrix = [[1,2,3],[4,5,6],[7,8,9]]
//输出：[1,2,3,6,9,8,7,4,5]
//示例 2：
//输入：matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
//输出：[1,2,3,4,8,12,11,10,9,5,6,7]

//时间复杂度：O(M*N)

//矩阵
//TODO:待重做巩固
public class Solution2
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        List<int> resoult = new List<int>();
        int top = 0;
        int bottom = matrix.Length - 1;
        int left = 0;
        int right = matrix[0].Length - 1;

        while (top <= bottom && left <= right)
        {
            //最上层遍历
            for (int j = left; j <= right; j++)
            {
                resoult.Add(matrix[top][j]);
            }
            top++;

            if (top > bottom) break;

            //最右侧遍历
            for (int j = top; j <= bottom; j++)
            {
                resoult.Add(matrix[j][right]);
            }
            right--;

            if (left > right) break;

            //最底层遍历
            for (int j = right; j >= left; j--)
            {
                resoult.Add(matrix[bottom][j]);
            }
            bottom--;

            if (top > bottom) break;

            //最左侧遍历
            for (int j = bottom; j >= top; j--)
            {
                resoult.Add(matrix[j][left]);
            }
            left++;
        }

        return resoult;
    }
}
