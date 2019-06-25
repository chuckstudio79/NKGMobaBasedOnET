﻿using BehaviorDesigner.Runtime.Tasks;
using System;

namespace ETHotfix
{
    public class BehaviorTreeFactory
    {
        public static Component Create(Entity behaviorTreeParent, HotfixAction hotfixAction)
        {
            try
            {
                var behaviorTreeConfig = (BehaviorTreeConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(BehaviorTreeConfig), hotfixAction.behaviorTreeConfigID);
                
                var type = Type.GetType($"ETHotfix.{behaviorTreeConfig.ComponentName}");

                Component component = Game.ObjectPool.Fetch(type);

                ComponentWithId componentWithId = component as ComponentWithId;

                if (componentWithId != null)
                {
                    componentWithId.Id = component.InstanceId;
                }

                Game.EventSystem.Awake(component, behaviorTreeParent, hotfixAction, behaviorTreeConfig);

                if(string.Equals(hotfixAction.FriendlyName, "Hotfix Action"))
                {
                    hotfixAction.FriendlyName = behaviorTreeConfig.Name;
                }

                return component;
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            
            return null;
        }

        public static Component Create(Entity behaviorTreeParent, HotfixDecorator hotfixDecorator)
        {
            try
            {
                var behaviorTreeConfig = (BehaviorTreeConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(BehaviorTreeConfig), hotfixDecorator.behaviorTreeConfigID);

                var type = Type.GetType($"ETHotfix.{behaviorTreeConfig.ComponentName}");

                Component component = Game.ObjectPool.Fetch(type);

                ComponentWithId componentWithId = component as ComponentWithId;

                if (componentWithId != null)
                {
                    componentWithId.Id = component.InstanceId;
                }

                Game.EventSystem.Awake(component, behaviorTreeParent, hotfixDecorator, behaviorTreeConfig);

                if (string.Equals(hotfixDecorator.FriendlyName, "Hotfix Decorator"))
                {
                    hotfixDecorator.FriendlyName = behaviorTreeConfig.Name;
                }
                return component;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            return null;
        }

        public static Component Create(Entity behaviorTreeParent, HotfixConditional hotfixConditional)
        {
            try
            {
                var behaviorTreeConfig = (BehaviorTreeConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(BehaviorTreeConfig), hotfixConditional.behaviorTreeConfigID);

                var type = Type.GetType($"ETHotfix.{behaviorTreeConfig.ComponentName}");

                Component component = Game.ObjectPool.Fetch(type);

                ComponentWithId componentWithId = component as ComponentWithId;

                if (componentWithId != null)
                {
                    componentWithId.Id = component.InstanceId;
                }

                Game.EventSystem.Awake(component, behaviorTreeParent, hotfixConditional, behaviorTreeConfig);

                if (string.Equals(hotfixConditional.FriendlyName, "Hotfix Conditional"))
                {
                    hotfixConditional.FriendlyName = behaviorTreeConfig.Name;
                }

                return component;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            return null;
        }

        public static Component Create(Entity behaviorTreeParent, HotfixComposite hotfixComposite)
        {
            try
            {
                var behaviorTreeConfig = (BehaviorTreeConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(BehaviorTreeConfig), hotfixComposite.behaviorTreeConfigID);

                var type = Type.GetType($"ETHotfix.{behaviorTreeConfig.ComponentName}");

                Component component = Game.ObjectPool.Fetch(type);

                ComponentWithId componentWithId = component as ComponentWithId;

                if (componentWithId != null)
                {
                    componentWithId.Id = component.InstanceId;
                }

                Game.EventSystem.Awake(component, behaviorTreeParent, hotfixComposite, behaviorTreeConfig);

                if (string.Equals(hotfixComposite.FriendlyName, "Hotfix Composite"))
                {
                    hotfixComposite.FriendlyName = behaviorTreeConfig.Name;
                }

                return component;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

            return null;
        }

        public static BehaviorTree Create(Entity parent, BehaviorDesigner.Runtime.BehaviorTree behaviorTree)
        {
            var behavior = parent.AddComponent<BehaviorTree, BehaviorDesigner.Runtime.BehaviorTree>(behaviorTree);
            behavior.AddComponent<BehaviorTreeVariableComponent>();
            behavior.AddComponent<BehaviorTreeComponent>();
            return behavior;
        }
    }
}
