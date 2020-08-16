//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年8月16日 10:54:20
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace NodeEditorFramework.Utilities.CreateNodesWindow
{
    public class CreateNodesAdvancedDropdown: AdvancedDropdown
    {
        private static Vector2 WindowSize = new Vector2(200, 200);

        /// <summary>
        /// 所有Item
        /// </summary>
        private static Dictionary<string, NodeItem> s_AllItems = new Dictionary<string, NodeItem>();

        private static Vector2 m_Pos = Vector2.zero;

        /// <summary>
        /// 展示下拉框
        /// </summary>
        /// <param name="position"></param>
        public static CreateNodesAdvancedDropdown ShowDropdown(Rect position)
        {
            CreateNodesAdvancedDropdown window = new CreateNodesAdvancedDropdown(new AdvancedDropdownState());
            window.minimumSize = WindowSize;
            window.Show(position);
            m_Pos = NodeEditor.ScreenToCanvasSpace(position.position);
            return window;
        }

        public CreateNodesAdvancedDropdown(AdvancedDropdownState state): base(state)
        {
        }

        protected override AdvancedDropdownItem BuildRoot()
        {
            var root = new NodeItem("添加内容");
            s_AllItems.Clear();
            BuildResources(root);
            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item)
        {
            base.ItemSelected(item);
            if (!(item is NodeItem nodeItem))
            {
                Debug.Log("转型失败");
                return;
            }

            Node.Create(nodeItem.NodeId, m_Pos, NodeEditor.curEditorState.canvas, NodeEditor.curEditorState.connectKnob);
            NodeEditor.curEditorState.connectKnob = null;
            NodeEditor.RepaintClients();
        }

        private void BuildResources(NodeItem root)
        {
            foreach (var nodeID in NodeTypes.getCompatibleNodes(null))
            {
                if (NodeCanvasManager.CheckCanvasCompability(nodeID, NodeEditor.curNodeCanvas.GetType()))
                {
                    NodeTypeData nodeTypeData = NodeTypes.getNodeData(nodeID);
                    BuildSingleCategory(root, NodeTypes.getNodeData(nodeID).adress, nodeTypeData.typeID);
                }
            }
        }

        private void BuildSingleCategory(NodeItem root, string targetContent,string nodeId)
        {
            string[] items = targetContent.Split('/');
            NodeItem parentItem = root;
            NodeItem tempItem;
            for (int i = 0; i < items.Length; i++)
            {
                if (s_AllItems.TryGetValue(items[i], out tempItem))
                {
                    parentItem = tempItem;
                }
                else
                {
                    NodeItem childItem = new NodeItem(items[i], nodeId);
                    parentItem.AddChild(childItem);
                    parentItem = childItem;
                    s_AllItems.Add(items[i], parentItem);
                }
            }
        }
    }
}