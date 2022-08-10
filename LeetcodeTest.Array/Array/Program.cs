// Given a binary array nums, return the maximum number of consecutive 1's in the array.


using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetcodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(FindMaxConsecutiveOnes(new[] {1, 0, 1, 1, 0, 1}));
            */
            /*
            Console.WriteLine(FindNumbers(new[] {12,345,2,6,7896}));
            */
            /*
            SortedSquares(new[] {-4, -1, 0, 3, 10});
            */
            /*Merge(new[] {1,2,3,0,0,0}, 3, new[] {2, 5, 6}, 3);*/
            /*RemoveElement(new[] {3, 2, 2, 3}, 3);
            CheckIfExist(new[] {10, 2, 5, 3});*/
            /*ValidMountainArray(new[] {1,3,2});*/
            /*ReplaceElements(new[] {17, 18, 5, 4, 6, 1});
            RemoveDuplicates(new[] {1, 2, 3, 4, 5, 5, 5, 5, 5, 5, 6});
            MoveZeroes(new []{0,1,0,3,12});*/
            /*SortArrayByParity(new[] {3, 1, 2, 4});
            ThirdMax(new[] {1, 2});*/
            /*
            FindDisappearedNumbers(new[] {4, 3, 2, 7, 8, 2, 3, 1});
            */
            FindDisappearedNumbers(new[] {1,1});
        }

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            var count = 0;
            var result = 0;
            foreach (var t in nums)
            {
                if (t == 1)
                {
                    ++count;
                    result = Math.Max(count, result);
                }
                else
                {
                    count = 0;
                }
            }

            return result;
        }

        public static int FindNumbers(int[] nums)
        {
            var count = 0;
            foreach (var num in nums)
            {
                var tempNum = num;
                var currentNum = 0;
                while (tempNum != 0)
                {
                    tempNum /= 10;
                    currentNum++;
                }

                if (currentNum % 2 == 0) ++count;
            }

            return count;
        }

        public static int[] SortedSquares(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];
            }

            Array.Sort(nums);
            return nums;
        }

        public static void DuplicateZeros(int[] arr)
        {
            var queue = new Queue<int>();
            for (var i = 0; i < arr.Length; i++)
            {
                queue.Enqueue(arr[i]);
                if (arr[i] == 0) queue.Enqueue(0);

                arr[i] = queue.Dequeue();
            }
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var num2Index = 0;
            for (int i = m; i < m + n; i++)
            {
                nums1[i] = nums2[num2Index];
                num2Index++;
            }

            Array.Sort(nums1);
        }

        public static int RemoveElement(int[] nums, int val)
        {
            var count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val) continue;
                nums[i] = '_';
                count++;
            }

            Array.Sort(nums);
            return nums.Length - count;
        }

        public static int RemoveDublicate(int[] nums)
        {
            var currentNumIndex = 0;
            foreach (var num in nums)
                if (num != nums[currentNumIndex])
                    nums[++currentNumIndex] = num;

            return currentNumIndex + 1;
        }

        public static bool CheckIfExist(int[] arr)
        {
            Array.Sort(arr);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int left = 0, right = arr.Length - 1, mid;
                while (left <= right)
                {
                    mid = left + (right - left) / 2;
                    if (arr[i] * 2 == arr[mid] && i != mid)
                        return true;
                    if (arr[i] * 2 >= arr[mid])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            return false;
        }
        
        public static bool ValidMountainArray(int[] arr)
        {
            var isOnTop = false;
            
            if (arr.Length < 3 || arr[0] > arr[1])
            {
                return false;
            }
            
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1]) return false;
                if (!isOnTop)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        isOnTop = false;
                        continue;
                    }

                    isOnTop = true;
                }
                else
                {
                    if (arr[i] > arr[i + 1])
                    {
                        continue;
                    }

                    return false;
                }
            }

            return isOnTop;
        }
        
        public static  int[] ReplaceElements(int[] arr) {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var maxElementToReplace = arr[i + 1];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > maxElementToReplace) maxElementToReplace = arr[j];
                }

                arr[i] = maxElementToReplace;
            }

            arr[arr.Length - 1] = -1;

            return arr;
        }
        
        public static int RemoveDuplicates(int[] nums) {
            var currentNumIndex = 0;
            foreach(var num in nums)
                if(num != nums[currentNumIndex]) 
                    nums[++currentNumIndex] = num;
        
            return currentNumIndex + 1;
        }
        
        public static void MoveZeroes(int[] nums)
        {
            var left = 0;
            var right = 0;
            while (right < nums.Length)
            {
                if (nums[right] == 0)
                {
                    right++;
                }
                else
                {
                    (nums[left], nums[right]) = (nums[right], nums[left]);
                    left++;
                    right++;
                }
            }
            Console.WriteLine(nums);
        }
        
        public static int[] SortArrayByParity(int[] nums)
        {
            return nums.OrderByDescending(item => item % 2 == 0).ToArray();
        }
        
        public static int HeightChecker(int[] heights)
        {
            var copyHeights = new int[heights.Length];
            Array.Copy(heights, copyHeights, heights.Length);
            Array.Sort(heights);
            return heights.Where((t, i) => copyHeights[i] != t).Count();
        }

        public static int ThirdMax(int[] nums)
        {
            nums=nums.OrderBy(x=>x).Distinct().ToArray();
            return nums.Length<3 ? nums.Max() : nums[^3];
        }
        
        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            var result = new List<int>();
            var enumerable = nums.Distinct().ToArray();
            for (int i = 1; i <= nums.Length; i++)
            {
                if(Array.BinarySearch(enumerable,i) < 0) result.Add(i);
            }

            return result;
        }
        
        
        private static void SwapInts(int[] array, int position1, int position2)
        {
            (array[position1], array[position2]) = (array[position2], array[position1]);
        }
    }
}