//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年9月26日 21:30:55
//------------------------------------------------------------

using ETModel;
using NodeEditorFramework;
using Plugins.NodeEditor.Editor.Canvas;
using Sirenix.OdinInspector;
using UnityEditor;

namespace Plugins.NodeEditor.Editor.NPBehaveNodes
{
    [Node(false, "NPBehave行为树/Decorator/Repeater", typeof (NPBehaveCanvas))]
    public class NP_RepeaterNode: NP_DecoratorNodeBase
    {
        /// <summary>
        /// 内部ID
        /// </summary>
        private const string Id = "重复执行结点";

        /// <summary>
        /// 内部ID
        /// </summary>
        public override string GetID => Id;

        [BoxGroup("重复执行结点数据")]
        [HideReferenceObjectPicker]
        [HideLabel]
        public NP_RepeaterNodeData NpRepeaterNodeData = new NP_RepeaterNodeData { NodeType = NodeType.Decorator, NodeDes = "重复执行结点数据" };

        public override NP_NodeDataBase NP_GetNodeData()
        {
            return NpRepeaterNodeData;
        }

        public override void NodeGUI()
        {
            EditorGUILayout.TextField(NpRepeaterNodeData.NodeDes);
        }
    }
}