using System;

namespace day06_sort
{
    class Day06_Sort
    {
        /// <summary>
        /// 快速排序算法模板
        /// </summary>
        /// <param name="q">数组</param>
        /// <param name="l">左边界</param>
        /// <param name="r">右边界</param>
        public void quick_sort(int[] q,int l,int r)
        {
            if (l >= r) return;
            int i = l - 1;
            int j = r;
            int x = q[(l + r) / 2];
            while (i < j)
            {
                while (q[--i] < x) ;//一直移动到数值不小于x时
                while (q[++j] > x) ;//一直移动到数值不大于x时
                if (i < j)
                {
                    int tmp = q[i];
                    q[i] = q[j];
                    q[j] = tmp;
                }
            }
            quick_sort(q, l, j);//递归小于x数值的前半段
            quick_sort(q, j + 1, r);//递归大于x数值的后半段
        }


        /// <summary>
        /// 归并排序（适用于原数组已经排序过的）
        /// </summary>
        /// <param name="p">需要排序的数组</param>
        /// <param name="l">左边界</param>
        /// <param name="r">右边界</param>
        int[] temp;//用于临时存储的数组
        public void merge_sort(int[] q,int l,int r)
        {
            if (l >= r) return;
            int mid = (l + r) / 2;//划分为一半
            merge_sort(q, l, mid);//先递归到最小单位(分治)    左边
            merge_sort(q, mid + 1, r);//右边
            int k = 0;
            int i = l;
            int j = mid + 1;
            while (i <= mid && j <= r)
            {
                if ((q[i] <= q[j])) temp[k++] = q[i++];//小的放前面
                else temp[k++] = q[j++];
            }
            while (i <= mid)//当左边有剩余时，全部放入用于存储的临时数组
                temp[k++] = q[i++];
            while (j <= r)//当右边有剩余时，全部放入用于存储的临时数组
                temp[k++] = q[j++];

            for (i = l, j = 0; i <= r; i++, j++)//将临时数组中的返回到原数组
                q[i] = temp[j];
        }
    }
}
