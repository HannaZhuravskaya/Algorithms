using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms.Basic;
using Algorithms.LeetCode;
using Algorithms.Structures;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class SomeTests
    {
        [Fact]
        public static void CheckQuickSort()
        {
            for (int i = 1; i < 100; ++i)
            {
                var random = new Random();
                var expectedArray = Enumerable.Range(0, i);
                var array = expectedArray.Select(i => new Tuple<int, int>(random.Next(100), i))
                                          .OrderBy(i => i.Item1)
                                          .Select(i => i.Item2)
                                          .ToList();

                QuickSort.Sort(array, 0, array.Count - 1);

                if (!expectedArray.SequenceEqual(array))
                    throw new Exception();
            }
        }

        [Fact]
        public static void CheckMergeSort()
        {
            for (int i = 1; i < 100; ++i)
            {
                var random = new Random();
                var expectedArray = Enumerable.Range(0, i);
                var array = expectedArray.Select(i => new Tuple<int, int>(random.Next(100), i))
                                          .OrderBy(i => i.Item1)
                                          .Select(i => i.Item2)
                                          .ToList();

                MergeSort.Sort(array, 0, array.Count - 1);

                if (!expectedArray.SequenceEqual(array))
                    throw new Exception();
            }
        }

        [Fact]
        public static void CheckCustomStack()
        {
            var stack = new CustomStack<int>();

            var list = new List<int>() { 1, 5, 8, 3, 6, 7 };

            foreach (int elem in list)
            {
                stack.Push(elem);
            }

            for (int i = list.Count - 1; i >= 0; --i)
            {
                var value = stack.Pop();
                if (list[i] != value)
                {
                    throw new Exception();
                }
            }

            bool flag = false;

            try
            {
                stack.Pop();
            }
            catch (ArgumentOutOfRangeException)
            {
                flag = true;
            }
            finally
            {
                if (!flag) throw new Exception();
            }
        }

        [Fact]
        public static void CheckCustomQueue()
        {
            var queue = new CustomQueue<int>();

            var list = new List<int>() { 1, 5, 8, 3, 6, 7 };

            foreach (int elem in list)
            {
                queue.Enqueue(elem);
            }

            for (int i = 0; i < list.Count; ++i)
            {
                var value = queue.Dequeue();
                if (list[i] != value)
                {
                    throw new Exception();
                }
            }

            bool flag = false;

            try
            {
                queue.Dequeue();
            }
            catch (ArgumentOutOfRangeException)
            {
                flag = true;
            }
            finally
            {
                if (!flag) throw new Exception();
            }
        }

        [Fact]
        public static void CheckBinarySearch()
        {
            var array = new List<int>() { 1, 2, 6, 8, 10, 15, 37, 58, 60 };

            for (int i = 0; i < array.Count; ++i)
            {
                var res = BinarySearch.FindIndex(array, 0, array.Count - 1, array[i]);

                if (res != i)
                    throw new System.Exception();
            }

            if (BinarySearch.FindIndex(array, 0, array.Count - 1, 7) != -1
                || BinarySearch.FindIndex(array, 0, array.Count - 1, -100) != -1
                || BinarySearch.FindIndex(array, 0, array.Count - 1, 78) != -1)
            {
                throw new System.Exception();
            }
        }

        [Fact]
        public static void CheckSingleLinkedList()
        {
            var linkedList = new SingleLinkedList<int>();

            var list = new List<int>() { 1, 5, 8, 3, 6, 7 };

            foreach (int elem in list)
            {
                linkedList.Insert(elem);
            }

            for (int i = list.Count - 1; i >= 0; --i)
            {
                var value = linkedList.Remove();
                if (list[i] != value || linkedList.Count != i)
                {
                    throw new Exception();
                }
            }

            bool flag = false;

            try { linkedList.Remove(); }
            catch (ArgumentOutOfRangeException) { flag = true; }
            finally { if (!flag) throw new Exception(); }
        }

        [Fact]
        public static void CheckDoubleLinkedList()
        {
            var linkedList = new DoubleLinkedList<int>();

            linkedList.PushBack(1);
            linkedList.Count.Should().Be(1);
            linkedList.PushBack(2);
            linkedList.Count.Should().Be(2);
            linkedList.PushFront(3);
            linkedList.Count.Should().Be(3);
            linkedList.PushFront(4);
            linkedList.Count.Should().Be(4);

            // [4, 3, 1, 2]

            var value = linkedList.PopBack();
            value.Should().Be(2);
            value = linkedList.PopBack();
            value.Should().Be(1);
            value = linkedList.PopBack();
            value.Should().Be(3);
            value = linkedList.PopBack();
            value.Should().Be(4);

            linkedList.PushBack(1);
            linkedList.Count.Should().Be(1);
            linkedList.PushBack(2);
            linkedList.Count.Should().Be(2);
            linkedList.PushFront(3);
            linkedList.Count.Should().Be(3);
            linkedList.PushFront(4);
            linkedList.Count.Should().Be(4);

            // [4, 3, 1, 2]

            value = linkedList.PopFront();
            value.Should().Be(4);
            value = linkedList.PopFront();
            value.Should().Be(3);
            value = linkedList.PopFront();
            value.Should().Be(1);
            value = linkedList.PopFront();
            value.Should().Be(2);

            bool flag = false;

            try { linkedList.PopFront(); }
            catch (ArgumentOutOfRangeException) { flag = true; }
            finally { if (!flag) throw new Exception(); }
        }

        [Fact]
        public static void CheckCustomMap()
        {
            var map = new CustomMap<string, int?>();
            map.Add("this", 1);
            map.Add("coder", 2);
            map.Add("this", 4);
            map.Add("hi", 5);
            map.Size.Should().Be(3);
            map.Remove("this").Should().Be(4);
            map.Remove("this").Should().Be(null);
            map.Size.Should().Be(2);
            map.IsEmpty.Should().Be(false);
        }

        [Fact]
        public static void CheckBinarySearchTree()
        {
            var tree = new BinarySearchTree<int>();
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            tree.Find(20).Should().Be(true);

            var sb = new StringBuilder();

            tree.Inorder((value) => { sb.Append(value); sb.Append(' '); });
            sb.ToString().Should().Be("20 30 40 50 60 70 80 ");
            sb.Clear();

            tree.Preorder((value) => { sb.Append(value); sb.Append(' '); });
            sb.ToString().Should().Be("50 30 20 40 70 60 80 ");
            sb.Clear();

            tree.Postorder((value) => { sb.Append(value); sb.Append(' '); });
            sb.ToString().Should().Be("20 40 30 60 80 70 50 ");
            sb.Clear();

            tree.Delete(20);
            tree.Postorder((value) => { sb.Append(value); sb.Append(' '); });
            sb.ToString().Should().Be("40 30 60 80 70 50 ");
            sb.Clear();

            tree.Find(20).Should().Be(false);
            tree.Find(21456).Should().Be(false);

            tree.Delete(30);
            tree.Postorder((value) => { sb.Append(value); sb.Append(' '); });
            sb.ToString().Should().Be("40 60 80 70 50 ");
            sb.Clear();

            tree.Delete(50);
            tree.Postorder((value) => { sb.Append(value); sb.Append(' '); });
            sb.ToString().Should().Be("40 80 70 60 ");
            sb.Clear();
        }

        [Fact]
        public static void CheckMaxHeap()
        {
            var h = new MaxHeap<int>(12, int.MaxValue);
            h.Insert(3);
            h.Insert(2);
            h.Insert(15);
            h.Insert(5);
            h.Insert(4);
            h.Insert(45);

            h.ExtractMax().Should().Be(45);
            h.MaxValue.Should().Be(15);
            h.ExtractMax().Should().Be(15);

            h.IncreaseValue(0, 100);
            h.MaxValue.Should().Be(100);
            h.ExtractMax().Should().Be(100);
            h.ExtractMax().Should().Be(4);
            h.ExtractMax().Should().Be(3);
            h.ExtractMax().Should().Be(2);


            h = new MaxHeap<int>(new List<int>() { 145, 40, 25, 65, 12, 48, 18, 1, 100, 27, 7, 3, 45, 9, 30 }, int.MaxValue);
            h.MaxValue.Should().Be(145);
            h.ExtractMax().Should().Be(145);
            h.MaxValue.Should().Be(100);
            h.ExtractMax().Should().Be(100);
            h.MaxValue.Should().Be(65);
            h.ExtractMax().Should().Be(65);
        }

        [Fact]
        public static void CheckIsAlienSorted()
        {
            var result = new IsAlienSorted().Check(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz");
            result.Should().Be(true);

            result = new IsAlienSorted().Check(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz");
            result.Should().Be(false);

            result = new IsAlienSorted().Check(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz");
            result.Should().Be(false);

            result = new IsAlienSorted().Check(new string[] { "kuvp", "q" }, "ngxlkthsjuoqcpavbfdermiywz");
            result.Should().Be(true);
        }

        [Fact]
        public static void TrieCheck()
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            trie.Search("apple").Should().Be(true);   // return True
            trie.Search("app").Should().Be(false);     // return False
            trie.StartsWith("app").Should().Be(true); // return True
            trie.Insert("app");
            trie.Search("app").Should().Be(true);     // return True

            trie.Insert("dog");
            trie.Insert("dock");
            trie.Insert("dodge");
            trie.Insert("dark");

            Console.WriteLine(string.Join(", ", trie.GetWordsStartsWith("app")));
            Console.WriteLine(string.Join(", ", trie.GetWordsStartsWith("do")));
        }

        [Fact]
        public static void CheckLongestIncreasingPath()
        {
            var m = new int[3][] { new int[3] { 9, 9, 4 }, new int[3] { 6, 6, 8 }, new int[3] { 2, 1, 1 } };
            var result = new Solution().LongestIncreasingPath(m);
            result.Should().Be(4);

            m = new int[4][] { new int[4] { 7, 6, 1, 1 }, new int[4] { 2, 7, 6, 0 }, new int[4] { 1, 3, 5, 1 }, new int[4] { 6, 6, 3, 2 } };
            result = new Solution().LongestIncreasingPath(m);
            result.Should().Be(7);

            m = new int[15][]
            {
                new int[10]{0,1,2,3,4,5,6,7,8,9},
                new int[10]{19,18,17,16,15,14,13,12,11,10},
                new int[10]{20,21,22,23,24,25,26,27,28,29},
                new int[10]{39,38,37,36,35,34,33,32,31,30},
                new int[10]{40,41,42,43,44,45,46,47,48,49},
                new int[10]{59,58,57,56,55,54,53,52,51,50},
                new int[10]{60,61,62,63,64,65,66,67,68,69},
                new int[10]{79,78,77,76,75,74,73,72,71,70},
                new int[10]{80,81,82,83,84,85,86,87,88,89},
                new int[10]{99,98,97,96,95,94,93,92,91,90},
                new int[10]{100,101,102,103,104,105,106,107,108,109},
                new int[10]{119,118,117,116,115,114,113,112,111,110},
                new int[10]{120,121,122,123,124,125,126,127,128,129},
                new int[10]{139,138,137,136,135,134,133,132,131,130},
                new int[10]{0,0,0,0,0,0,0,0,0,0}
            };

            result = new Solution().LongestIncreasingPath(m);
            result.Should().Be(140);
        }

        [Fact]
        public static void CheckDeepestLeavesSum()
        {
            var root = DeepestLeavesSumTask.CreateTree(new int?[] { 1, 2, 3, 4, 5, null, 6, 7, null, null, null, null, 8 });
            var result = new DeepestLeavesSumTask().DeepestLeavesSum(root);
            result.Should().Be(15);

            root = DeepestLeavesSumTask.CreateTree(new int?[] { 6, 7, 8, 2, 7, 1, 3, 9, null, 1, 4, null, null, null, 5 });
            result = new DeepestLeavesSumTask().DeepestLeavesSum(root);
            result.Should().Be(19);

            root = DeepestLeavesSumTask.CreateTree(new int?[] { 1, null, 2, null, 3 });
            result = new DeepestLeavesSumTask().DeepestLeavesSum(root);
            result.Should().Be(3);
        }

        [Fact]
        public static void LetterCombinationsCheck()
        {
            var result = new LetterCombinationsTask().LetterCombinations("23");
            result.Should().HaveCount(9);
            result.Should().Contain(new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" });

            result = new LetterCombinationsTask().LetterCombinations("2");
            result.Should().HaveCount(3);
            result.Should().Contain(new List<string> { "a", "b", "c" });

            result = new LetterCombinationsTask().LetterCombinations("");
            result.Should().BeEmpty();
        }

        [Fact]
        public static void CheckDijkstraMatrix()
        {
            int[][] graph = new int[9][]
            {
            new int[9] { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            new int[9] { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            new int[9] { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            new int[9] { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            new int[9] { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            new int[9] { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            new int[9] { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            new int[9] { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            new int[9] { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };

            DijkstraMatrix t = new DijkstraMatrix();
            t.Dijkstra(graph, 0).Should().Equal(new int[9] { 0, 4, 12, 19, 21, 11, 9, 8, 14 });

            /*int[, ] graph = new int[, ] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                          { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                          { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                          { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                          { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                          { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                          { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                          { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                          { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            */
        }

        [Fact]
        public static void CheckSingleNumberTask()
        {
            var obj = new SingleNumberTask();

            obj.SingleNumber(new int[] { 2, 2, 1 }).Should().Be(1);
            obj.SingleNumber(new int[] { 4, 1, 2, 1, 2 }).Should().Be(4);
            obj.SingleNumber(new int[] { 1 }).Should().Be(1);
        }
    }
}