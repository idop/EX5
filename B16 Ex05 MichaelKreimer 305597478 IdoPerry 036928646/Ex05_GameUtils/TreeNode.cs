﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Ex05_GameUtils
{
    public class TreeNode<T> : IEnumerable<TreeNode<T>>
    {
        public T Data
        {
            get;
            set;
        }

        public TreeNode<T> Parent
        {
            get;
            set;
        }

        public ICollection<TreeNode<T>> Children
        {
            get;
            set;
        }

        public int Index
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public TreeNode(T data, int index)
        {
            this.Data = data;
            this.Children = new List<TreeNode<T>>();
            Index = index;
            Score = 0;
        }

        public TreeNode<T> AddChild(T child, int i)
        {
            TreeNode<T> childNode = new TreeNode<T>(child, i) { Parent = this };
            this.Children.Add(childNode);
            return childNode;
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
