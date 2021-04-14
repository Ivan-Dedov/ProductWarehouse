using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProductWarehouse
{
    /// <summary>
    /// Represents a third-party between the user (i.e. TreeView) and the warehouse item.
    /// </summary>
    public class WarehouseAdapter
    {
        #region Fields
        private readonly Warehouse warehouse;
        private readonly TreeView treeView;
        #endregion

        #region Constructors
        public WarehouseAdapter(Warehouse warehouse, TreeView treeView)
        {
            this.warehouse = warehouse;
            this.treeView = treeView;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Looks for a specified Storable in the TreeView.
        /// </summary>
        /// <param name="storable">The Storable to look up.</param>
        /// <returns>The TreeNode that corresponds to that Storable.</returns>
        public TreeNode Find(IStorable storable)
        {
            if (storable is null)
            {
                return null;
            }

            Stack<string> pathToStorable = new Stack<string>();
            while (storable.Parent != null)
            {
                pathToStorable.Push(storable.Name);
                storable = storable.Parent as IStorable;
            }
            pathToStorable.Push(storable.Name);

            TreeNode target = null;
            while (pathToStorable.Count > 0)
            {
                target = FindNode(pathToStorable.Pop(), target);
            }
            return target;
        }
        /// <summary>
        /// Looks for a specified Node in the warehouse.
        /// </summary>
        /// <param name="storable">The TreeNode to look up.</param>
        /// <returns>The Storable that corresponds to that TreeNode.</returns>
        public IStorable Find(TreeNode node)
        {
            if (node is null)
            {
                return null;
            }

            Stack<string> pathToNode = new Stack<string>();
            while (node.Parent != null)
            {
                pathToNode.Push(node.Name);
                node = node.Parent;
            }
            pathToNode.Push(node.Name);

            IStorable target = null;
            while (pathToNode.Count > 0)
            {
                target = FindItem(pathToNode.Pop(), target as IContainer);
            }
            return target;
        }

        /// <summary>
        /// Searches for a Node with a specified name and parent (optional).
        /// </summary>
        /// <param name="name">The name of the Node.</param>
        /// <param name="parent">The parent of that Node (null by default).</param>
        /// <returns>The TreeNode with a specified name and parent.</returns>
        private TreeNode FindNode(string name, TreeNode parent = null)
        {
            if (parent == null)
            {
                foreach (TreeNode item in treeView.Nodes)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                throw new KeyNotFoundException("Could not find a Node with a required name.");
            }
            foreach (TreeNode item in parent.Nodes)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            throw new KeyNotFoundException("Could not find a Node with a required name.");
        }
        /// <summary>
        /// Searches for a Storable with a specified name and parent (optional).
        /// </summary>
        /// <param name="name">The name of the Storable.</param>
        /// <param name="parent">The parent of that Storable (null by default).</param>
        /// <returns>The Storable with a specified name and parent.</returns>
        private IStorable FindItem(string name, IContainer parent = null)
        {
            if (parent == null)
            {
                foreach (IStorable item in warehouse.Sections)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                throw new KeyNotFoundException("Could not find an item with a required name.");
            }
            foreach (IStorable item in parent.Items)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            throw new KeyNotFoundException("Could not find a Node with a required name.");
        }

        /// <summary>
        /// Removes a specified Node from the warehouse and the TreeView.
        /// </summary>
        /// <param name="node">The Node to delete.</param>
        public void Remove(TreeNode node)
        {
            TreeNode parentNode = node.Parent;
            if (parentNode is null)
            {
                treeView.Nodes.Remove(node);
            }
            else
            {
                parentNode.Nodes.Remove(node);
            }

            IStorable storable = Find(node);
            IContainer storableParent = storable.Parent;
            if (storableParent is null)
            {
                warehouse.Sections.Remove(storable as Section);
            }
            else
            {
                storableParent.Remove(storable);
            }
        }
        /// <summary>
        /// Removes a specified Storable from the warehouse and the TreeView.
        /// </summary>
        /// <param name="node">The Storable to delete.</param>
        public void Remove(IStorable storable)
        {
            IContainer storableParent = storable.Parent;
            if (storableParent is null)
            {
                storableParent.Items.Remove(storable);
            }
            else
            {
                warehouse.Sections.Remove(storable as Section);
            }

            TreeNode node = Find(storable);
            TreeNode parentNode = node.Parent;
            if (parentNode is null)
            {
                parentNode.Nodes.Remove(node);
            }
            else
            {
                treeView.Nodes.Remove(node);
            }
        }

        /// <summary>
        /// Adds the specified Storable to the warehouse and the TreeView.
        /// </summary>
        /// <param name="storable">The Storable to add.</param>
        public void Add(IStorable storable)
        {
            if (storable is Product p)
            {
                TreeNode parentNode = Find(p.Parent as IStorable);
                if (!NameAlreadyPresent(p.Name, p.Parent))
                {
                    parentNode.Nodes.Add(new TreeNode(storable.Name,
                        Constants.bagIconIndex, Constants.bagIconIndex));
                    parentNode.Nodes[^1].Name = parentNode.Nodes[^1].Text;
                    storable.Parent.Add(p);
                }
                else
                {
                    throw new ArgumentException("This name is already present in the section.");
                }
            }
            else if (storable is Section s)
            {
                if (s.Parent is null)
                {
                    if (!NameAlreadyPresent(s.Name))
                    {
                        treeView.Nodes.Add(new TreeNode(storable.Name,
                        Constants.folderIconIndex, Constants.folderIconIndex));
                        treeView.Nodes[^1].Name = treeView.Nodes[^1].Text;
                        warehouse.Sections.Add(s);
                    }
                    else
                    {
                        throw new ArgumentException("This name is already present in the section.");
                    }
                }
                else
                {
                    TreeNode parentNode = Find(s.Parent as IStorable);
                    if (!NameAlreadyPresent(s.Name, s.Parent))
                    {
                        parentNode.Nodes.Add(new TreeNode(storable.Name,
                            Constants.folderIconIndex, Constants.folderIconIndex));
                        parentNode.Nodes[^1].Name = parentNode.Nodes[^1].Text;
                        storable.Parent.Add(s);
                    }
                    else
                    {
                        throw new ArgumentException("This name is already present in the section.");
                    }
                }
            }
        }

        /// <summary>
        /// Checks whether a name is already present in a specified container.
        /// </summary>
        /// <param name="name">The name to look up.</param>
        /// <param name="container">The container to look through (pass null if the top
        /// layers needs to be checked).</param>
        /// <returns>true, if the name already exists; false, otherwise.</returns>
        private bool NameAlreadyPresent(string name, IContainer container = null)
        {
            if (container is null)
            {
                return warehouse.Sections.Exists(x => x.Name == name);
            }
            return container.Items.Exists(x => x.Name == name);
        }
        #endregion
    }
}